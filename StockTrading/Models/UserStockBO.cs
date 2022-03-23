using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StockTrading.Models
{
    /// <summary>
    /// Class for User stock BO
    /// </summary>
    public class UserStockBO
    {
        /// <summary>
        /// Gets or sets user transaction id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets UseId
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Gets or sets Stock Id
        /// </summary>
        public int StockId { get; set; }

        /// <summary>
        /// Gets or sets Company Name
        /// </summary>
        public string CompanyName { get; set; }

        /// <summary>
        /// Ges or sets Type of action (buy / sell)
        /// </summary>
        public int Type { get; set; }

        /// <summary>
        /// Ges or sets quantity of share
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Ges or sets buying price of shares
        /// </summary>
        public string BuyingPrice { get; set; }
       
        /// <summary>
        /// Ges or sets total price of buying shares
        /// </summary>
        public string BuyingAmount { get; set; }

        /// <summary>
        /// Ges or sets date of transaction for bying shares
        /// </summary>
        public DateTime BuyingDate { get; set; }

        /// <summary>
        /// Ges or sets selling price of shares
        /// </summary>
        public string SellingPrice { get; set; }

        /// <summary>
        /// Ges or sets total price of selling shares
        /// </summary>
        public string SellingAmount { get; set; }

        /// <summary>
        /// Ges or sets date of transaction for selling shares
        /// </summary>
        public DateTime SellingDate { get; set; }

        /// <summary>
        /// Gets or sets Market price
        /// </summary>
        public string MarketPrice { get; set; }

        /// <summary>
        /// Ges or sets total price of shares
        /// </summary>
        public string GainAmount { get; set; }

        /// <summary>
        /// Ges or sets total price of shares
        /// </summary>
        public string ProfitLoss { get; set; }

        /// <summary>
        /// Ges or sets for shares sold or not
        /// </summary>
        public bool IsSold { get; set; }

        // <summary>
        /// Gets or sets price status whetjer price increased or decreased
        /// If Price incresed or same then 1 decreased 0
        /// </summary>
        public bool PriceStatus { get; set; }

        
    }
}