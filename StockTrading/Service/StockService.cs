using StockTrading.Data;
using StockTrading.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StockTrading.Service
{
    /// <summary>
    /// Class for stock service
    /// </summary>
    public class StockService
    {
        /// <summary>
        /// Stock Details Data
        /// </summary>
        private readonly StockData stockData;

        /// <summary>
        /// Initializes a new instance of the <see cref="StockService" /> class
        /// </summary>
        public StockService()
        {
            this.stockData = new StockData();
        }

        /// <summary>
        /// Method to Get all stock details
        /// </summary>
        /// <param name="objUserBO"></param>
        /// <returns>Return list of all stock details</returns>
        public List<StockBO> GetAllStockDetails()
        {
            return this.stockData.FindStockDetails();
        }

        /// <summary>
        /// Method to add the stock
        /// </summary>
        /// <param name="stockBO">Stock details</param>
        /// <returns>Return int whether stock is saved or not</returns>
        public int SaveStockDetails(StockBO stockBO)
        {
            return this.stockData.AddStockDetails(stockBO);
        }

        /// <summary>
        /// Method to add the user stock transaction
        /// </summary>
        /// <param name="stockBO">User Stock details</param>
        /// <returns>Return int whether user stock is saved or not</returns>
        public int SaveUserStockDetails(UserStockBO stockBO)
        {
            return this.stockData.AddUserStockDetails(stockBO);
        }
    }
}