using StockTrading.Data;
using System;
using System.Timers;

namespace StockTrading
{
    public class Global : System.Web.HttpApplication
    {
        private static Timer timer;
        protected void Application_Start(object sender, EventArgs e)
        {
            timer = new System.Timers.Timer(10000);
            timer.Elapsed += new System.Timers.ElapsedEventHandler(timer_Elapsed);
            timer.Enabled = true;
            timer.Start();
        }

        private void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            RandomPriceGenerator.UpdateMarketPrice();            
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {
            timer.Dispose();
        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}