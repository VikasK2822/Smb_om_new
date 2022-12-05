using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using smb_om.Data;
using smb_om.Infrastructure;
using smb_om.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace smb_om.Repository
{
   
    public class MlpRepository : Imlp
    {
        //private readonly DataContext _context;

        //public MlpRepository(DataContext context)
        //{
        //    this._context = context;
        //}

        public string conn { get; set; }
        public IConfiguration Configuration { get; }
        public MlpRepository(IConfiguration configuration)
        {

            Configuration = configuration;
            conn = Configuration.GetConnectionString("DataContext");

        }
        public MlpModel GetOrderMlp()
        {
            MlpModel mlpModel = new MlpModel();
            List<Product_type> All_product_Types_list = new List<Product_type>();   
            try
            {
                SqlCommand cmd = new SqlCommand("usp_get_smb_order_queue");
                SqlConnection con = new SqlConnection(conn);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                DataSet ds = new DataSet();
                sda.Fill(ds);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    Product_type _UVERSE_product_Type = new Product_type();
                    List<PartnerQueue> _uverse_Partner_List = new List<PartnerQueue>();
                   
                    Product_type _POTS_product_Type = new Product_type();
                    List<PartnerQueue> _POTS_Partner_List = new List<PartnerQueue>();

                    Product_type _AWB_product_Type = new Product_type();
                    List<PartnerQueue> _AWB_Partner_List = new List<PartnerQueue>();

                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                       
                        string service_name= Convert.ToString(dr["servicename"]);
                        if(!string.IsNullOrEmpty(service_name))
                        {

                            if(service_name.ToUpper()== "UVERSE")
                            {
                                int row_num = Convert.IsDBNull(dr["row_num"]) ? 0 : Convert.ToInt32(dr["row_num"]);
                                if(row_num==1)
                                {
                                    _UVERSE_product_Type.OldestOrderQuene= Convert.ToString(dr["Oldest_Order_Queue_Day"]);
                                    _UVERSE_product_Type.ProductName = service_name;
                                    _UVERSE_product_Type.TotalnoOrders= Convert.ToString(dr["Order_Count"]);
                                    _UVERSE_product_Type.SLA_Color= Convert.ToString(dr["SLAColor"]); 
                                }
                                PartnerQueue _partnerQueue = new PartnerQueue();
                                _partnerQueue.PartnerValue = Convert.ToString(dr["Partner_Name"]);
                               _partnerQueue.PartnerText = Convert.ToString(dr["Display_value"]);
                                _uverse_Partner_List.Add(_partnerQueue);
                            }
                            else if (service_name.ToUpper() == "POTS")
                            {
                                int row_num = Convert.IsDBNull(dr["row_num"]) ? 0 : Convert.ToInt32(dr["row_num"]);
                                if (row_num == 1)
                                {
                                    _POTS_product_Type.OldestOrderQuene = Convert.ToString(dr["Oldest_Order_Queue_Day"]);
                                    _POTS_product_Type.ProductName = service_name;
                                    _POTS_product_Type.TotalnoOrders = Convert.ToString(dr["Order_Count"]);
                                    _POTS_product_Type.SLA_Color = Convert.ToString(dr["SLAColor"]);
                                }
                                PartnerQueue _partnerQueue = new PartnerQueue();
                                _partnerQueue.PartnerValue = Convert.ToString(dr["Partner_Name"]);
                                _partnerQueue.PartnerText = Convert.ToString(dr["Display_value"]);
                                _POTS_Partner_List.Add(_partnerQueue);
                            }
                            else if (service_name.ToUpper() == "AWB")
                            {
                                int row_num = Convert.IsDBNull(dr["row_num"]) ? 0 : Convert.ToInt32(dr["row_num"]);
                                if (row_num == 1)
                                {
                                    _AWB_product_Type.OldestOrderQuene = Convert.ToString(dr["Oldest_Order_Queue_Day"]);
                                    _AWB_product_Type.ProductName = service_name;
                                    _AWB_product_Type.TotalnoOrders = Convert.ToString(dr["Order_Count"]);
                                    _AWB_product_Type.SLA_Color = Convert.ToString(dr["SLAColor"]);
                                }
                                PartnerQueue _partnerQueue = new PartnerQueue();
                                _partnerQueue.PartnerValue = Convert.ToString(dr["Partner_Name"]);
                                _partnerQueue.PartnerText = Convert.ToString(dr["Display_value"]);
                                _AWB_Partner_List.Add(_partnerQueue);
                            }
                        }
                        
                        
                    }

                    _UVERSE_product_Type.PartnerDaysOrder = _uverse_Partner_List;
                    _POTS_product_Type.PartnerDaysOrder = _POTS_Partner_List;
                    _AWB_product_Type.PartnerDaysOrder = _AWB_Partner_List;
                    All_product_Types_list.Add(_UVERSE_product_Type);
                    All_product_Types_list.Add(_POTS_product_Type);
                    All_product_Types_list.Add(_AWB_product_Type);
                }
                mlpModel.product_Types = All_product_Types_list;

            }
            catch (Exception)
            {

                throw;
            }
            return mlpModel;

        }
        public string GetSmbOrderId(string Product_Type, string Partner_Name,string User_Id)
        {
            string _order_number = "";
            try
            {
                SqlCommand cmd = new SqlCommand("usp_get_smb_orderId");
                cmd.Parameters.AddWithValue("@Product_Type", Product_Type);
                cmd.Parameters.AddWithValue("@Partner_Name", Partner_Name);
                cmd.Parameters.AddWithValue("@User_Id", User_Id);
                SqlConnection con = new SqlConnection(conn);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                DataSet ds = new DataSet();
                sda.Fill(ds);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    _order_number= Convert.ToString(ds.Tables[0].Rows[0]["Order_Number"]);
                }

            }
            catch (Exception)
            {

                throw;
            }
           

            return _order_number;

        }

        // public MlpModel GetOrderMlp()
        //{
        //    MlpModel mlpModel = new MlpModel();
        //    List<Product_type> lst_product_Type = new List<Product_type>();
        //    try
        //    {
        //        var IQueryablevalidateUser = (from _user in _context.OrderMaster
        //                                      join p in _context.partner on _user.PartnerId equals p.PartnerId
        //                                      join a in _context.productInformation on _user.TransactionId equals a.Transaction_Id
        //                                      where _user.Order_WorkStatus == 0 && _user.FG_Flag == true
        //                                      select new Order_product_partner
        //                                      {
        //                                          PatnerName = p.Partner_Name,
        //                                          ProductName = a.Product_Type,
        //                                          OrderDate = _user.Created_Date

        //                                      });



        //        var productName = (from c in IQueryablevalidateUser
        //                           select c.ProductName).Distinct().ToList();
        //        var PartnerName = (from c in IQueryablevalidateUser
        //                           select c.PatnerName).Distinct().ToList();




        //        foreach (string prdname in productName)
        //        {
        //            List<string> PartnerDaysOrder = new List<string>();
        //            Product_type product_Type = new Product_type();
        //            foreach (string prtname in PartnerName)
        //            {
        //                int iordercount = 0;
        //                DateTimeOffset oldestdate = DateTime.UtcNow;
        //                foreach (Order_product_partner obj in IQueryablevalidateUser)
        //                {
        //                    if (obj.ProductName == prdname && obj.PatnerName == prtname)
        //                    {
        //                        DateTime checkdate = DateTime.Now;
        //                        if (iordercount == 0)
        //                        {
        //                            oldestdate = obj.OrderDate.LocalDateTime;

        //                        }
        //                        else if (obj.OrderDate.LocalDateTime < oldestdate)
        //                        {
        //                            oldestdate = obj.OrderDate.LocalDateTime;
        //                        }


        //                        string partnerDays = "";
        //                        iordercount = iordercount + 1;
        //                        TimeSpan ts = DateTime.Now - oldestdate;
        //                        partnerDays = obj.PatnerName + "(" + iordercount + ")" + " -- " + ts.Days + " days " + ts.Hours + " hours " + ts.Minutes + " minutes ";

        //                        var checkpartnername = PartnerDaysOrder.Where(x => x.Contains(obj.PatnerName)).FirstOrDefault();
        //                        if (!string.IsNullOrEmpty(checkpartnername))
        //                        {
        //                            PartnerDaysOrder.Remove(checkpartnername);
        //                        }

        //                        PartnerDaysOrder.Add(partnerDays);
        //                        product_Type.PartnerDaysOrder = PartnerDaysOrder;
        //                        //  product_Type.OldestOrderQuene = Convert.ToString(oldestdate);
        //                        product_Type.ProductName = obj.ProductName;
        //                        product_Type.TotalnoOrders = Convert.ToString(iordercount);
        //                        // string rfc1123Date = oldestdate.ToLocalTime().ToString("R");
        //                        string rfc1123Date = oldestdate.ToString("R");
        //                        product_Type.OldestOrderQuene = Convert.ToString(rfc1123Date);
        //                        // var parsedDt = Convert.ToDateTime(rfc1123Date);
        //                        // DateTime.ParseExact(, CultureInfo.CurrentCulture.DateTimeFormat.RFC1123Pattern, CultureInfo.CurrentCulture).ToLocalTime();


        //                    }


        //                }

        //            }
        //            lst_product_Type.Add(product_Type);
        //        }


        //    }

        //    catch (Exception ex)
        //    {


        //    }


        //    mlpModel.product_Types = lst_product_Type;
        //    return mlpModel;


        //}
    }
}
