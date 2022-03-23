using StockTrading.Data;
using StockTrading.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StockTrading.Service
{
    /// <summary>
    /// Class for funds service
    /// </summary>
    public class FundsService
    {
        /// <summary>
        /// Funds Details Data
        /// </summary>
        private readonly FundsData fundsData;

        /// <summary>
        /// Initializes a new instance of the <see cref="FundsService" /> class
        /// </summary>
        public FundsService()
        {
            this.fundsData = new FundsData();
        }

        /// <summary>
        ///  Method to Get all the funds list
        /// </summary>
        /// <param name="userId">User Id</param>
        /// <returns>Returns funds transaction list</returns>
        public List<FundsBO> GetFundsDetails(int userId)
        {
            return this.fundsData.FindFundsDetails(userId);
        }

        /// <summary>
        /// Method to add or withdraw funds
        /// </summary>
        /// <param name="fundsBO">funds details</param>
        /// <returns>Return int whether funds is saved or not</returns>
        public int SaveFundDetails(FundsBO fundsBO)
        {
            return this.fundsData.AddFundDetails(fundsBO);
        }
    }
}