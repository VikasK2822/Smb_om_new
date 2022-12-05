using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using smb_om.Data;
using smb_om.Infrastructure;
using smb_om.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace smb_om.Repository
{
    public class AffiliateRepository : IAffiliate
    {
        public string conn { get; set; }
        public IConfiguration Configuration { get; }
        public AffiliateRepository(IConfiguration configuration)
        {

            Configuration = configuration;
            conn = Configuration.GetConnectionString("DataContext");

        }


        //private readonly DataContext _context;

        //public AffiliateRepository(DataContext context)
        //{
        //    this._context = context;
        //}
        //public PartnerModel GetPartnerAffiliate()
        //{
        //    PartnerModel partnerModel = new PartnerModel();
        //    try
        //    {

             
        //        var IQueryableaffiliated = (from _user in _context.affiliate
        //                                    where _user.FG_Flag == true
        //                                    select _user).ToList();

        //        var IQueryablepartner = (from _user in _context.partner
        //                                 where _user.FG_Flag == true
        //                                 select _user).ToList();

        //        partnerModel.affiliates = IQueryableaffiliated;
        //        partnerModel.partners = IQueryablepartner;

        //        return partnerModel;
        //    }
        //    catch(Exception ex)
        //    {
                
        //        return partnerModel;
        //    }

        //}
        public PartnerModel GetPartnerAffiliate()
        {
            PartnerModel partnerModel = new PartnerModel();
            List<OrderState> orderStates = new List<OrderState>();
            try
            {
                SqlCommand cmd = new SqlCommand("usp_GetPartner");
                SqlConnection con = new SqlConnection(conn);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                DataSet ds = new DataSet();
                sda.Fill(ds);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    List<partner> lstpartner = new List<partner>();
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        partner partner = new partner();
                        partner.Partner_Name = Convert.ToString(dr["Partner_Name"]);
                        partner.PartnerId = Convert.ToString(dr["PartnerId"]);
                        lstpartner.Add(partner);
                    }
                    partnerModel.partners = lstpartner;
                }

            }
            catch (Exception)
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
                    List<Affiliate> lstaffiliate = new List<Affiliate>();
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        Affiliate affiliate = new Affiliate();
                        affiliate.Affiliate_Name = Convert.ToString(dr["Affiliate_Name"]);
                        affiliate.AffiliateId = Convert.ToString(dr["AffiliateId"]);
                        lstaffiliate.Add(affiliate);
                    }
                    partnerModel.affiliates = lstaffiliate;
                }

            }
            catch (Exception)
            {

                throw;
            }
            return partnerModel;

        }

    }
}
