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
    /// Class for stock data
    /// </summary>
    public class StockData
    {
        /// <summary>
        /// Logger Declaration
        /// </summary>
        private readonly ILog log;

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthenticationData" /> class
        /// </summary>
        public StockData()
        {
            this.log = log4net.LogManager.GetLogger("File");
        }

        /// <summary>
        /// Method to Get all the stock information
        /// </summary>
        /// <returns>Return List of all stocks</returns>
        public List<StockBO> FindStockDetails()
        {
            DataSet ObjDataSet = new DataSet();
            List<StockBO> lstStockDetails = new List<StockBO>();

            try
            {
                ObjDataSet = SqlHelper.ExecuteDataset(SqlHelper.Connect(), CommandType.StoredProcedure, ProceduresData.GetAllStocks);
                if (ObjDataSet.Tables.Count > 0 && ObjDataSet.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow item in ObjDataSet.Tables[0].Rows)
                    {
                        StockBO stockBO = new StockBO();
                        stockBO.StockId = Convert.ToInt32(item["StockId"]);
                        stockBO.CompanyName = Convert.ToString(item["CompanyName"]);
                        stockBO.StockTicker = Convert.ToString(item["StockTicker"]);
                        stockBO.Volume = Convert.ToString(item["Volume"]);
                        stockBO.InitialPrice = Convert.ToString(item["InitialPrice"]);
                        stockBO.MarketPrice = Convert.ToString(item["MarketPrice"]);
                        stockBO.MarketCap = Convert.ToString(Convert.ToDecimal(stockBO.MarketPrice) * Convert.ToDecimal(stockBO.Volume));
                        stockBO.OpenPrice = Convert.ToString(item["OpenPrice"]);
                        stockBO.TodayLow = Convert.ToString(item["TodayLow"]);
                        stockBO.TodayHigh = Convert.ToString(item["TodayHigh"]);
                        stockBO.PriceStatus = Convert.ToDecimal(stockBO.MarketPrice) >= Convert.ToDecimal(stockBO.OpenPrice);
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

        /// <summary>
        /// Method to add the stock
        /// </summary>
        /// <param name="stockBO">Stock details</param>
        /// <returns>Return int whether stock is saved or not</returns>
        public int AddStockDetails(StockBO stockBO)
        {
            int result = 0;
            SqlParameter[] ObjSqlParam = new SqlParameter[4];

            try
            {
                ObjSqlParam[0] = new SqlParameter("@CompanyName", SqlDbType.VarChar);
                ObjSqlParam[0].Value = stockBO.CompanyName;

                ObjSqlParam[1] = new SqlParameter("@StockTicker", SqlDbType.VarChar);
                ObjSqlParam[1].Value = stockBO.StockTicker;

                ObjSqlParam[2] = new SqlParameter("@Volume", SqlDbType.VarChar);
                ObjSqlParam[2].Value = stockBO.Volume ;

                ObjSqlParam[3] = new SqlParameter("@InitialPrice", SqlDbType.VarChar);
                ObjSqlParam[3].Value = stockBO.InitialPrice;

                result = SqlHelper.ExecuteNonQuery(SqlHelper.Connect(), CommandType.StoredProcedure, ProceduresData.SaveStockDetails, ObjSqlParam);
            }
            catch (Exception ex)
            {
                this.log.Fatal(this.GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name + " - Exception - ", ex);
            }

            return result;
        }

        /// <summary>
        /// Method to update open price
        /// </summary>
        /// <returns></returns>
        public int UpdateOpenPrice()
        {
            int result = 0;
            try
            {
                result = SqlHelper.ExecuteNonQuery(SqlHelper.Connect(), CommandType.Text, ProceduresData.UpdateOpenPrice);
            }
            catch (Exception ex)
            {
                this.log.Fatal(this.GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name + " - Exception - ", ex);
            }

            return result;
        }

        /// <summary>
        /// Method to add the user stock transaction
        /// </summary>
        /// <param name="stockBO">User Stock details</param>
        /// <returns>Return int whether user stock is saved or not</returns>
        public int AddUserStockDetails(UserStockBO stockBO)
        {
            int result = 0;
            SqlParameter[] ObjSqlParam = new SqlParameter[11];

            try
            {
                ObjSqlParam[0] = new SqlParameter("@Id", SqlDbType.Int);
                ObjSqlParam[0].Value = stockBO.Id;

                ObjSqlParam[1] = new SqlParameter("@UserId", SqlDbType.Int);
                ObjSqlParam[1].Value = stockBO.UserId;

                ObjSqlParam[2] = new SqlParameter("@Type", SqlDbType.Int);
                ObjSqlParam[2].Value = stockBO.Type;

                ObjSqlParam[3] = new SqlParameter("@StockId", SqlDbType.Int);
                ObjSqlParam[3].Value = stockBO.StockId;

                ObjSqlParam[4] = new SqlParameter("@Quantity", SqlDbType.Int);
                ObjSqlParam[4].Value = stockBO.Quantity;

                ObjSqlParam[5] = new SqlParameter("@BuyingPrice", SqlDbType.VarChar);
                ObjSqlParam[5].Value = stockBO.BuyingPrice;

                ObjSqlParam[6] = new SqlParameter("@BuyingAmount", SqlDbType.VarChar);
                ObjSqlParam[6].Value = stockBO.BuyingAmount;

                ObjSqlParam[7] = new SqlParameter("@BuyingDate", SqlDbType.DateTime);
                ObjSqlParam[7].Value = DateTime.Now;

                ObjSqlParam[8] = new SqlParameter("@SellingPrice", SqlDbType.VarChar);
                ObjSqlParam[8].Value = stockBO.SellingPrice;

                ObjSqlParam[9] = new SqlParameter("@SellingAmount", SqlDbType.VarChar);
                ObjSqlParam[9].Value = stockBO.SellingAmount;

                ObjSqlParam[10] = new SqlParameter("@SellingDate", SqlDbType.DateTime);
                ObjSqlParam[10].Value = DateTime.Now;

                result = SqlHelper.ExecuteNonQuery(SqlHelper.Connect(), CommandType.StoredProcedure, ProceduresData.SaveUserStockDetails, ObjSqlParam);
            }
            catch (Exception ex)
            {
                this.log.Fatal(this.GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name + " - Exception - ", ex);
            }

            return result;
        }
    }
}