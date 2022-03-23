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
    /// Class for Funds data
    /// </summary>
    public class FundsData
    {
        /// <summary>
        /// Logger Declaration
        /// </summary>
        private readonly ILog log;

        /// <summary>
        /// Initializes a new instance of the <see cref="FundsData" /> class
        /// </summary>
        public FundsData()
        {
            this.log = log4net.LogManager.GetLogger("File");
        }

        /// <summary>
        ///  Method to Get all the funds list
        /// </summary>
        /// <param name="userId">User Id</param>
        /// <returns>Returns funds transaction list</returns>
        public List<FundsBO> FindFundsDetails(int userId)
        {
            DataSet ObjDataSet = new DataSet();
            List<FundsBO> lstFundsData = new List<FundsBO>(); 
            SqlParameter[] ObjSqlParam = new SqlParameter[1];
            try
            {
                ObjSqlParam[0] = new SqlParameter("@UserId", SqlDbType.VarChar);
                ObjSqlParam[0].Value = userId;

                ObjDataSet = SqlHelper.ExecuteDataset(SqlHelper.Connect(), CommandType.StoredProcedure, ProceduresData.GetFundsDataByUsers, ObjSqlParam);
                if (ObjDataSet.Tables.Count > 0 && ObjDataSet.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow item in ObjDataSet.Tables[0].Rows)
                    {
                        FundsBO fundsBO = new FundsBO();
                        fundsBO.TransactionId = Convert.ToInt32(item["TransactionId"]);
                        fundsBO.FundType = Convert.ToInt32(item["FundType"]);
                        fundsBO.FundTypeName = Convert.ToString(item["FundTypeName"]);
                        fundsBO.DebitAmount = Convert.ToDecimal(item["DebitAmount"]);
                        fundsBO.CreditAmount = Convert.ToDecimal(item["CreditAmount"]);
                        fundsBO.TransactionDate = Convert.ToDateTime(item["TransactionDate"]);
                        lstFundsData.Add(fundsBO);
                    }
                }
            }
            catch (Exception ex)
            {
                this.log.Fatal(this.GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name + " - Exception - ", ex);
            }
            return lstFundsData;
        }

        /// <summary>
        /// Method to add or withdraw funds
        /// </summary>
        /// <param name="fundsBO">funds details</param>
        /// <returns>Return int whether funds is saved or not</returns>
        public int AddFundDetails(FundsBO fundsBO)
        {

            int result = 0;
            SqlParameter[] ObjSqlParam = new SqlParameter[5];

            try
            {
                ObjSqlParam[0] = new SqlParameter("@UserId", SqlDbType.Int);
                ObjSqlParam[0].Value = fundsBO.UserId;

                ObjSqlParam[1] = new SqlParameter("@FundType", SqlDbType.Int);
                ObjSqlParam[1].Value = fundsBO.FundType;

                ObjSqlParam[2] = new SqlParameter("@DebitAmount", SqlDbType.VarChar);
                ObjSqlParam[2].Value = fundsBO.DebitAmount;

                ObjSqlParam[3] = new SqlParameter("@CreditAmount", SqlDbType.VarChar);
                ObjSqlParam[3].Value = fundsBO.CreditAmount;

                ObjSqlParam[4] = new SqlParameter("@TransactionDate", SqlDbType.DateTime);
                ObjSqlParam[4].Value = Convert.ToDateTime(fundsBO.TransactionDate);

                result = SqlHelper.ExecuteNonQuery(SqlHelper.Connect(), CommandType.StoredProcedure, ProceduresData.SaveFundDetails, ObjSqlParam);
            }
            catch (Exception ex)
            {
                result = 0;
                this.log.Fatal(this.GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name + " - Exception - ", ex);
            }

            return result;
        }
    }
}