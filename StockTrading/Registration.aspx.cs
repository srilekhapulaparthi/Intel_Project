using log4net;
using StockTrading.Models;
using StockTrading.Service;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StockTrading
{
    public partial class Registration : System.Web.UI.Page
    {
        /// Logger Declaration and Initialization
        /// </summary>
        private ILog log = log4net.LogManager.GetLogger("File");

        /// <summary>
        /// User Details Data
        /// </summary>
        private readonly UserService userService = new UserService();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSignUp_Click(object sender, EventArgs e)
        {
            try
            {
                UserBO userBO = new UserBO
                {
                    RoleId = 2,
                    FirstName = txtFirstName.Text.Trim(),
                    LastName = txtLastName.Text.Trim(),
                    Email = txtEmail.Text.Trim(),
                    MobileNo = txtMobile.Text.Trim()
                };
                var result = this.userService.SaveUserDetails(userBO);
                switch (result)
                {
                    case -1:
                        lblErrorMessage.Text = "User already exists with the given details.";
                        lblErrorMessage.Attributes["Style"] = "color: red";
                        break;
                    case 0:
                        lblErrorMessage.Text = "Something went wrong. Please try after sometime.";
                        lblErrorMessage.Attributes["Style"] = "color: red";
                        break;
                    default:
                        lblErrorMessage.Text = "User created successfully. Password is sent to mail";
                        lblErrorMessage.Attributes["Style"] = "color: green";
                        SendMailToUser(result, userBO);
                        break;
                }
                lblErrorMessage.Visible = true;
                ClearFields();
            }
            catch (Exception ex)
            {
                this.log.Fatal(this.GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name + " - Exception - ", ex);
            }
        }

        /// <summary>
        /// Method to clear all the fields
        /// </summary>
        private void ClearFields()
        {
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtEmail.Text = "";
            //txtPassword.Text = "";
            txtMobile.Text = "";
        }

        /// <summary>
        /// Method to send mail functionality to user
        /// </summary>
        /// <param name="userId">User Id</param>
        /// <param name="userBO">User details</param>
        private void SendMailToUser(int userId, UserBO userBO)
        {
            try
            {
                string mailTemplate = "<html xmlns='http://www.w3.org/1999/xhtml'><head><title></title></head><body>" +
                        "<span style='font-family: Arial; font-size: 10pt'>Hello <b>{0}</b>,<br /><br />Following are the user details.<br /><br />" +
                        "<div>User name : {1} </div><br /><div>Password : {2} </div><br /><br />" +
                        "<br />Thanks<br />Stock Trading Team </span></body></html>";
                var password = GetRandomPassword();
                string mailBody = string.Format(mailTemplate, userBO.FirstName, userBO.Email, password);
                using (MailMessage mailMessage = new MailMessage())
                {
                    mailMessage.From = new MailAddress(ConfigurationManager.AppSettings["UserName"]);
                    mailMessage.Subject = "User Credentials";
                    mailMessage.Body = mailBody;
                    mailMessage.IsBodyHtml = true;
                    mailMessage.To.Add(userBO.Email);

                    using (SmtpClient smtp = new SmtpClient(ConfigurationManager.AppSettings["Host"], int.Parse(ConfigurationManager.AppSettings["Port"])))
                    {
                        smtp.Credentials = new NetworkCredential(ConfigurationManager.AppSettings["UserName"], ConfigurationManager.AppSettings["Password"]);
                        smtp.EnableSsl = true;
                        smtp.UseDefaultCredentials = true;
                        smtp.Send(mailMessage);                        
                    }                   
                }

                UpdatePassword(userId, password);
            }
            catch (Exception ex)
            {
                this.log.Fatal(this.GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name + " - Exception - ", ex);
            }          
        }

        /// <summary>
        /// Method to update user password
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="password"></param>
        private void UpdatePassword(int userId, string password)
        {
            var result = this.userService.SaveUserPassword(userId, password);
        }

        /// <summary>
        /// Method to generate random password for the user
        /// </summary>
        /// <returns>Return password</returns>
        private string GetRandomPassword()
        {
            const string chars = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            StringBuilder sb = new StringBuilder();
            Random rnd = new Random();
            for (int i = 0; i < 6; i++)
            {
                int index = rnd.Next(chars.Length);
                sb.Append(chars[index]);
            }

            return sb.ToString();
        }
    }
}