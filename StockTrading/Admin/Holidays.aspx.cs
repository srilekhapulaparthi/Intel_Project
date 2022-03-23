using log4net;
using StockTrading.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StockTrading.Admin
{
    public partial class Holidays : System.Web.UI.Page
    {
        /// Logger Declaration and Initialization
        /// </summary>
        private ILog log = log4net.LogManager.GetLogger("File");

        /// <summary>
        /// Holidays Details Service
        /// </summary>
        private readonly HolidaysService holidaysService = new HolidaysService();

        /// <summary>
        /// Page load event
        /// </summary>
        /// <param name="sender">Sender object</param>
        /// <param name="e">Event args</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            BindHolidaysDetails();
        }

        /// <summary>
        /// Method to get holidays list
        /// </summary>
        private void BindHolidaysDetails()
        {
            var holidayDetails = this.holidaysService.GetHolidaysList();
            gvHolidays.DataSource = holidayDetails;
            gvHolidays.DataBind();
        }
    }
}