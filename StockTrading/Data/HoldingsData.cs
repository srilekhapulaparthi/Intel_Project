using log4net;
using StockTrading.Helpers;
using StockTrading.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace StockTrading.Data
{
    /// <summary>
    /// Class for Holdings data
    /// </summary>
    public class HoldingsData
    {
        /// <summary>
        /// Logger Declaration
        /// </summary>
        private readonly ILog log;

        /// <summary>
        /// Initializes a new instance of the <see cref="HoldingsData" /> class
        /// </summary>
        public HoldingsData()
        {
            this.log = log4net.LogManager.GetLogger("File");
        }

        /// <summary>
        /// Method to Get all the stock information
        /// </summary>
        /// <returns>Return List of all stocks</returns>
        public List<UserStockBO> FindHoldingDetails(int userId)
        {
            DataSet ObjDataSet = new DataSet();
            List<UserStockBO> lstStockDetails = new List<UserStockBO>();
            SqlParameter[] ObjSqlParam = new SqlParameter[1];
            try
            {
                ObjSqlParam[0] = new SqlParameter("@UserId", SqlDbType.Int);
                ObjSqlParam[0].Value = userId;

                ObjDataSet = SqlHelper.ExecuteDataset(SqlHelper.Connect(), CommandType.StoredProcedure, ProceduresData.GetAllHoldings, ObjSqlParam);
                if (ObjDataSet.Tables.Count > 0 && ObjDataSet.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow item in ObjDataSet.Tables[0].Rows)
                    {
                        UserStockBO stockBO = new UserStockBO();
                        stockBO.Id = Convert.ToInt32(item["Id"]);
                        stockBO.StockId = Convert.ToInt32(item["StockId"]);
                        stockBO.CompanyName = Convert.ToString(item["CompanyName"]);
                        stockBO.Quantity = Convert.ToInt32(item["Quantity"]);
                        stockBO.MarketPrice = Convert.ToString(item["MarketPrice"]);
                        stockBO.BuyingPrice = string.IsNullOrEmpty(item["BuyingPrice"].ToString()) ? "0" : Convert.ToString(item["BuyingPrice"]);
                        stockBO.BuyingAmount = string.IsNullOrEmpty(item["BuyingAmount"].ToString()) ? "0" : Convert.ToString(item["BuyingAmount"]);
                        if (!string.IsNullOrEmpty(item["BuyingDate"].ToString()))
                        {
                            stockBO.BuyingDate = Convert.ToDateTime(item["BuyingDate"]);
                        }
                        stockBO.SellingPrice = string.IsNullOrEmpty(item["SellingPrice"].ToString()) ? "0" : Convert.ToString(item["SellingPrice"]);
                        stockBO.SellingAmount = string.IsNullOrEmpty(item["SellingAmount"].ToString()) ? "0" : Convert.ToString(item["SellingAmount"]);
                        if (!string.IsNullOrEmpty(item["SellingDate"].ToString()))
                        {
                            stockBO.SellingDate = Convert.ToDateTime(item["SellingDate"]);
                        }
                        stockBO.IsSold = Convert.ToBoolean(item["IsSold"]);
                        stockBO.ProfitLoss = string.IsNullOrEmpty(stockBO.SellingAmount) ? stockBO.BuyingAmount :  Convert.ToString(Convert.ToDecimal(stockBO.SellingAmount) - Convert.ToDecimal(stockBO.BuyingAmount));
                        stockBO.GainAmount = Convert.ToString(((stockBO.Quantity * Convert.ToDecimal(stockBO.MarketPrice)) - Convert.ToDecimal(stockBO.BuyingAmount)));
                        stockBO.PriceStatus = Convert.ToDecimal(stockBO.GainAmount) > 0;
                        lstStockDetails.Add(stockBO);
                    }
                }
            }
            catch (Exception ex)
            {
                this.log.Fatal(this.GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name + " - Exception - ", ex);
            }
            return lstStockDetails;
        }
    }
}