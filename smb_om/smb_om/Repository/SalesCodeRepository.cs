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
    public class SalesCodeRepository : ISalesCode
    {
        public string conn { get; set; }
        public IConfiguration Configuration { get; }
        public SalesCodeRepository(IConfiguration configuration)
        {

            Configuration = configuration;
            conn = Configuration.GetConnectionString("DataContext");

        }

        public SalesCodeModel GetSalesCode()
        {
            SalesCodeModel salescodemodel = new SalesCodeModel();
            List<SalesCoderesult> lstSalesCoderesult = new List<SalesCoderesult>();
            List<SalesCodeAffiliate> lstSalesCodeaffiliate = new List<SalesCodeAffiliate>();
            try
            {
                SqlCommand cmd = new SqlCommand("Usp_SalesCode");
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
                        SalesCoderesult salesCoderesult = new SalesCoderesult();
                        salesCoderesult.Affiliate = Convert.ToString(dr["Affiliate"]); ;
                        salesCoderesult.Row_Id = Convert.ToInt32(dr["Row_Id"]);
                        salesCoderesult.SalesCode = Convert.ToString(dr["SalesCode"]);
                        salesCoderesult.Service_Type = Convert.ToString(dr["Service_Type"]);

                        lstSalesCoderesult.Add(salesCoderesult);
                    }
                }
                salescodemodel.salesCoderesults = lstSalesCoderesult;


            }
            catch (Exception ex)
            {

                throw;
            }
            try
            {
                SqlCommand cmd = new SqlCommand("usp_GetAffiliate");
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
                        SalesCodeAffiliate salesCodeaffiliate = new SalesCodeAffiliate();
                        salesCodeaffiliate.AffiliateName = Convert.ToString(dr["Affiliate_Name"]);
                        lstSalesCodeaffiliate.Add(salesCodeaffiliate);
                    }
                }
                salescodemodel.salesCodeAffiliates = lstSalesCodeaffiliate;


            }
            catch (Exception ex)
            {

                throw;
            }
            return salescodemodel;
        }

        public int UpdateSalesCode(int RowID, string salescode)
        {

            List<UnassignedOrder> lstunassignedOrder = new List<UnassignedOrder>();
            int iresult = default(int);
            try
            {
                SqlCommand cmd = new SqlCommand("Usp_updateSalesCode");
                SqlConnection con = new SqlConnection(conn);
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@RowID", RowID);
                cmd.Parameters.AddWithValue("@salescode", salescode);
                iresult = cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

                throw;
            }

            return iresult;
        }

        public int InsertSalesCode(string affiliateName, string service_type, string salescode)
        {
            int iresult = default(int);
            try
            {
                SqlCommand cmd = new SqlCommand("Usp_insertSalesCode");
                SqlConnection con = new SqlConnection(conn);
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@Affiliate", affiliateName);
                cmd.Parameters.AddWithValue("@Service_Type", service_type);
                cmd.Parameters.AddWithValue("@salesCode", salescode);
                
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
