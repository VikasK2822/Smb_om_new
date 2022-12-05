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
    public class ProductReasonCodeRepository : IProductReasonCode
    {
        public string conn { get; set; }
        public IConfiguration Configuration { get; }
        public ProductReasonCodeRepository(IConfiguration configuration)
        {

            Configuration = configuration;
            conn = Configuration.GetConnectionString("DataContext");

        }
        
        public ProductReasonCode GetProductReasonCode()
        {
            ProductReasonCode productReasonCode = new ProductReasonCode();
            List<stateName> stateNames = new List<stateName>();
            try
            {
                SqlCommand cmd = new SqlCommand("Usp_GetStateName");
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
                        stateName stateName = new stateName();
                        stateName.statename = Convert.ToString(dr["StateName"]);
                        stateNames.Add(stateName);
                    }
                    productReasonCode.stateNames = stateNames;
                }

            }
            catch (Exception ex)
            {

                throw;
            }
            
            //try
            //{
            //    SqlCommand cmd = new SqlCommand("usp_GetAffiliate");
            //    SqlConnection con = new SqlConnection(conn);
            //    SqlDataAdapter sda = new SqlDataAdapter(cmd);
            //    cmd.CommandType = CommandType.StoredProcedure;
            //    cmd.Connection = con;
            //    DataSet ds = new DataSet();
            //    sda.Fill(ds);

            //    if (ds.Tables[0].Rows.Count > 0)
            //    {
            //        List<Affiliate> lstaffiliate = new List<Affiliate>();
            //        foreach (DataRow dr in ds.Tables[0].Rows)
            //        {
            //            Affiliate affiliate = new Affiliate();
            //            affiliate.Affiliate_Name = Convert.ToString(dr["Affiliate_Name"]);
            //            affiliate.AffiliateId = Convert.ToString(dr["AffiliateId"]);
            //            lstaffiliate.Add(affiliate);
            //        }
            //        partnerModel.affiliates = lstaffiliate;
            //    }

            //}
            //catch (Exception)
            //{

            //    throw;
            //}
            return productReasonCode;

        }
        public ProductReasonCode GetProductReasonCodeforState(string stateName)
        {
            ProductReasonCode productReasonCode = new ProductReasonCode();
            List<ReasonCodeName> ReasonCodeName = new List<ReasonCodeName>();
            try
            {
                SqlCommand cmd = new SqlCommand("Usp_GetReasonCodestate");
                SqlConnection con = new SqlConnection(conn);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@StateName", stateName);
                cmd.Connection = con;
                DataSet ds = new DataSet();
                sda.Fill(ds);

                if (ds.Tables[0].Rows.Count > 0)
                {

                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        ReasonCodeName ReasonCode = new ReasonCodeName();
                        ReasonCode.ReasonCode = Convert.ToString(dr["ReasonCode"]);
                        ReasonCode.RowId = Convert.ToInt32(dr["Row_ID"]);
                        ReasonCode.statetId = Convert.ToInt32(dr["StateId"]);
                        ReasonCode.FG_Flag = Convert.ToInt32(dr["FG_Flag"]);
                        if (ReasonCode.FG_Flag == 1)
                        {
                            ReasonCode.ISchecked = "checked";
                        }
                        else
                            ReasonCode.ISchecked = "";
                        ReasonCodeName.Add(ReasonCode);
                    }
                    productReasonCode.reasonCodeNames = ReasonCodeName;
                }

            }
            catch (Exception ex)
            {

                throw;
            }
            return productReasonCode;

        }

        public int UpdateReasonCode(int RowID, int Isactive)
        {

            List<UnassignedOrder> lstunassignedOrder = new List<UnassignedOrder>();
            int iresult = default(int);
            try
            {
                SqlCommand cmd = new SqlCommand("Usp_UpdateReasonCodestate");
                SqlConnection con = new SqlConnection(conn);
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@IsActive", Isactive);
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
