using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StockTrading.Models
{
    /// <summary>
    /// Class for Stock BO
    /// </summary>
    public class StockBO
    {
        /// <summary>
        /// Gets or sets StockId
        /// </summary>
        public int StockId { get; set; }

        /// <summary>
        /// Gets or sets Company Name
        /// </summary>
        public string CompanyName { get; set; }
        
        /// <summary>
        /// Gets or sets Stock Ticker
        /// </summary>
        public string StockTicker { get; set; }

        /// <summary>
        /// Gets or sets Volume
        /// </summary>
        public string Volume { get; set; }

        /// <summary>
        /// Gets or sets Initial price
        /// </summary>
        public string InitialPrice { get; set; }

        /// <summary>
        /// Gets or sets Market price
        /// </summary>
        public string MarketPrice { get; set; }

        /// <summary>
        /// Gets or sets Market Capital
        /// </summary>
        public string MarketCap { get; set; }

        /// <summary>
        /// Gets or sets Open price
        /// </summary>
        public string OpenPrice { get; set; }

        /// <summary>
        /// Gets or sets Todays low price
        /// </summary>
        public string TodayLow { get; set; }

        // <summary>
        /// Gets or sets Todays high price
        /// </summary>
        public string TodayHigh { get; set; }

        // <summary>
        /// Gets or sets price status whetjer price increased or decreased
        /// If Price incresed or same then 1 decreased 0
        /// </summary>
        public bool PriceStatus { get; set; }

    }
}