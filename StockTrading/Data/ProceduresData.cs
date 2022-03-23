using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StockTrading.Data
{
    /// <summary>
    /// Class for Procedure Information
    /// </summary>
    public class ProceduresData
    {
        /// <summary>
        /// Procedure to get user details by email and password
        /// </summary>
        public const string GetUserDetailsByEmail = "Proc_GetUserDetailsByEmailandPassword";

        /// <summary>
        /// Procedure to update user password
        /// </summary>
        public const string UpdatePassword = "Update [User] SET Password = {0} WHERE UserId = {1}";

        /// <summary>
        /// Procedure to save new user
        /// </summary>
        public const string SaveUserDetails = "Proc_AddUserDetails";

        /// <summary>
        /// Procedure to get all stocks details
        /// </summary>
        public const string GetAllStocks = "Proc_GetAllStock";
        
        /// <summary>
        /// Procedure to save stocks details
        /// </summary>
        public const string SaveStockDetails = "Proc_AddStockDetails";

        /// <summary>
        /// Procedure to save user stocks details
        /// </summary>
        public const string SaveUserStockDetails = "Proc_AddUserStockDetails";

        /// <summary>
        /// Query to get holidays list
        /// </summary>
        public const string GetAllHolidays = "Select * from [dbo].[HolidaysList];";

        /// <summary>
        /// Procedure to get user fund details
        /// </summary>
        public const string GetFundsDataByUsers = "Proc_GetFundsDetailByUser";

        /// <summary>
        /// Procedure to add or withdraw fund details
        /// </summary>
        public const string SaveFundDetails = "Proc_AddFundDetails";

        /// <summary>
        /// Procedure to update market prices
        /// </summary>
        public const string UpdateMarketPrice = "Update_MarketPrices";
        
        /// <summary>
        /// Procedure to update Open price
        /// </summary>
        public const string UpdateOpenPrice = "Update Stocks SET OpenPrice = MarketPrice";

        /// <summary>
        /// Procedure to get all holding details
        /// </summary>
        public const string GetAllHoldings = "Proc_GetAllHoldings";
    }
}