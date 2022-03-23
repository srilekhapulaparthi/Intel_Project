using StockTrading.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StockTrading
{
    public partial class Main : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userInfo"] != null)
            {
                var userDetails = (UserBO)Session["userInfo"];
                lblUserName.Text = string.Format("{0} {1}", userDetails.FirstName, userDetails.LastName ?? userDetails.LastName);
                lblAvailablAmount.Text = Convert.ToString(userDetails.AvailableCash);
            }
            else
            {
                Response.Redirect("~/Login.aspx");
            }

        }

        protected void lnkSignOut_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Session.Remove("userInfo");
            Response.Redirect("~/Login.aspx");
        }
    }
}