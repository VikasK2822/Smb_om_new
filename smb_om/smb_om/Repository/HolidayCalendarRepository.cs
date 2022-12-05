using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using smb_om.Infrastructure;
using smb_om.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace smb_om.Repository
{
    public class HolidayCalendarRepository : IHolidayCalendar
    {

        public string conn { get; set; }
        public IConfiguration Configuration { get; }
        public HolidayCalendarRepository(IConfiguration configuration)
        {

            Configuration = configuration;
            conn = Configuration.GetConnectionString("DataContext");

        }
        public HolidayCalendarModel GetHolidayDetails()
        {
            HolidayCalendarModel holidayCalendarModel = new HolidayCalendarModel();
            List<HolidayCalendarResult> lstholidayCalendarResults = new List<HolidayCalendarResult>();
            try
            {
                SqlCommand cmd = new SqlCommand("usp_Getholiday");
                SqlConnection con = new SqlConnection(conn);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                DataSet ds = new DataSet();
                sda.Fill(ds);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        HolidayCalendarResult holidayCalendarResult = new HolidayCalendarResult();
                        holidayCalendarResult.HolidayName = Convert.ToString(dr["HolidayName"]); ;
                        holidayCalendarResult.HolidayDate = Convert.ToString(dr["HolidayDate"]);
                        holidayCalendarResult.RowID = Convert.ToInt32(dr["RowID"]);
                        lstholidayCalendarResults.Add(holidayCalendarResult);
                    }
                }
                holidayCalendarModel.holidayCalendarResults = lstholidayCalendarResults;


            }
            catch (Exception ex)
            {

                throw;
            }

            return holidayCalendarModel;
        }

        public int UpdateHolidayMaster(int RowID, string HolidayName, string HolidayDate,int Isdeleted, int Isupdated)
        {

            List<UnassignedOrder> lstunassignedOrder = new List<UnassignedOrder>();
            int iresult = default(int);
            try
            {
                SqlCommand cmd = new SqlCommand("usp_Updateholiday");
                SqlConnection con = new SqlConnection(conn);
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@RowID", RowID);
                cmd.Parameters.AddWithValue("@holidayName", HolidayName);
                cmd.Parameters.AddWithValue("@HolidayDate", HolidayDate);
                if(Isdeleted == 1)
                cmd.Parameters.AddWithValue("@Delete", Isdeleted);
                else
                    cmd.Parameters.AddWithValue("@Delete", 0);
                if(Isupdated == 1)
                    cmd.Parameters.AddWithValue("@Update", Isupdated);
                else
                    cmd.Parameters.AddWithValue("@Update", 0);
                iresult = cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

                throw;
            }

            return iresult;
        }

        public int InsertHolidayMaster(string HolidayName, string HolidayDate)
        {

            List<UnassignedOrder> lstunassignedOrder = new List<UnassignedOrder>();
            int iresult = default(int);
            try
            {
                SqlCommand cmd = new SqlCommand("Usp_Insertholiday_master");
                SqlConnection con = new SqlConnection(conn);
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@HolidayName", HolidayName);
                cmd.Parameters.AddWithValue("@HolidayDate", HolidayDate);
                iresult = cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

                throw;
            }

            return iresult;
        }

    }
}
