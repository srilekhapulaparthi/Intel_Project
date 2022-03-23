using StockTrading.Data;
using StockTrading.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StockTrading.Service
{
    /// <summary>
    /// Class for Holidays service
    /// </summary>
    public class HolidaysService
    {
        /// <summary>
        /// User Details Data
        /// </summary>
        private readonly HolidaysData holidaysData;

        /// <summary>
        /// Initializes a new instance of the <see cref="HolidaysService" /> class
        /// </summary>
        public HolidaysService()
        {
            this.holidaysData = new HolidaysData();
        }

        /// <summary>
        /// Method to Get Holidays list
        /// </summary>
        /// <returns>Returns holidays list</returns>
        public List<HolidaysBO> GetHolidaysList()
        {
            return this.holidaysData.FindHolidaysList();
        }
    }
}