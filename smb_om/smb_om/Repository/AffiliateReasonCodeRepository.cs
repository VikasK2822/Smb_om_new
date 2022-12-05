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
    public class AffiliateReasonCodeRepository : IAffiliateReasonCode
    {
        public string conn { get; set; }
        public IConfiguration Configuration { get; }
        public AffiliateReasonCodeRepository(IConfiguration configuration)
        {

            Configuration = configuration;
            conn = Configuration.GetConnectionString("DataContext");

        }

        public List<AffiliateReasonCode> GetAffiliateReasonCode()
        {
            List<AffiliateReasonCode> lstAffiliareasoncode = new List<AffiliateReasonCode>();
            try
            {
                SqlCommand cmd = new SqlCommand("Get_AffiliateReasonCode");
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
                        AffiliateReasonCode Affiliareasoncode = new AffiliateReasonCode();
                        Affiliareasoncode.RowID = Convert.ToInt32(dr["RowID"]);
                        Affiliareasoncode.AffiliateName = Convert.ToString(dr["AffiliateName"]);
                        Affiliareasoncode.Canceled = Convert.ToBoolean(dr["Canceled"]);
                        Affiliareasoncode.Incomplete = Convert.ToBoolean(dr["Incomplete"]);
                        Affiliareasoncode.Submitted = Convert.ToBoolean(dr["Submitted"]);
                        Affiliareasoncode.Pending = Convert.ToBoolean(dr["Pending"]);

                        lstAffiliareasoncode.Add(Affiliareasoncode);
                    }
                }

            }
            catch (Exception)
            {

                throw;
            }
            return lstAffiliareasoncode;
        }
        public int UpdateAffiliateReasoncode(string affiliatename, int cancelled, int pending, int submitted, int incomplete)
        {
            int iresult = default(int);
            try
            {
                SqlCommand cmd = new SqlCommand("Usp_UpdateAffiliate");
                SqlConnection con = new SqlConnection(conn);
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@affiliateName", affiliatename);
                cmd.Parameters.AddWithValue("@Canceled", cancelled);
                cmd.Parameters.AddWithValue("@Incomplete", incomplete);
                cmd.Parameters.AddWithValue("@Pending", pending);
                cmd.Parameters.AddWithValue("@Submitted", submitted);
                iresult = cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

                throw;
            }

            return iresult;
        }
        public AffiliateReasonCode CheckAffiliateReasonCode(string affiliatename)
        {
            AffiliateReasonCode Affiliareasoncode = new AffiliateReasonCode();
            try
            {
                SqlCommand cmd = new SqlCommand("Usp_CheckAffiliateReasonCode");
                SqlConnection con = new SqlConnection(conn);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                cmd.Parameters.AddWithValue("@AffiliateName", affiliatename);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                DataSet ds = new DataSet();
                sda.Fill(ds);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                      
                        Affiliareasoncode.RowID = Convert.ToInt32(dr["RowID"]);
                        Affiliareasoncode.AffiliateName = Convert.ToString(dr["AffiliateName"]);
                        Affiliareasoncode.Canceled = Convert.ToBoolean(dr["Canceled"]);
                        Affiliareasoncode.Incomplete = Convert.ToBoolean(dr["Incomplete"]);
                        Affiliareasoncode.Submitted = Convert.ToBoolean(dr["Submitted"]);
                        Affiliareasoncode.Pending = Convert.ToBoolean(dr["Pending"]);

                       
                    }
                }

            }
            catch (Exception)
            {

                throw;
            }
            return Affiliareasoncode;
        }

        
    }
}
