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
    public class ReasonCodeRepository : IReasonCode
    {
        public string conn { get; set; }
        public IConfiguration Configuration { get; }
        public ReasonCodeRepository(IConfiguration configuration)
        {

            Configuration = configuration;
            conn = Configuration.GetConnectionString("DataContext");

        }

        public MasterReasonCode GetReasonCode()
        {
            MasterReasonCode masterReasonCode = new MasterReasonCode();
            List<ReasonCodeResult> lstreasoncode = new List<ReasonCodeResult>();
            try
            {
                SqlCommand cmd = new SqlCommand("Usp_GetReasonCode");
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
                        ReasonCodeResult reasonCodeResult = new ReasonCodeResult();
                        reasonCodeResult.ReasonCode = Convert.ToString(dr["ReasonCode"]); ;
                        reasonCodeResult.ReasonCodeName = Convert.ToString(dr["ReasonCodeName"]);
                        reasonCodeResult.Row_ID = Convert.ToInt32(dr["Row_ID"]);
                        lstreasoncode.Add(reasonCodeResult);
                    }
                }
                masterReasonCode.reasonCodeResults = lstreasoncode;
            }
            catch (Exception ex)
            {

                throw;
            }

            return masterReasonCode;
        }

        public int UpdateReasonCode(string RowID, string ReasonCode)
        {
            int iresult = default(int);
            try
            {
                SqlCommand cmd = new SqlCommand("Usp_UpdateReasonCode");
                SqlConnection con = new SqlConnection(conn);
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@ReasonCode", ReasonCode);
                cmd.Parameters.AddWithValue("@RowID", RowID);
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
