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
    public class QueueRepository : IQueueSummary
    {
        public string conn { get; set; }
        public IConfiguration Configuration { get; }
        public QueueRepository(IConfiguration configuration)
        {

            Configuration = configuration;
            conn = Configuration.GetConnectionString("DataContext");

        }

        public QueueSummary GetQueueSummary()
        {
            QueueSummary queueSummary = new QueueSummary();
            Check_Install_3_Day check_Install_3_Day = new Check_Install_3_Day();
            Incomplete Incomplete = new Incomplete();
            Check_Install_2_Day check_Install_2_Day = new Check_Install_2_Day();
            Check_Install_1_Day check_Install_1_Day = new Check_Install_1_Day();
            Check_Install_Day check_Install_Day = new Check_Install_Day();
            Post_Install_Day post_Install_Day = new Post_Install_Day();
            MLP mLP = new MLP();

            try
            {
                SqlCommand cmd = new SqlCommand("USP_GET_CHECK_INSTALL_INCOMPLTEL_QueueSummary");
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
                      
                        var v = Convert.ToString(dr["QueueType"]);
                        if(v.ToLower() == "MLP".ToLower())
                        {
                            mLP.Queuetype = Convert.ToString(dr["QueueType"]); 
                            mLP.ordercount = Convert.ToString(dr["OrderCount"]);
                            mLP.MinimumDays = Convert.ToString(dr["MinmumDays"]);

                        }
                        if (v.ToLower() == "INCOMPLETE".ToLower())
                        {
                            Incomplete.Queuetype = Convert.ToString(dr["QueueType"]);
                            Incomplete.ordercount = Convert.ToString(dr["OrderCount"]);
                            Incomplete.MinimumDays = Convert.ToString(dr["MinmumDays"]);

                        }
                        if (v.ToLower() == "Check Install 3 Day".ToLower())
                        {
                            check_Install_3_Day.Queuetype = Convert.ToString(dr["QueueType"]);
                            check_Install_3_Day.ordercount = Convert.ToString(dr["OrderCount"]);
                            check_Install_3_Day.MinimumDays = Convert.ToString(dr["MinmumDays"]);
                        }
                        if (v.ToLower() == "Check Install 2 Day".ToLower())
                        {
                            check_Install_2_Day.Queuetype = Convert.ToString(dr["QueueType"]);
                            check_Install_2_Day.ordercount = Convert.ToString(dr["OrderCount"]);
                            check_Install_2_Day.MinimumDays = Convert.ToString(dr["MinmumDays"]);
                        }
                        if (v.ToLower() == "Check Install 1 Day".ToLower())
                        {
                            check_Install_1_Day.Queuetype = Convert.ToString(dr["QueueType"]);
                            check_Install_1_Day.ordercount = Convert.ToString(dr["OrderCount"]);
                            check_Install_1_Day.MinimumDays = Convert.ToString(dr["MinmumDays"]);
                        }
                        if (v.ToLower() == "Check Install  Day".ToLower())
                        {
                            check_Install_Day.Queuetype = Convert.ToString(dr["QueueType"]);
                            check_Install_Day.ordercount = Convert.ToString(dr["OrderCount"]);
                            check_Install_Day.MinimumDays = Convert.ToString(dr["MinmumDays"]);
                        }
                        if (v.ToLower() == "Post Install Day".ToLower())
                        {
                            post_Install_Day.Queuetype = Convert.ToString(dr["QueueType"]);
                            post_Install_Day.ordercount = Convert.ToString(dr["OrderCount"]);
                            post_Install_Day.MinimumDays = Convert.ToString(dr["MinmumDays"]);

                        }
                       
                        
                    }

                }
                queueSummary.check_Install_1_Day = check_Install_1_Day;
                queueSummary.MLP = mLP;
                queueSummary.check_Install_2_Day = check_Install_2_Day;
                queueSummary.check_Install_3_Day = check_Install_3_Day;
                queueSummary.Incomplete = Incomplete;
                queueSummary.check_Install_Day = check_Install_Day;
                queueSummary.post_Install_Day = post_Install_Day;

            }
            catch (Exception)
            {

                throw;
            }
            return queueSummary;

        }
    }
}
