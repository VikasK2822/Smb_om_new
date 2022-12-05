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
    public class ViewlogRepository : Iviewlog
    {
        public string conn { get; set; }
        public IConfiguration Configuration { get; }
        public ViewlogRepository(IConfiguration configuration)
        {

            Configuration = configuration;
            conn = Configuration.GetConnectionString("DataContext");

        }

        public List<ViewLog> GetViewLog(string ordernumber)
        {
            List<ViewLog> lstviewLog  = new List<ViewLog>();
            List<OrderState> orderStates = new List<OrderState>();
            try
            {
                SqlCommand cmd = new SqlCommand("usp_GetLogs");
                cmd.Parameters.AddWithValue("@ordernumber", ordernumber);
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
                        ViewLog viewLog = new ViewLog();
                        viewLog.category = Convert.ToString(dr["Category"]);
                        viewLog.message = Convert.ToString(dr["Message"]);
                        viewLog.ordernumber = Convert.ToString(dr["Order_Number"]);
                        viewLog.date = Convert.ToString(dr["Crefate_Date"]);

                        lstviewLog.Add(viewLog);
                    }
                    
                }

            }
            catch (Exception)
            {

                throw;
            }
            return lstviewLog;

        }


    }


}
