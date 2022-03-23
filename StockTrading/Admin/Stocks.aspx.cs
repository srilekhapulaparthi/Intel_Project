using log4net;
using StockTrading.Models;
using StockTrading.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StockTrading.Admin
{
    public partial class Stocks : System.Web.UI.Page
    {
        /// Logger Declaration and Initialization
        /// </summary>
        private ILog log = log4net.LogManager.GetLogger("File");

        /// <summary>
        /// User Details Service
        /// </summary>
        private readonly StockService stockService = new StockService();

        /// <summary>
        /// Page load event
        /// </summary>
        /// <param name="sender">Sender object</param>
        /// <param name="e">Event args</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            BindStockDetails();
        }

        /// <summary>
        /// Method to bind the existing stock information
        /// </summary>
        private void BindStockDetails()
        {
            var stockDetails = this.stockService.GetAllStockDetails();
            gvStocks.DataSource = stockDetails;
            gvStocks.DataBind();
        }

        /// <summary>
        /// Add stock button click event to add the stocks
        /// </summary>
        /// <param name="sender">sender object</param>
        /// <param name="e">event args</param>
        protected void btnAddStock_Click(object sender, EventArgs e)
        {
            var stockDetails = new StockBO()
            {
                CompanyName = txtCompanyName.Text.Trim(),
                StockTicker = txtStockTicker.Text.Trim(),
                Volume = txtVolume.Text.Trim(),
                InitialPrice = txtInitialPrice.Text.Trim()
            };
            var result = this.stockService.SaveStockDetails(stockDetails);
            switch (result)
            {
                case -1:
                    lblErrorMessage.Text = "Stock already exists with the given details.";
                    lblErrorMessage.Attributes["Style"] = "color: red";
                    break;
                case 0:
                    lblErrorMessage.Text = "Something went wrong. Please try after sometime.";
                    lblErrorMessage.Attributes["Style"] = "color: red";
                    break;
                default:
                    lblErrorMessage.Text = "Stock added successfully";
                    lblErrorMessage.Attributes["Style"] = "color: green";
                    break;
            }
            lblErrorMessage.Visible = true;
            ClearFields();
            BindStockDetails();
            Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "OpenModal()", true);
        }

        /// <summary>
        /// Method to clear all the fields
        /// </summary>
        private void ClearFields()
        {
            txtCompanyName.Text = "";
            txtStockTicker.Text = "";
            txtVolume.Text = "";
            txtInitialPrice.Text = "";
        }
    }
}