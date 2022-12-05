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
    public class DwqCheckInstallRepository: IDwqCheckInstall
    {

        public string conn { get; set; }
        public IConfiguration Configuration { get; }
        public DwqCheckInstallRepository(IConfiguration configuration)
        {

            Configuration = configuration;
            conn = Configuration.GetConnectionString("DataContext");

        }
        public DwqCheckInstallModel GetCheckInstallQueueOrder()
        {
            DwqCheckInstallModel dwqCheckInstall = new DwqCheckInstallModel();
            try
            {
                SqlCommand cmd = new SqlCommand("usp_get_smb_order_dwqueueCheckInstall");
                SqlConnection con = new SqlConnection(conn);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                DataSet ds = new DataSet();
                sda.Fill(ds);
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    DataTable Product_Type_DT = ds.Tables[0];   
                    var distinctValues = Product_Type_DT.AsEnumerable().Select(a => a.Field<string>("Product_Type")).Distinct().ToList();

                    List<Product_type> Product_Queue_List = new List<Product_type>();   
                    foreach (var item in distinctValues)
                    {
                              
                        Product_type _product_Type = new Product_type();
                        List<PartnerQueue> _PartnerDaysOrder = new List<PartnerQueue>();
                        foreach (DataRow uvdata in Product_Type_DT.Rows)
                        {
                            if (item == Convert.ToString(uvdata["Product_Type"]))
                            {
                                PartnerQueue partnerQueue = new PartnerQueue();
                                int row_num = Convert.IsDBNull(uvdata["row_num"]) ? 0 : Convert.ToInt32(uvdata["row_num"]);
                                if (row_num == 1)
                                {
                                    _product_Type.ProductName = Convert.ToString(uvdata["Product_Type"]);
                                    _product_Type.TotalnoOrders = Convert.ToString(uvdata["Order_Count"]);
                                    _product_Type.SLA_Color = Convert.ToString(uvdata["SLAColor"]);
                                    _product_Type.OldestOrderQuene = Convert.ToString(uvdata["Oldest_Order_Queue_Day"]);

                                }
                                partnerQueue.PartnerText = Convert.ToString(uvdata["Display_value"]);
                                partnerQueue.PartnerValue = Convert.ToString(uvdata["PatnerName"]);
                                _PartnerDaysOrder.Add(partnerQueue);
                            }
                        }
                        _product_Type.PartnerDaysOrder = _PartnerDaysOrder;
                        Product_Queue_List.Add(_product_Type);
                    }

                    dwqCheckInstall.CheckInstall3DayQueue = Product_Queue_List;
                }
                if (ds != null && ds.Tables[1].Rows.Count > 0)
                {
                    DataTable Product_Type_DT = ds.Tables[1];
                    var distinctValues = Product_Type_DT.AsEnumerable().Select(a => a.Field<string>("Product_Type")).Distinct().ToList();

                    List<Product_type> Product_Queue_List = new List<Product_type>();
                    foreach (var item in distinctValues)
                    {

                        Product_type _product_Type = new Product_type();
                        List<PartnerQueue> _PartnerDaysOrder = new List<PartnerQueue>();
                        foreach (DataRow uvdata in Product_Type_DT.Rows)
                        {
                            if (item == Convert.ToString(uvdata["Product_Type"]))
                            {
                                PartnerQueue partnerQueue = new PartnerQueue();
                                int row_num = Convert.IsDBNull(uvdata["row_num"]) ? 0 : Convert.ToInt32(uvdata["row_num"]);
                                if (row_num == 1)
                                {
                                    _product_Type.ProductName = Convert.ToString(uvdata["Product_Type"]);
                                    _product_Type.TotalnoOrders = Convert.ToString(uvdata["Order_Count"]);
                                    _product_Type.SLA_Color = Convert.ToString(uvdata["SLAColor"]);
                                    _product_Type.OldestOrderQuene = Convert.ToString(uvdata["Oldest_Order_Queue_Day"]);

                                }
                                partnerQueue.PartnerText = Convert.ToString(uvdata["Display_value"]);
                                partnerQueue.PartnerValue = Convert.ToString(uvdata["PatnerName"]);
                                _PartnerDaysOrder.Add(partnerQueue);
                            }
                        }
                        _product_Type.PartnerDaysOrder = _PartnerDaysOrder;
                        Product_Queue_List.Add(_product_Type);
                    }

                    dwqCheckInstall.CheckInstall2DayQueue = Product_Queue_List;
                }
                if (ds != null && ds.Tables[2].Rows.Count > 0)
                {
                    DataTable Product_Type_DT = ds.Tables[2];
                    var distinctValues = Product_Type_DT.AsEnumerable().Select(a => a.Field<string>("Product_Type")).Distinct().ToList();

                    List<Product_type> Product_Queue_List = new List<Product_type>();
                    foreach (var item in distinctValues)
                    {

                        Product_type _product_Type = new Product_type();
                        List<PartnerQueue> _PartnerDaysOrder = new List<PartnerQueue>();
                        foreach (DataRow uvdata in Product_Type_DT.Rows)
                        {
                            if (item == Convert.ToString(uvdata["Product_Type"]))
                            {
                                PartnerQueue partnerQueue = new PartnerQueue();
                                int row_num = Convert.IsDBNull(uvdata["row_num"]) ? 0 : Convert.ToInt32(uvdata["row_num"]);
                                if (row_num == 1)
                                {
                                    _product_Type.ProductName = Convert.ToString(uvdata["Product_Type"]);
                                    _product_Type.TotalnoOrders = Convert.ToString(uvdata["Order_Count"]);
                                    _product_Type.SLA_Color = Convert.ToString(uvdata["SLAColor"]);
                                    _product_Type.OldestOrderQuene = Convert.ToString(uvdata["Oldest_Order_Queue_Day"]);

                                }
                                partnerQueue.PartnerText = Convert.ToString(uvdata["Display_value"]);
                                partnerQueue.PartnerValue = Convert.ToString(uvdata["PatnerName"]);
                                _PartnerDaysOrder.Add(partnerQueue);
                            }
                        }
                        _product_Type.PartnerDaysOrder = _PartnerDaysOrder;
                        Product_Queue_List.Add(_product_Type);
                    }

                    dwqCheckInstall.CheckInstall1DayQueue = Product_Queue_List;
                }
                if (ds != null && ds.Tables[3].Rows.Count > 0)
                {
                    DataTable Product_Type_DT = ds.Tables[3];
                    var distinctValues = Product_Type_DT.AsEnumerable().Select(a => a.Field<string>("Product_Type")).Distinct().ToList();

                    List<Product_type> Product_Queue_List = new List<Product_type>();
                    foreach (var item in distinctValues)
                    {

                        Product_type _product_Type = new Product_type();
                        List<PartnerQueue> _PartnerDaysOrder = new List<PartnerQueue>();
                        foreach (DataRow uvdata in Product_Type_DT.Rows)
                        {
                            if (item == Convert.ToString(uvdata["Product_Type"]))
                            {
                                PartnerQueue partnerQueue = new PartnerQueue();
                                int row_num = Convert.IsDBNull(uvdata["row_num"]) ? 0 : Convert.ToInt32(uvdata["row_num"]);
                                if (row_num == 1)
                                {
                                    _product_Type.ProductName = Convert.ToString(uvdata["Product_Type"]);
                                    _product_Type.TotalnoOrders = Convert.ToString(uvdata["Order_Count"]);
                                    _product_Type.SLA_Color = Convert.ToString(uvdata["SLAColor"]);
                                    _product_Type.OldestOrderQuene = Convert.ToString(uvdata["Oldest_Order_Queue_Day"]);

                                }
                                partnerQueue.PartnerText = Convert.ToString(uvdata["Display_value"]);
                                partnerQueue.PartnerValue = Convert.ToString(uvdata["PatnerName"]);
                                _PartnerDaysOrder.Add(partnerQueue);
                            }
                        }
                        _product_Type.PartnerDaysOrder = _PartnerDaysOrder;
                        Product_Queue_List.Add(_product_Type);
                    }

                    dwqCheckInstall.CheckInstallDayQueue = Product_Queue_List;
                }
                if (ds != null && ds.Tables[4].Rows.Count > 0)
                {
                    DataTable Product_Type_DT = ds.Tables[4];
                    var distinctValues = Product_Type_DT.AsEnumerable().Select(a => a.Field<string>("Product_Type")).Distinct().ToList();

                    List<Product_type> Product_Queue_List = new List<Product_type>();
                    foreach (var item in distinctValues)
                    {

                        Product_type _product_Type = new Product_type();
                        List<PartnerQueue> _PartnerDaysOrder = new List<PartnerQueue>();
                        foreach (DataRow uvdata in Product_Type_DT.Rows)
                        {
                            if (item == Convert.ToString(uvdata["Product_Type"]))
                            {
                                PartnerQueue partnerQueue = new PartnerQueue();
                                int row_num = Convert.IsDBNull(uvdata["row_num"]) ? 0 : Convert.ToInt32(uvdata["row_num"]);
                                if (row_num == 1)
                                {
                                    _product_Type.ProductName = Convert.ToString(uvdata["Product_Type"]);
                                    _product_Type.TotalnoOrders = Convert.ToString(uvdata["Order_Count"]);
                                    _product_Type.SLA_Color = Convert.ToString(uvdata["SLAColor"]);
                                    _product_Type.OldestOrderQuene = Convert.ToString(uvdata["Oldest_Order_Queue_Day"]);

                                }
                                partnerQueue.PartnerText = Convert.ToString(uvdata["Display_value"]);
                                partnerQueue.PartnerValue = Convert.ToString(uvdata["PatnerName"]);
                                _PartnerDaysOrder.Add(partnerQueue);
                            }
                        }
                        _product_Type.PartnerDaysOrder = _PartnerDaysOrder;
                        Product_Queue_List.Add(_product_Type);
                    }

                    dwqCheckInstall.PostInstallDayQueue = Product_Queue_List;
                }

            }
            catch (Exception)
            {

                throw;
            }

            return dwqCheckInstall;

        }
        public string GetDwqCheckInstallOrderId(string Product_Type, string Partner_Name, string Queue_Name, string User_Id)    
        {

            string _order_number = "";
            try
            {
                SqlCommand cmd = new SqlCommand("usp_get_CheckInstall_DWQ_orderId");
                cmd.Parameters.AddWithValue("@Product_Type", Product_Type);
                cmd.Parameters.AddWithValue("@Partner_Name", Partner_Name);
                cmd.Parameters.AddWithValue("@Queue_Name", Queue_Name);
                cmd.Parameters.AddWithValue("@User_Id", User_Id);

                SqlConnection con = new SqlConnection(conn);

                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                DataSet ds = new DataSet();
                sda.Fill(ds);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    _order_number = Convert.ToString(ds.Tables[0].Rows[0]["Order_Number"]);
                }

            }
            catch (Exception)
            {

                throw;
            }


            return _order_number;
        }
    }

}
