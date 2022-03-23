using log4net;
using StockTrading.Helpers;
using StockTrading.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace StockTrading.Data
{
    /// <summary>
    /// Class for Holidays data
    /// </summary>
    public class HolidaysData
    {
        /// <summary>
        /// Logger Declaration
        /// </summary>
        private readonly ILog log;

        /// <summary>
        /// Initializes a new instance of the <see cref="HolidaysData" /> class
        /// </summary>
        public HolidaysData()
        {
            this.log = log4net.LogManager.GetLogger("File");
        }

        /// <summary>
        /// Method to Get Holidays list
        /// </summary>
        /// <returns>Returns holidays list</returns>
        public List<HolidaysBO> FindHolidaysList()
        {
            DataSet ObjDataSet = new DataSet();
            List<HolidaysBO> lstHolidaysList = new List<HolidaysBO>();
            try
            {

                ObjDataSet = SqlHelper.ExecuteDataset(SqlHelper.Connect(), CommandType.Text, ProceduresData.GetAllHolidays);
                if (ObjDataSet.Tables.Count > 0 && ObjDataSet.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow item in ObjDataSet.Tables[0].Rows)
                    {
                        HolidaysBO holidaysBO = new HolidaysBO();
                        holidaysBO.Id = Convert.ToInt32(item["Id"]);
                        holidaysBO.Holiday = Convert.ToString(item["Holiday"]);
                        holidaysBO.Date = Convert.ToDateTime(item["Date"]);
                        lstHolidaysList.Add(holidaysBO);
                    }
                }
            }
            catch (Exception ex)
            {
                this.log.Fatal(this.GetType().Name + " - " + System.Reflection.MethodBase.GetCurrentMethod().Name + " - Exception - ", ex);
            }
            return lstHolidaysList;
        }
    }
}