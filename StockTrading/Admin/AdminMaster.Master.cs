using StockTrading.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StockTrading.Admin
{
    public partial class AdminMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userInfo"] != null)
            {
                var userDetails = (UserBO)Session["userInfo"];
                lblUserName.Text = string.Format("{0} {1}", userDetails.FirstName, userDetails.LastName ?? userDetails.LastName);
            }
            else
            {
                Response.Redirect("~/Login.aspx");
            }

        }

        /// <summary>
        /// Logout button click event to logout from the application
        /// </summary>
        /// <param name="sender">sender object</param>
        /// <param name="e">event args</param>
        protected void lnkSignOut_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Session.Remove("userInfo");
            Response.Redirect("~/Login.aspx");
        }
    }
}