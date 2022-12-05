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
    public class BrvRepository : IBrv
    {

        public string conn { get; set; }
        public IConfiguration Configuration { get; }
        public BrvRepository(IConfiguration configuration)
        {

            Configuration = configuration;
            conn = Configuration.GetConnectionString("DataContext");

        }

        public BrvModel GetBrvsuppress()
        {
            BrvModel BrvModel = new BrvModel();
            List<BrvModelResult> lstbrvresult = new List<BrvModelResult>();
            try
            {
                SqlCommand cmd = new SqlCommand("Usp_GetAffiliateBrv");
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
                        BrvModelResult brvresult = new BrvModelResult();
                        brvresult.Affiliate = Convert.ToString(dr["Affiliate"]); ;
                        brvresult.BrvSuppress = Convert.ToString(dr["BrvSuppress"]);
                        brvresult.RowID = Convert.ToInt32(dr["RowID"]);
                        lstbrvresult.Add(brvresult);
                    }
                }
                BrvModel.brvModelResults = lstbrvresult;


            }
            catch (Exception ex)
            {

                throw;
            }

            return BrvModel;
        }

        public int UpdateBrvAffiliate(int RowID, string AffiliateBrv)
        {

            List<UnassignedOrder> lstunassignedOrder = new List<UnassignedOrder>();
            int iresult = default(int);
            try
            {
                SqlCommand cmd = new SqlCommand("Usp_updateAffiliateBrv");
                SqlConnection con = new SqlConnection(conn);
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@RowID", RowID);
                cmd.Parameters.AddWithValue("@AffiliateBrv", AffiliateBrv);
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
