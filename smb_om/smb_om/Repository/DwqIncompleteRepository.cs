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
    public class DwqIncompleteRepository : IDwqIncomplete   
    {
        public string conn { get; set; }
        public IConfiguration Configuration { get; }
        public DwqIncompleteRepository(IConfiguration configuration)    
        {   

            Configuration = configuration;
            conn = Configuration.GetConnectionString("DataContext");

        }
        public DqwIncompleteModel GetIncompleteQueueOrder()
        {
            DqwIncompleteModel dqwIncompleteModel = new DqwIncompleteModel();

           
            try
            {
                SqlCommand cmd = new SqlCommand("usp_get_smb_order_dwqueueIncomplete");
                SqlConnection con = new SqlConnection(conn);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                DataSet ds = new DataSet();
                sda.Fill(ds);
                if( ds!=null&& ds.Tables[0].Rows.Count > 0)
                {
                    DataTable UVERSE_DT = ds.Tables[0];
                    var distinctValues = UVERSE_DT.AsEnumerable().Select(a => a.Field<string>("ReasonCodeName")).Distinct().ToList();
                    
                    List<Product_type> Uverse_Product_Queue_List = new List<Product_type>();    
                        foreach (var item in distinctValues) 
                        {
                            string ReasonCodeName = item;
                            Product_type _product_Type = new Product_type();
                            List<PartnerQueue> _PartnerDaysOrder = new List<PartnerQueue>();    
                            foreach (DataRow uvdata in UVERSE_DT.Rows)  
                            {
                                if(ReasonCodeName== Convert.ToString(uvdata["ReasonCodeName"]))
                                {
                                    PartnerQueue partnerQueue = new PartnerQueue();
                                    int row_num = Convert.IsDBNull(uvdata["row_num"]) ? 0 : Convert.ToInt32(uvdata["row_num"]);
                                    if(row_num==1)
                                    {
                                        _product_Type.ProductName = Convert.ToString(uvdata["ReasonCodeName"]);
                                        _product_Type.TotalnoOrders = Convert.ToString(uvdata["counts"]);
                                        _product_Type.SLA_Color = Convert.ToString(uvdata["SLAColor"]);
                                        _product_Type.OldestOrderQuene = Convert.ToString(uvdata["Oldest_Order_Queue_Day"]);

                                     }
                                    partnerQueue.PartnerText = Convert.ToString(uvdata["Display_value"]);
                                    partnerQueue.PartnerValue = Convert.ToString(uvdata["PatnerName"]);
                                    _PartnerDaysOrder.Add(partnerQueue);
                                }
                            }
                            _product_Type.PartnerDaysOrder = _PartnerDaysOrder;
                            Uverse_Product_Queue_List.Add(_product_Type);
                        }

                    dqwIncompleteModel.UverseQueue = Uverse_Product_Queue_List;
                }
                if (ds != null && ds.Tables[1] !=null && ds.Tables[1].Rows.Count > 0)
                {
                    DataTable UVERSE_DT = ds.Tables[1];
                    var distinctValues = UVERSE_DT.AsEnumerable().Select(a => a.Field<string>("ReasonCodeName")).Distinct().ToList();

                    List<Product_type> Uverse_Product_Queue_List = new List<Product_type>();
                    foreach (var item in distinctValues)
                    {
                        string ReasonCodeName = item;
                        Product_type _product_Type = new Product_type();
                        List<PartnerQueue> _PartnerDaysOrder = new List<PartnerQueue>();
                        foreach (DataRow uvdata in UVERSE_DT.Rows)
                        {
                            if (ReasonCodeName == Convert.ToString(uvdata["ReasonCodeName"]))
                            {
                                PartnerQueue partnerQueue = new PartnerQueue();
                                int row_num = Convert.IsDBNull(uvdata["row_num"]) ? 0 : Convert.ToInt32(uvdata["row_num"]);
                                if (row_num == 1)
                                {
                                    _product_Type.ProductName = Convert.ToString(uvdata["ReasonCodeName"]);
                                    _product_Type.TotalnoOrders = Convert.ToString(uvdata["counts"]);
                                    _product_Type.SLA_Color = Convert.ToString(uvdata["SLAColor"]);
                                    _product_Type.OldestOrderQuene = Convert.ToString(uvdata["Oldest_Order_Queue_Day"]);

                                }
                                partnerQueue.PartnerText = Convert.ToString(uvdata["Display_value"]);
                                partnerQueue.PartnerValue = Convert.ToString(uvdata["PatnerName"]);
                                _PartnerDaysOrder.Add(partnerQueue);
                            }
                        }
                        _product_Type.PartnerDaysOrder = _PartnerDaysOrder;
                        Uverse_Product_Queue_List.Add(_product_Type);
                    }

                    dqwIncompleteModel.AwbQueue = Uverse_Product_Queue_List;
                }
                if (ds != null && ds.Tables[2] != null && ds.Tables[2].Rows.Count > 0)
                {
                    DataTable UVERSE_DT = ds.Tables[2];
                    var distinctValues = UVERSE_DT.AsEnumerable().Select(a => a.Field<string>("ReasonCodeName")).Distinct().ToList();

                    List<Product_type> Uverse_Product_Queue_List = new List<Product_type>();
                    foreach (var item in distinctValues)
                    {
                        string ReasonCodeName = item;
                        Product_type _product_Type = new Product_type();
                        List<PartnerQueue> _PartnerDaysOrder = new List<PartnerQueue>();
                        foreach (DataRow uvdata in UVERSE_DT.Rows)
                        {
                            if (ReasonCodeName == Convert.ToString(uvdata["ReasonCodeName"]))
                            {
                                PartnerQueue partnerQueue = new PartnerQueue();
                                int row_num = Convert.IsDBNull(uvdata["row_num"]) ? 0 : Convert.ToInt32(uvdata["row_num"]);
                                if (row_num == 1)
                                {
                                    _product_Type.ProductName = Convert.ToString(uvdata["ReasonCodeName"]);
                                    _product_Type.TotalnoOrders = Convert.ToString(uvdata["counts"]);
                                    _product_Type.SLA_Color = Convert.ToString(uvdata["SLAColor"]);
                                    _product_Type.OldestOrderQuene = Convert.ToString(uvdata["Oldest_Order_Queue_Day"]);

                                }
                                partnerQueue.PartnerText = Convert.ToString(uvdata["Display_value"]);
                                partnerQueue.PartnerValue = Convert.ToString(uvdata["PatnerName"]);
                                _PartnerDaysOrder.Add(partnerQueue);
                            }
                        }
                        _product_Type.PartnerDaysOrder = _PartnerDaysOrder;
                        Uverse_Product_Queue_List.Add(_product_Type);
                    }

                    dqwIncompleteModel.PotsQueue = Uverse_Product_Queue_List;
                }


            }
            catch (Exception)
            {

                throw;
            }
            return dqwIncompleteModel;

        }

        public string GetDwqInCompleteOrderId(string ProductType, string PartnerName, string reasoncodeName, string user_id)
        {
            string _order_number = "";
            try
            {
                SqlCommand cmd = new SqlCommand("usp_get_Incompleete_DWQ_orderId");
                cmd.Parameters.AddWithValue("@Product_Type", ProductType);
                cmd.Parameters.AddWithValue("@Partner_Name", PartnerName);
                cmd.Parameters.AddWithValue("@ReasonCode_Name", reasoncodeName);
                cmd.Parameters.AddWithValue("@User_Id", user_id);
                
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
