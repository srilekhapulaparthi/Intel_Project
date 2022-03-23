using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StockTrading.Models
{
    /// <summary>
    /// Class for Holidays BO
    /// </summary>
    public class HolidaysBO
    {

        /// <summary>
        /// Gets or sets Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Ges or sets Holiday
        /// </summary>
        public string Holiday { get; set; }

        /// <summary>
        /// Ges or sets date
        /// </summary>
        public DateTime Date { get; set; }

    }
}