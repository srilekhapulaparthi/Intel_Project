using StockTrading.Data;
using StockTrading.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StockTrading.Service
{
    /// <summary>
    /// Class for holdings service
    /// </summary>
    public class HoldingsService
    {
        /// <summary>
        /// Holdings Details Data
        /// </summary>
        private readonly HoldingsData holdingsData;

        /// <summary>
        /// Initializes a new instance of the <see cref="HoldingsService" /> class
        /// </summary>
        public HoldingsService()
        {
            this.holdingsData = new HoldingsData();
        }

        /// <summary>
        /// Method to Get all the holdings information
        /// </summary>
        /// <param name="userId">User id</param>
        /// <returns>Return List of all holdings</returns>
        public List<UserStockBO> GetHoldingDetails(int userId)
        {
            return this.holdingsData.FindHoldingDetails(userId);
        }
    }
}