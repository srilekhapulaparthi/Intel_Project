using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StockTrading.Models
{
    /// <summary>
    /// Class for Funds BO
    /// </summary>
    public class FundsBO
    {
        /// <summary>
        /// Gets or sets Transaction Id
        /// </summary>
        public int TransactionId { get; set; }

        /// <summary>
        /// Ges or sets User Id
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Ges or sets Fund Type
        /// </summary>
        public int FundType { get; set; }

        /// <summary>
        /// Ges or sets Fund Name
        /// </summary>
        public string FundTypeName { get; set; }
        
        /// <summary>
        /// Ges or sets Amount
        /// </summary>
        public decimal DebitAmount { get; set; }

        /// <summary>
        /// Ges or sets Amount
        /// </summary>
        public decimal CreditAmount { get; set; }

        /// <summary>
        /// Ges or sets Transaction Date
        /// </summary>
        public DateTime TransactionDate { get; set; }
    }
}