using log4net;
using StockTrading.Helpers;
using StockTrading.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using static StockTrading.Models.UserBO;

namespace StockTrading.Data
{
    /// <summary>
    /// Class for User data
    /// </summary>
    public class UserData
    {
        /// <summary>
        /// Logger Declaration
        /// </summary>
        private readonly ILog log;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserData" /> class
        /// </summary>
        public UserData()
        {
            this.log = log4net.LogManager.GetLogger("File");
        }

        /// <summary>
        /// Method to Get User Details By User Name and Password
        /// </summary>
        /// <param name="email">Email id</param>
        /// <param name="password">User password</param>
        /// <returns>Returns user details</returns>
        public UserBO FindUserDetailsByUserNameAndPassword(string email, string password)
        {
            DataSet ObjDataSet = new DataSet();
            SqlParameter[] ObjSqlParam = new SqlParameter[2];
            UserBO ObjLoginUserBO = new UserBO();

            try
            {
                ObjSqlParam[0] = new SqlParameter("@Email", SqlDbType.VarChar);
                ObjSqlParam[0].Value = email;

                ObjSqlParam[1] = new SqlParameter("@Password", SqlDbType.VarChar);
                ObjSqlParam[1].Value = password;

                ObjDataSet = SqlHelper.ExecuteDataset(SqlHelper.Connect(), CommandType.StoredProcedure, ProceduresData.GetUserDetailsByEmail, ObjSqlParam);
                if (ObjDataSet.Tables[0].Rows.Count > 0)
                {
                    ObjLoginUserBO.UserId = Convert.ToInt32(ObjDataSet.Tables[0].Rows[0]["UserId"]);
                    ObjLoginUserBO.RoleId = Convert.ToInt32(ObjDataSet.Tables[0].Rows[0]["RoleId"]);
                    ObjLoginUserBO.FirstName = Convert.ToString(ObjDataSet.Tables[0].Rows[0]["FirstName"]);
                    ObjLoginUserBO.LastName = Convert.ToString(ObjDataSet.Tables[0].Rows[0]["LastName"]);
                    ObjLoginUserBO.Email = Convert.ToString(ObjDataSet.Tables[0].Rows[0]["Email"]);
                    ObjLoginUserBO.MobileNo = Convert.ToString(ObjDataSet.Tables[0].Rows[0]["MobileNo"]);
                    ObjLoginUserBO.AvailableCash = Convert.ToDecimal(ObjDataSet.Tables[0].Rows[0]["Funds"]);
                }
            }
            catch (Exception ex)
            {
                this.log.Fatal(this.GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name + " - Exception - ", ex);
            }
            return ObjLoginUserBO;
        }

        /// <summary>
        /// Method to save user details
        /// </summary>
        /// <param name="userDetails">user model</param>
        /// <returns>Returns int whether user created or not</returns>
        public int AddUserDetails(UserBO userDetails)
        {
            int result = 0;
            SqlParameter[] ObjSqlParam = new SqlParameter[5];
            try
            {
                ObjSqlParam[0] = new SqlParameter("@RoleId", SqlDbType.Int);
                ObjSqlParam[0].Value = userDetails.RoleId;

                ObjSqlParam[1] = new SqlParameter("@FirstName", SqlDbType.VarChar);
                ObjSqlParam[1].Value = userDetails.FirstName;

                ObjSqlParam[2] = new SqlParameter("@LastName", SqlDbType.VarChar);
                ObjSqlParam[2].Value = userDetails.LastName;

                ObjSqlParam[3] = new SqlParameter("@Email", SqlDbType.VarChar);
                ObjSqlParam[3].Value = userDetails.Email;

                ObjSqlParam[4] = new SqlParameter("@MobileNo", SqlDbType.VarChar);
                ObjSqlParam[4].Value = userDetails.MobileNo;

                result = SqlHelper.ExecuteNonQuery(SqlHelper.Connect(), CommandType.StoredProcedure, ProceduresData.SaveUserDetails, ObjSqlParam);
            }
            catch (Exception ex)
            {
                this.log.Fatal(this.GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name + " - Exception - ", ex);
            }

            return result;
        }

        /// <summary>
        /// Method to update user password
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="password"></param>
        /// <returns>Returns int whether user password is updated or not</returns>
        public int AddUserPassword(int userId, string password)
        {
            int result = 0;
            try
            {
                result = SqlHelper.ExecuteNonQuery(SqlHelper.Connect(), CommandType.Text, string.Format(ProceduresData.UpdatePassword, password, userId));
            }
            catch (Exception ex)
            {
                this.log.Fatal(this.GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name + " - Exception - ", ex);
            }

            return result;
        }
    }
}