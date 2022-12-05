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
    public class QuickSearchRepository : IQuickSearch
    {
        public string conn { get; set; }
        public IConfiguration Configuration { get; }
        public QuickSearchRepository(IConfiguration configuration)
        {

            Configuration = configuration;
            conn = Configuration.GetConnectionString("DataContext");

        }

        public OrderQuickSearch GetOrderSearchDrp()
        {
            OrderQuickSearch orderSearch = new OrderQuickSearch();
            List<QuickSearchResult> lstQuickSearch = new List<QuickSearchResult>();
            try
            {
                SqlCommand cmd = new SqlCommand("Usp_GetPartner");
                SqlConnection con = new SqlConnection(conn);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                DataSet ds = new DataSet();
                sda.Fill(ds);

                List<partnersearch> lstpartner = new List<partnersearch>();
                if (ds.Tables[0].Rows.Count > 0)
                {

                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        partnersearch partner = new partnersearch();
                        partner.text = Convert.ToString(dr["Partner_Name"]); 
                        partner.value = Convert.ToString(dr["PartnerId"]);
                        lstpartner.Add(partner);
                    }
                }
                orderSearch.partners = lstpartner;

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
                List<affiliatesearch> lstaffiliate = new List<affiliatesearch>();
                if (ds.Tables[0].Rows.Count > 0)
                {

                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        affiliatesearch affiliatesearch = new affiliatesearch();
                        affiliatesearch.text = Convert.ToString(dr["Affiliate_Name"]); 
                        affiliatesearch.value = Convert.ToString(dr["AffiliateId"]);
                        lstaffiliate.Add(affiliatesearch);
                    }
                }
                orderSearch.affiliates = lstaffiliate;

            }
            catch (Exception ex)
            {

                throw;
            }
            try
            {
                SqlCommand cmd = new SqlCommand("Usp_GetDistinctState");
                SqlConnection con = new SqlConnection(conn);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                DataSet ds = new DataSet();
                sda.Fill(ds);

                List<statereason> lststateReason = new List<statereason>();
                if (ds.Tables[0].Rows.Count > 0)
                {

                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        statereason statereason = new statereason();
                        statereason.text = Convert.ToString(dr["StateName"]); 
                        statereason.value = Convert.ToString(dr["StateId"]);
                        lststateReason.Add(statereason);
                    }
                }
                orderSearch.statereasons = lststateReason;


            }
            catch (Exception ex)
            {

                throw;
            }
            return orderSearch;
        }

            public OrderQuickSearch GetOrderSearchDetails(OrderQuickSearch orderQuickSearch)
        {
            OrderQuickSearch orderSearch = new OrderQuickSearch();
            List<QuickSearchResult> lstQuickSearch = new List<QuickSearchResult>();
            try
            {
                SqlCommand cmd = new SqlCommand("usp_get_smb_order_QuickSearch_info");
                SqlConnection con = new SqlConnection(conn);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@CBR_Phone_Number", orderQuickSearch.CBRPhoneNumber);
                cmd.Parameters.AddWithValue("@Ordernumber", orderQuickSearch.OrderNumber);
                cmd.Parameters.AddWithValue("@Billing_Account_Number", orderQuickSearch.BillingAccountNumber);
                cmd.Parameters.AddWithValue("@Common_Order_Number", orderQuickSearch.commonOrderNumber);
                cmd.Parameters.AddWithValue("@Business_Name", orderQuickSearch.quickBusinessName);
                if( !orderQuickSearch.Isordertype)
                {
                    cmd.Parameters.AddWithValue("@IsOrderType", 0);
                }
                else
                    cmd.Parameters.AddWithValue("@IsOrderType", 1);



                DataSet ds = new DataSet();
                sda.Fill(ds);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        QuickSearchResult quickSearchResult = new QuickSearchResult();
                        quickSearchResult.OrderNumber = Convert.ToString(dr["Order_Number"]);
                        quickSearchResult.partnerName = Convert.ToString(dr["Partner_Name"]);
                        quickSearchResult.Product = Convert.ToString(dr["Product"]);
                        quickSearchResult.Status = Convert.ToString(dr["Status"]);
                        quickSearchResult.Business_Name = Convert.ToString(dr["Business_Name"]);
                        quickSearchResult.Repid = Convert.ToString(dr["RepId"]);
                        quickSearchResult.LastUpadtedDate = Convert.ToString(dr["LastUpadtedDate"]);
                        quickSearchResult.ReceivedDate = Convert.ToString(dr["ReceivedDate"]);
                        lstQuickSearch.Add(quickSearchResult);
                    }
                }
                orderSearch.quickSearchResults = lstQuickSearch;

            }
            catch (Exception ex)
            {

                throw;
            }
          


            return orderSearch;

        }



        public List<productstate> GetReasonById(string stateID)
        {
            List<productstate> productstates = new List<productstate>();
            try
            {
                if (!string.IsNullOrEmpty(stateID))
                {

                    SqlCommand cmd = new SqlCommand("Usp_GetReasonCodestate");
                    cmd.Parameters.AddWithValue("@StateName", stateID);
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
                            productstate prdstate = new productstate();
                            prdstate.text = Convert.ToString(dr["ReasonCode"]);
                            prdstate.value = Convert.ToString(dr["Reasoncodeid"]);

                            productstates.Add(prdstate);
                        }
                    }

                }

            }
            catch (Exception)
            {

                throw;
            }
            return productstates;

        }

        public OrderQuickSearch GetOrderCompleteSearchDetails(DetailSearch detailSearch)
        {
            OrderQuickSearch orderSearch = new OrderQuickSearch();
            List<detailSearchResult> lstQuickSearch = new List<detailSearchResult>();
            try
            {
                SqlCommand cmd = new SqlCommand("Usp_GetDetails");
                SqlConnection con = new SqlConnection(conn);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@orderid", detailSearch.OrderNumber);
                cmd.Parameters.AddWithValue("@contactPhNumber", detailSearch.contactNumber);
                cmd.Parameters.AddWithValue("@LastName", detailSearch.LastName);
                cmd.Parameters.AddWithValue("@BusinessName", detailSearch.BusinesName);
                cmd.Parameters.AddWithValue("@BillingAcctNumber", detailSearch.BillingAccountNumber);
                cmd.Parameters.AddWithValue("@CommonOrderNumber", detailSearch.CommonOrderNumber);
                cmd.Parameters.AddWithValue("@OrderType", detailSearch.OrderType);
                //cmd.Parameters.AddWithValue("@IsOrderType", orderQuickSearch.quickBusinessName);
                cmd.Parameters.AddWithValue("@Partnerid", detailSearch.Partnerid);
                cmd.Parameters.AddWithValue("@Affiliateid", detailSearch.Affiliateid);
                cmd.Parameters.AddWithValue("@region", detailSearch.region);
                cmd.Parameters.AddWithValue("@orderstate", detailSearch.orderstate);
                cmd.Parameters.AddWithValue("@product", detailSearch.product);
                cmd.Parameters.AddWithValue("@productState", detailSearch.productState);
                cmd.Parameters.AddWithValue("@productStateReason", detailSearch.productStateReason);
                cmd.Parameters.AddWithValue("@startDate", detailSearch.startDate);
                cmd.Parameters.AddWithValue("@enddate", detailSearch.enddate);





                if (!detailSearch.IsOrderType)
                {
                    cmd.Parameters.AddWithValue("@IsOrderType", 0);
                }
                else
                    cmd.Parameters.AddWithValue("@IsOrderType", 1);



                DataSet ds = new DataSet();
                sda.Fill(ds);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        detailSearchResult quickSearchResult = new detailSearchResult();
                        quickSearchResult.OrderNumber = Convert.ToString(dr["Order_Number"]);
                        quickSearchResult.partnerName = Convert.ToString(dr["Partner_Name"]);
                        quickSearchResult.Product = Convert.ToString(dr["Product"]);
                        quickSearchResult.Status = Convert.ToString(dr["Status"]);
                        quickSearchResult.Business_Name = Convert.ToString(dr["Business_Name"]);
                        quickSearchResult.Repid = Convert.ToString(dr["RepId"]);
                        quickSearchResult.LastUpadtedDate = Convert.ToString(dr["LastUpadtedDate"]);
                        quickSearchResult.ReceivedDate = Convert.ToString(dr["ReceivedDate"]);
                        lstQuickSearch.Add(quickSearchResult);
                    }
                }
                orderSearch.detailSearchResults = lstQuickSearch;

            }
            catch (Exception ex)
            {

                throw;
            }


            return orderSearch;

        }
    }
}
