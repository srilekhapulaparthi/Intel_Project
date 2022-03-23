using log4net;
using StockTrading.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace StockTrading.Data
{
    /// <summary>
    /// Class for Funds data
    /// </summary>
    public class RandomPriceGenerator
    {
        /// Logger Declaration and Initialization
        /// </summary>
        private ILog log = log4net.LogManager.GetLogger("File");

        /// <summary>
        /// Method to generate market prices
        /// </summary>
        public static void UpdateMarketPrice()
        {
            var stockData = new StockData();
            Random rand = new Random();
            try
            {
                var currentTime = Convert.ToDecimal(string.Format("{0:HH.mm}", DateTime.Now));
                if (currentTime >= Convert.ToDecimal(9.00) && currentTime <= Convert.ToDecimal(15.00))
                {
                    var lstStocks = stockData.FindStockDetails();
                    var count = lstStocks.Count()+1000;
                    var lstRandomStocks = lstStocks.AsEnumerable()
                                                    .Select(x => new
                                                    {
                                                        rank = rand.Next(1, count),
                                                        x.StockId,
                                                        x.CompanyName,
                                                        x.StockTicker,
                                                        x.Volume,
                                                        x.InitialPrice,
                                                        x.MarketPrice,
                                                        x.OpenPrice,
                                                        x.TodayLow,
                                                        x.TodayHigh
                                                    }).OrderBy(x => x.rank).ToList();

                    DataTable dt = new DataTable();
                    dt.Columns.AddRange(new DataColumn[4] {
                    new DataColumn("StockId", typeof(int)),
                    new DataColumn("MarketPrice", typeof(string)),
                    new DataColumn("TodayLow",typeof(string)),
                    new DataColumn("TodayHigh", typeof(string)) });
                    //var stocksList = lstRandomStocks.TakeWhile(x => x.rank % 2 == 0);
                    foreach (var item in lstRandomStocks)
                    {
                        int value = rand.Next(-50, 50);
                        int id = item.StockId;
                        string marketPrice = Convert.ToString(Convert.ToDecimal(item.MarketPrice) + Convert.ToDecimal(value));
                        string todayLow = Convert.ToDecimal(item.TodayLow) < Convert.ToDecimal(marketPrice) ? item.TodayLow : marketPrice;
                        string todayHigh = Convert.ToDecimal(marketPrice) > Convert.ToDecimal(item.TodayHigh) ? marketPrice : item.TodayHigh;
                        if (Convert.ToDecimal(marketPrice) > 0)
                        {
                            dt.Rows.Add(id, marketPrice, todayLow, todayHigh);
                        }
                    }

                    if (dt.Rows.Count > 0)
                    {
                        using (SqlConnection con = new SqlConnection(SqlHelper.Connect()))
                        {
                            using (SqlCommand cmd = new SqlCommand(ProceduresData.UpdateMarketPrice))
                            {
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Connection = con;
                                cmd.Parameters.AddWithValue("@tblPrices", dt);
                                con.Open();
                                cmd.ExecuteNonQuery();
                                con.Close();
                            }
                        }
                    }
                }
                else if (currentTime >= Convert.ToDecimal(15.00) && currentTime <= Convert.ToDecimal(15.10))
                {
                    stockData.UpdateOpenPrice();
                }
            }
            catch (Exception ex)
            {

            }
        }

    }
}