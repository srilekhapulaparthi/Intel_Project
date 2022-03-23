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
    public partial class Holdings : System.Web.UI.Page
    {
        /// Logger Declaration and Initialization
        /// </summary>
        private ILog log = log4net.LogManager.GetLogger("File");

        /// <summary>
        /// Holding Details Service
        /// </summary>
        private readonly HoldingsService holdingsService = new HoldingsService();

        /// <summary>
        /// Stock Details Service
        /// </summary>
        private readonly StockService stockService = new StockService();

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
                BindHoldingDetails();
            }
        }

        /// <summary>
        /// Method to bind the existing holding information
        /// </summary>
        private void BindHoldingDetails()
        {
            var holdingDetails = this.holdingsService.GetHoldingDetails(UserId).Where(x => !x.IsSold).ToList();
            gvHoldings.DataSource = holdingDetails;
            gvHoldings.DataBind();
        }

        /// <summary>
        /// Method to refresh the grid on timely basis
        /// </summary>
        /// <param name="sender">Sender object</param>
        /// <param name="e">Event args</param>
        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            BindHoldingDetails();
        }

        /// <summary>
        /// Button click event to buy or sell shares
        /// </summary>
        /// <param name="sender">Sender object</param>
        /// <param name="e">Event args</param>
        protected void btnBuySell_Click(object sender, EventArgs e)
        {
            int result = 0;
            UserStockBO userStockBO = new UserStockBO();
            try
            {
                userStockBO.Id = Convert.ToInt32(hdnHoldingId.Value); 
                userStockBO.StockId = Convert.ToInt32(hdnStockId.Value);
                userStockBO.UserId = UserId;
                userStockBO.Type = Convert.ToInt32(hdnType.Value);
                userStockBO.Quantity = Convert.ToInt32(hdnQuantity.Value.Trim());
                userStockBO.SellingPrice = Convert.ToString(hdnPrice.Value.Trim());
                userStockBO.SellingAmount = Convert.ToString(userStockBO.Quantity * Convert.ToDecimal(userStockBO.SellingPrice));
                result = this.stockService.SaveUserStockDetails(userStockBO);
            }
            catch (Exception ex)
            {
                this.log.Fatal(this.GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name + " - Exception - ", ex);
            }
            switch (result)
            {
                case -1:
                    //Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "OpenModal()", true);
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "<script>alert('Insufficient available cash');</script>", false);
                    break;
                case 0:
                    lblErrorMessage.Text = "Something went wrong. Please try after sometime.";
                    lblErrorMessage.Attributes["Style"] = "color: red";
                    break;
                default:
                    lblErrorMessage.Text = string.Format("Shares {0} successfully", userStockBO.Type == 3 ? "Bought" : "Sold");
                    lblErrorMessage.Attributes["Style"] = "color: green";
                    UpdateAvailableCash(userStockBO);
                    break;
            }
            lblErrorMessage.Visible = true;
            ClearFields();
            BindHoldingDetails();
        }

        /// <summary>
        /// Method to clear all the fields
        /// </summary>
        private void ClearFields()
        {
            hdnQuantity.Value = "";
            hdnHoldingId.Value = "";
            hdnType.Value = "";
            hdnStockId.Value = "";
            txtQuantity.Text = "";
            txtPrice.Text = "";
        }

        /// <summary>
        /// Updating the available cash
        /// </summary>
        /// <param name="userStockBO">User Stock details</param>
        private void UpdateAvailableCash(UserStockBO userStockBO)
        {
            decimal availableCash = 0;
            if (Session["userInfo"] != null)
            {
                var userDetails = (UserBO)Session["userInfo"];
                availableCash =  userDetails.AvailableCash + Convert.ToDecimal(userStockBO.SellingAmount);
                userDetails.AvailableCash = availableCash;
                Session["userInfo"] = userDetails;
            }
            Label lblMasterAvaiableCash = (Label)Master.FindControl("lblAvailablAmount");
            lblMasterAvaiableCash.Text = Convert.ToString(availableCash);
        }
    }
}