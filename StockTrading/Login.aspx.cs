using log4net;
using StockTrading.Service;
using System;
using System.Web.Security;

namespace StockTrading
{
    public partial class Login : System.Web.UI.Page
    {
        /// Logger Declaration and Initialization
        /// </summary>
        private ILog log = log4net.LogManager.GetLogger("File");

        /// <summary>
        /// User Details Data
        /// </summary>
        private readonly UserService userService = new UserService();

        /// <summary>
        /// Page load event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtEmail.Text.Trim() != "" && txtPassword.Text.Trim() != "")
                {
                    var userData = userService.GetUserDetailsByUserNameAndPassword(txtEmail.Text, txtPassword.Text);
                    if (!string.IsNullOrEmpty(userData.Email))
                    {
                        Session["userInfo"] = userData;
                        FormsAuthentication.RedirectFromLoginPage(txtEmail.Text.Trim(), false);
                        if (userData.RoleId == 1)
                        {
                            Response.Redirect("~/Admin/Stocks.aspx", true);
                        }

                        Response.Redirect("~/Stocks.aspx", true);
                    }
                    else
                    {
                        lblErrorMessage.Text = "Invalid Username / Password";
                        lblErrorMessage.Visible = true;
                        return;
                    }
                }
                else
                {
                    lblErrorMessage.Text = "Please enter Username and Password";
                    lblErrorMessage.Visible = true;
                    return;
                }
            }
            catch (Exception ex)
            {
                this.log.Fatal(this.GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name + " - Exception - ", ex);
            }
        }
    }
}