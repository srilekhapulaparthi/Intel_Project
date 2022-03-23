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
    public partial class Funds : System.Web.UI.Page
    {
        /// <summary>
        /// Get or set the user id
        /// </summary>
        private int UserId = 0;

        /// Logger Declaration and Initialization
        /// </summary>
        private ILog log = log4net.LogManager.GetLogger("File");

        /// <summary>
        /// User Details Service
        /// </summary>
        private readonly FundsService fundsService = new FundsService();


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

            BindFundDetails();
        }

        /// <summary>
        /// Method to bind the existing stock information
        /// </summary>
        /// <param name="userId">User Id</param>
        private void BindFundDetails()
        {
            var fundsDetails = this.fundsService.GetFundsDetails(UserId);
            gvFunds.DataSource = fundsDetails;
            gvFunds.DataBind();
            if (fundsDetails.Count > 0)
            {
               // gvFunds.FooterRow.TableSection = TableRowSection.TableFooter;
                //Calculate Sum and display in Footer Row
                decimal total = fundsDetails.AsEnumerable().Sum(row => row.CreditAmount) - fundsDetails.AsEnumerable().Sum(row => row.DebitAmount);
                UpdateAvailableCash(total);
                gvFunds.FooterRow.Cells[2].Text = "Total";
                gvFunds.FooterRow.Cells[2].HorizontalAlign = HorizontalAlign.Right;
                gvFunds.FooterRow.Cells[3].CssClass = "text-end";
                gvFunds.FooterRow.Cells[3].Text = "$" + total.ToString("N2");
            }            
        }

        protected void btnAddOrWithDrawCash_Click(object sender, EventArgs e)
        {
            int result = 0;
            try
            {
                var fundDetails = new FundsBO()
                {
                    UserId = UserId,
                    FundType = Convert.ToInt32(rblDepositType.SelectedValue),
                    CreditAmount = Convert.ToInt32(rblDepositType.SelectedValue) == 1 ? Convert.ToDecimal(txtAmount.Text.Trim()) : 0,
                    DebitAmount = Convert.ToInt32(rblDepositType.SelectedValue) == 2 ? Convert.ToDecimal(txtAmount.Text.Trim()) : 0,
                    TransactionDate = DateTime.Now
                };
                result = this.fundsService.SaveFundDetails(fundDetails);
            }
            catch (Exception ex)
            {
                this.log.Fatal(this.GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name + " - Exception - ", ex);
            }
            switch (result)
            {
                case -1:
                    //Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "OpenModal()", true);
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "<script>alert('Cannot withdraw more than available cash');</script>", false);
                    break;
                case 0:
                    lblErrorMessage.Text = "Something went wrong. Please try after sometime.";
                    lblErrorMessage.Attributes["Style"] = "color: red";
                    break;
                default:
                    lblErrorMessage.Text = "Funds Added / Withdrawn successfully";
                    lblErrorMessage.Attributes["Style"] = "color: green";
                    break;
            }
            lblErrorMessage.Visible = true;
            ClearFields();
            BindFundDetails();           
        }

        /// <summary>
        /// Method to clear all the fields
        /// </summary>
        private void ClearFields()
        {
            rblDepositType.SelectedValue = "1";
            txtAmount.Text = "";
            lblErrorMessage.Visible = false;
        }

        /// <summary>
        /// Updating the available cash
        /// </summary>
        /// <param name="amount">Total amount</param>
        private void UpdateAvailableCash(decimal amount)
        {
            if (Session["userInfo"] != null)
            {
                var userDetails = (UserBO)Session["userInfo"];
                userDetails.AvailableCash = amount;
                Session["userInfo"] = userDetails;
            }
            Label lblMasterAvaiableCash = (Label)Master.FindControl("lblAvailablAmount");
            lblMasterAvaiableCash.Text = Convert.ToString(amount);
        }
    }
}