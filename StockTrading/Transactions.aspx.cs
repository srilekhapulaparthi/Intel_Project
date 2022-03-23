using log4net;
using StockTrading.Models;
using StockTrading.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StockTrading
{
    public partial class Transactions : System.Web.UI.Page
    {
        /// Logger Declaration and Initialization
        /// </summary>
        private ILog log = log4net.LogManager.GetLogger("File");

        /// <summary>
        /// Holding Details Service
        /// </summary>
        private readonly HoldingsService holdingsService = new HoldingsService();

        /// <summary>
        /// Get or set the user id
        /// </summary>
        private int UserId = 0;

        /// <summary>
        /// Page load event
        /// </summary>
        /// <param name="sender">Sender object</param>
        /// <param name="e">Event args</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userInfo"] != null)
            {
                var userDetails = (UserBO)Session["userInfo"];
                UserId = userDetails.UserId;
            }
            else
            {
                Response.Redirect("~/Login.aspx", true);
            }
            if (!Page.IsPostBack)
            {
                BindTransactionDetails();
            }
        }

        /// <summary>
        /// Method to bind the existing holding information
        /// </summary>
        private void BindTransactionDetails()
        {
            var holdingDetails = this.holdingsService.GetHoldingDetails(UserId);
            gvTransactions.DataSource = holdingDetails;
            gvTransactions.DataBind();
        }
    }
}