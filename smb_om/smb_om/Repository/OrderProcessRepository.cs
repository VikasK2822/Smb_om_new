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
    public class OrderProcessRepository : IOrderProcess
    {
        public string conn { get; set; }
        public IConfiguration Configuration { get; }
        public OrderProcessRepository(IConfiguration configuration) 
        {

            Configuration = configuration;
            conn = Configuration.GetConnectionString("DataContext");
           
        }
        public OrderInformation GetOrderInformation(string Order_Number)
        {
            OrderInformation orderInfo = new OrderInformation();
            OrderHearderInfo hearderInfo = new OrderHearderInfo();
            Account accountInfo = new Account();
            Address serviceaddrres = new Address();
            Address billingaddress  = new Address();    
            Verify verifyInfo = new Verify();
            List<OrderDocument> documentlist = new List<OrderDocument>();   
            Payment paymentinfo = new Payment();
            BusinessDetails businessinfo = new BusinessDetails();
            List<ProductInstallationInfo> productinstallationlist = new List<ProductInstallationInfo>();

            List<RepNotesHistory> _repcommentlist = new List<RepNotesHistory>();    
            List<RepNotesHistory> _systemcommentlist = new List<RepNotesHistory>(); 

            #region Package Instance
            PackageInformation _packageInfo = new PackageInformation();
            InternetPackage internetPackageinfo = new InternetPackage();
            VoipPackage voipPackageInfo = new VoipPackage();
            PotsPackage potsPackageInfo = new PotsPackage();
            List<ProductPackageInformation> _InternetPackagelist = new List<ProductPackageInformation>();
            List<ProductPackageInformation> _VoipPackagelist = new List<ProductPackageInformation>();
            List<ProductPackageInformation> _PotsPackagelist = new List<ProductPackageInformation>();
            List<PromoPackageInformation> Ineternet_PromoPackagelist = new List<PromoPackageInformation>();
            List<PromoPackageInformation> Voip_PromoPackagelist = new List<PromoPackageInformation>();
            #endregion

            try
            {
                SqlCommand cmd = new SqlCommand("USP_Get_OrderInformationById");
                cmd.Parameters.AddWithValue("@Order_Number", Order_Number);
                SqlConnection con = new SqlConnection(conn);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                DataSet ds = new DataSet();
                sda.Fill(ds);
     
                if (ds.Tables[0].Rows.Count > 0)
                {
                    string Billing_Account_Number = Convert.ToString(ds.Tables[0].Rows[0]["Billing_Account_Number"]);

                    #region  OrderHearderInfo Details

                    orderInfo.Order_Number = Convert.ToString(ds.Tables[0].Rows[0]["Order_Number"]);
                    orderInfo.TransactionId = Convert.ToString(ds.Tables[0].Rows[0]["TransactionId"]);
                    hearderInfo.BAN = Billing_Account_Number;
                    string Order_Create_Date_string = Convert.ToString(ds.Tables[0].Rows[0]["Order_Create_Date"]);
                    if(!string.IsNullOrEmpty(Order_Create_Date_string))
                    {
                        hearderInfo.Order_Create_Date = Order_Create_Date_string;
                    }
                   // hearderInfo.Order_Create_Date = DateTimeOffset.Parse(Order_Create_Date_string);
                   // DateTimeOffset.Now.DateTime.ToString("yyyy-MM-dd'T'HH:mm:ss'Z'")


                    hearderInfo.CustomerName = Convert.ToString(ds.Tables[0].Rows[0]["CustomerName"]);
                    hearderInfo.ServiceAddress = Convert.ToString(ds.Tables[0].Rows[0]["Service_Address"]);
                    hearderInfo.UVSalesCode = Convert.ToString(ds.Tables[0].Rows[0]["UV_Sales_Code"]);

                    hearderInfo.Partner = Convert.ToString(ds.Tables[0].Rows[0]["Partner_Name"]);
                    hearderInfo.Affiliate = Convert.ToString(ds.Tables[0].Rows[0]["Affiliate_Name"]);
                    hearderInfo.OrderType = Convert.ToString(ds.Tables[0].Rows[0]["Order_Type"]);
                    hearderInfo.CommonOrderId = Convert.ToString(ds.Tables[0].Rows[0]["Common_Order_ID"]);
                    hearderInfo.Canbereached = Convert.ToString(ds.Tables[0].Rows[0]["CBR_Phone_Number"]);

                    hearderInfo.Seller_Name= Convert.ToString(ds.Tables[0].Rows[0]["Seller_Name"]);
                    hearderInfo.Seller_PhoneNumber = Convert.ToString(ds.Tables[0].Rows[0]["Seller_PhoneNumber"]);
                    hearderInfo.Seller_AgentID = Convert.ToString(ds.Tables[0].Rows[0]["Seller_AgentID"]);
                    hearderInfo.Seller_EmailAddress = Convert.ToString(ds.Tables[0].Rows[0]["Seller_EmailAddress"]);
                    hearderInfo.Seller_Contact_Phone_Number = Convert.ToString(ds.Tables[0].Rows[0]["Seller_Contact_Phone_Number"]);
                    hearderInfo.Seller_Preferred_Contact_Method = Convert.ToString(ds.Tables[0].Rows[0]["Seller_Preferred_Contact_Method"]);
                    hearderInfo.Seller_Linkedorder = Convert.ToString(ds.Tables[0].Rows[0]["Seller_Linkedorder"]);
                    hearderInfo.Seller_Partner_Agent_Notes = Convert.ToString(ds.Tables[0].Rows[0]["Seller_Agents_Notes"]);
                    orderInfo.Message_To_Seller= Convert.ToString(ds.Tables[0].Rows[0]["Message_To_Seller"]);
                    // attaching header info 
                    orderInfo.HearderInfo = hearderInfo;
                    #endregion
                    #region Account Info
                  
                    
                    accountInfo.Billing_Account_Number = Billing_Account_Number;
                    accountInfo.Common_OrderID = Convert.ToString(ds.Tables[0].Rows[0]["Common_Order_ID"]);
                    accountInfo.Fiber_OMS_OrderID = Convert.ToString(ds.Tables[0].Rows[0]["Fiber_OMS_Order_ID"]);
                    accountInfo.Payment_Confirmation_Number = Convert.ToString(ds.Tables[0].Rows[0]["Pay_Confirmation_Number"]);
                    accountInfo.Ticket_Number = Convert.ToString(ds.Tables[0].Rows[0]["Ticket_Number"]);
                    accountInfo.Bolt_On_OrderNumber = Convert.ToString(ds.Tables[0].Rows[0]["Bolt_Order_Number"]);
                    accountInfo.Unified_Credit_TransactionID = Convert.ToString(ds.Tables[0].Rows[0]["Unified_Credit_Transaction_ID"]);
                    accountInfo.Credit_Class = Convert.ToString(ds.Tables[0].Rows[0]["Credit_Class"]);
                    accountInfo.Bureau_Name_Abbreviation = Convert.ToString(ds.Tables[0].Rows[0]["Common_Order_ID"]);
                    orderInfo.AccountInfo = accountInfo;
                    #endregion

                    #region  verify Authentication 

                   
                    if (Convert.ToString(ds.Tables[0].Rows[0]["Date_Of_Birth"]) != "")
                        verifyInfo.Authentication_DOB= DateTimeOffset.Parse(Convert.ToString(ds.Tables[0].Rows[0]["Date_Of_Birth"]));
                        verifyInfo.Authentication_SSN= Convert.ToString(ds.Tables[0].Rows[0]["SSN"]);
                        verifyInfo.Authentication_FederalTaxID= Convert.ToString(ds.Tables[0].Rows[0]["federalTaxId"]);
                        verifyInfo.Authentication_DriversLicense= Convert.ToString(ds.Tables[0].Rows[0]["licenseNumber"]);
                        verifyInfo.Authentication_State= Convert.ToString(ds.Tables[0].Rows[0]["state"]);
                    if (Convert.ToString(ds.Tables[0].Rows[0]["licenseExpirationDate"]) != "")
                        verifyInfo.Authentication_ExpirationDate = DateTimeOffset.Parse(Convert.ToString(ds.Tables[0].Rows[0]["licenseExpirationDate"]));

                      
                        verifyInfo.Authentication_Officer1SSN= Convert.ToString(ds.Tables[0].Rows[0]["SSN_Officer1"]);
                        verifyInfo.Authentication_Officer2SSN= Convert.ToString(ds.Tables[0].Rows[0]["SSN_Officer2"]);
                        verifyInfo.SecurityVerificationn_PIN= Convert.ToString(ds.Tables[0].Rows[0]["Security_Pin"]);
                        verifyInfo.SecurityVerificationn_Securit_Question= Convert.ToString(ds.Tables[0].Rows[0]["Security_Question"]);
                        verifyInfo.SecurityVerificationn_Security_Answer= Convert.ToString(ds.Tables[0].Rows[0]["Security_Answer"]);

                    #endregion

                   
                    #region Payment info
                       
                        paymentinfo.Payment_Type= Convert.ToString(ds.Tables[0].Rows[0]["Payment_Type"])==""?"NA": Convert.ToString(ds.Tables[0].Rows[0]["Payment_Type"]);
                        paymentinfo.Amount= Convert.ToString(ds.Tables[0].Rows[0]["Amount"]);
                       if(Convert.ToString(ds.Tables[0].Rows[0]["Disclosure_Accepted"]) !="")
                        {
                        bool isDisclosure_Accepted = Convert.ToBoolean(ds.Tables[0].Rows[0]["Disclosure_Accepted"]);
                        paymentinfo.DisclosureAccepted = isDisclosure_Accepted == true ? "y" : "N";
                        }
                     
                        paymentinfo.CreditCardType= Convert.ToString(ds.Tables[0].Rows[0]["Card_type"]);
                        paymentinfo.CreditCardNumber= Convert.ToString(ds.Tables[0].Rows[0]["Card_Number"]);
                        paymentinfo.CreditCardName= Convert.ToString(ds.Tables[0].Rows[0]["CreditCardName"]);
                        paymentinfo.AuthorizationNumber= Convert.ToString(ds.Tables[0].Rows[0]["Authorization_Number"]);
                        if (Convert.ToString(ds.Tables[0].Rows[0]["Expiration_Date"]) != "")
                        {
                        paymentinfo.DB_ExpirationDate = DateTimeOffset.Parse(Convert.ToString(ds.Tables[0].Rows[0]["Expiration_Date"]));
                        paymentinfo.ExpirationDate = paymentinfo.DB_ExpirationDate.ToString("yyyy-MM");
                        }



                    #endregion
                    #region Bussiness Info
                        
                        businessinfo.BusinessName = Convert.ToString(ds.Tables[0].Rows[0]["Business_Name"]);
                        businessinfo.BusinessType = Convert.ToString(ds.Tables[0].Rows[0]["Business_Type"]);
                        businessinfo.FederalTaxID = Convert.ToString(ds.Tables[0].Rows[0]["federalTaxId"]);
                       if(Convert.ToString(ds.Tables[0].Rows[0]["Date_Of_Incorporation"])!="")
                        {
                        DateTimeOffset offset = DateTimeOffset.Parse(Convert.ToString(ds.Tables[0].Rows[0]["Date_Of_Incorporation"]));
                        businessinfo.DateOfIncorporation = offset.ToString("MM/dd/yyyy");
                        }
                       
                        businessinfo.StateOfIncorporation = Convert.ToString(ds.Tables[0].Rows[0]["State_Of_Incorporation"]);
                        businessinfo.Officer1_First_Name = Convert.ToString(ds.Tables[0].Rows[0]["First_Name_Officer1"]);
                        businessinfo.Officer1_Last_Name = Convert.ToString(ds.Tables[0].Rows[0]["Last_Name_Officer1"]);
                        businessinfo.Officer1_Phone_Number = Convert.ToString(ds.Tables[0].Rows[0]["Phone_Number_Officer1"]);
                        businessinfo.Officer1_Email_Address = Convert.ToString(ds.Tables[0].Rows[0]["Email_Address_Officer1"]);


                    #endregion

                    potsPackageInfo.POTS_Order_Number = Convert.ToString(ds.Tables[0].Rows[0]["POTS_Order_Number"]);
                    potsPackageInfo.Customer_Billing_Telephone_Number= Convert.ToString(ds.Tables[0].Rows[0]["Customer_Billing_Telephone_Number"]);
                    potsPackageInfo.RDS_Ticket_Number = Convert.ToString(ds.Tables[0].Rows[0]["RDS_Ticket_Number"]);

                }
               

                if (ds.Tables[1].Rows.Count > 0)
                {
                    foreach (DataRow item in ds.Tables[1].Rows) 
                    {
                        string AddressType = Convert.ToString(item["Address_type"]);
                       
                        if(AddressType.ToUpper()== "SERVICE")
                        {
                            serviceaddrres.AddressType = AddressType;
                            serviceaddrres.Street_Number_Prefix = Convert.ToString(item["Street_Number_Prefix"]);
                            serviceaddrres.Street_Number = Convert.ToString(item["Street_Number"]);
                            serviceaddrres.Street_Number_Suffix = Convert.ToString(item["Street_Number_Suffix"]);
                            serviceaddrres.Street_Direction = Convert.ToString(item["Street_Direction"]);
                            serviceaddrres.Street_Name = Convert.ToString(item["Street_Name"]);
                            serviceaddrres.Street_Type = Convert.ToString(item["Street_Type"]);
                            serviceaddrres.Street_Trailing_Direction = Convert.ToString(item["Street_Trailing_Direction"]);
                            serviceaddrres.Assigned_Street_Number = Convert.ToString(item["Assigned_Street_Number"]);
                            serviceaddrres.Structure_Type = "";
                            serviceaddrres.Structure_Value = Convert.ToString(item["Structure"]);
                            serviceaddrres.Level_Type = "";
                            serviceaddrres.Level_Value = Convert.ToString(item["Level"]);
                            serviceaddrres.Apartment_Type = "";
                            serviceaddrres.Apartment_Value = Convert.ToString(item["Apartment"]);
                            serviceaddrres.City = Convert.ToString(item["City"]);
                            serviceaddrres.State = Convert.ToString(item["State"]);
                            serviceaddrres.Zip = Convert.ToString(item["Zip"]);
                            serviceaddrres.Country = Convert.ToString(item["County"]);
                            serviceaddrres.Post_Office_Box = "";
                            serviceaddrres.Rural_Route_Box_Ctr_Number = "";
                            serviceaddrres.Urbanization_Code = Convert.ToString(item["Urbanization_Code"]);
                            serviceaddrres.Address_Ticket = "";
                        }
                       else if(AddressType.ToUpper() == "BILLING")
                        {

                            billingaddress.AddressType = AddressType;
                            billingaddress.Street_Number_Prefix = Convert.ToString(item["Street_Number_Prefix"]);
                            billingaddress.Street_Number = Convert.ToString(item["Street_Number"]);
                            billingaddress.Street_Number_Suffix = Convert.ToString(item["Street_Number_Suffix"]);
                            billingaddress.Street_Direction = Convert.ToString(item["Street_Direction"]);
                            billingaddress.Street_Name = Convert.ToString(item["Street_Name"]);
                            billingaddress.Street_Type = Convert.ToString(item["Street_Type"]);
                            billingaddress.Street_Trailing_Direction = Convert.ToString(item["Street_Trailing_Direction"]);
                            billingaddress.Assigned_Street_Number = Convert.ToString(item["Assigned_Street_Number"]);
                            billingaddress.Structure_Type = "";
                            billingaddress.Structure_Value = Convert.ToString(item["Structure"]);
                            billingaddress.Level_Type = "";
                            billingaddress.Level_Value = Convert.ToString(item["Level"]);
                            billingaddress.Apartment_Type = "";
                            billingaddress.Apartment_Value = Convert.ToString(item["Apartment"]);
                            billingaddress.City = Convert.ToString(item["City"]);
                            billingaddress.State = Convert.ToString(item["State"]);
                            billingaddress.Zip = Convert.ToString(item["Zip"]);
                            billingaddress.Country = Convert.ToString(item["County"]);
                            billingaddress.Post_Office_Box = "";
                            billingaddress.Rural_Route_Box_Ctr_Number = "";
                            billingaddress.Urbanization_Code = Convert.ToString(item["Urbanization_Code"]);
                            billingaddress.Address_Ticket = "";

                            
                        }
                    
                    }
                   
                    
                }

              
              

                if (ds.Tables[2].Rows.Count > 0)
                {
                    foreach(DataRow packageitem in ds.Tables[2].Rows)   
                    {
                        int rowid= Convert.ToInt32(packageitem["RowId"]);
                        string Package_Type = Convert.ToString(packageitem["Package_Type"]);    
                        if(Package_Type.ToUpper()=="ORDER")
                        {
                            OrderPackageInformation _orderPackageInfo = new OrderPackageInformation();
                            _orderPackageInfo.Display_Name = Convert.ToString(packageitem["Display_Name"]);
                            _orderPackageInfo.USOC = Convert.ToString(packageitem["Usoc"]);
                            _orderPackageInfo.Price = Convert.ToString(packageitem["Price"]);
                            _orderPackageInfo.Activation_Fee = Convert.ToString(packageitem["Activation_Fee"]);
                            _packageInfo.orderPackageinfo = _orderPackageInfo;
                        }
                        else  if (Package_Type.ToUpper() == "INTERNET")
                        {
                            ProductPackageInformation _internetPackage = new ProductPackageInformation();   
                            
                            _internetPackage.Package_RowId = rowid;
                            _internetPackage.Package_Type = Convert.ToString(packageitem["Package_Type"]);
                            _internetPackage.Order_Number = Convert.ToString(packageitem["Order_Number"]);
                            _internetPackage.Display_Name= Convert.ToString(packageitem["Display_Name"]);
                            _internetPackage.Isprocessed = Convert.IsDBNull(packageitem["IsProcessed"])?false : Convert.ToBoolean(packageitem["IsProcessed"]);
                            _internetPackage.Price = Convert.ToString(packageitem["Price"]);
                            _internetPackage.Text_Answer = Convert.ToString(packageitem["Text_Answer"]);
                            _InternetPackagelist.Add(_internetPackage);
                            _packageInfo.IsInternetPackageInformation = true;
                        }
                        else if (Package_Type.ToUpper() == "VOIP")
                        {   
                            ProductPackageInformation _voipPackage = new ProductPackageInformation();   

                            _voipPackage.Package_RowId = rowid;
                            _voipPackage.Package_Type = Convert.ToString(packageitem["Package_Type"]);
                            _voipPackage.Order_Number = Convert.ToString(packageitem["Order_Number"]);
                            _voipPackage.Display_Name = Convert.ToString(packageitem["Display_Name"]);
                            _voipPackage.Isprocessed = Convert.IsDBNull(packageitem["IsProcessed"]) ? false : Convert.ToBoolean(packageitem["IsProcessed"]);
                            _voipPackage.Price = Convert.ToString(packageitem["Price"]);
                            _voipPackage.Text_Answer = Convert.ToString(packageitem["Text_Answer"]);
                            _VoipPackagelist.Add(_voipPackage);
                            _packageInfo.IsVoipPackageInformation = true;
                        }
                        else if (Package_Type.ToUpper() == "POTS")
                        {
                            ProductPackageInformation _PotsPackage = new ProductPackageInformation();

                            _PotsPackage.Package_RowId = rowid;
                            _PotsPackage.Package_Type = Convert.ToString(packageitem["Package_Type"]);
                            _PotsPackage.Order_Number = Convert.ToString(packageitem["Order_Number"]);
                            _PotsPackage.Display_Name = Convert.ToString(packageitem["Display_Name"]);
                            _PotsPackage.Isprocessed = Convert.IsDBNull(packageitem["IsProcessed"]) ? false : Convert.ToBoolean(packageitem["IsProcessed"]);
                            _PotsPackage.Price = Convert.ToString(packageitem["Price"]);
                            _PotsPackage.Text_Answer = Convert.ToString(packageitem["Text_Answer"]);
                            _PotsPackagelist.Add(_PotsPackage);
                            _packageInfo.IsPotsPackageInformation = true;
                        }
                        else if (Package_Type.ToUpper() == "AWB")
                        {   
                                 AwbPackageInformation _awbInfo = new AwbPackageInformation();
                                _awbInfo.Package_RowId = rowid;
                            _awbInfo.Package_Type = Convert.ToString(packageitem["Package_Type"]);
                            _awbInfo.Order_Number = Convert.ToString(packageitem["Order_Number"]);
                            _awbInfo.Isprocessed = Convert.IsDBNull(packageitem["IsProcessed"]) ? false : Convert.ToBoolean(packageitem["IsProcessed"]);
                            _awbInfo.AWB_Agreement_Number= Convert.ToString(packageitem["AWB_Agreement_Number"]);
                                _awbInfo.AWB_CTN= Convert.ToString(packageitem["AWB_CTN"]);
                                _packageInfo.AwbPackageInformation = _awbInfo;
                                 _packageInfo.IsAWBPackageInformation = true;
                        }
                        else if (Package_Type.ToUpper() == "PROMO")
                        {
                            PromoPackageInformation _promoInfo = new PromoPackageInformation();
                             string _Parent_Package = Convert.ToString(packageitem["Parent_Package"]);
                            _promoInfo.Package_RowId = rowid;
                            _promoInfo.Display_Name = Convert.ToString(packageitem["Display_Name"]);
                             _promoInfo.USOC = Convert.ToString(packageitem["Usoc"]);
                                _promoInfo.Price = Convert.ToString(packageitem["Price"]);
                                _promoInfo.Action = Convert.ToString(packageitem["Action"]);
                            if(_Parent_Package.ToUpper()=="INTERNET")
                            {
                                internetPackageinfo.IsPromoPackageInformation = true;
                                Ineternet_PromoPackagelist.Add(_promoInfo);
                            }
                            if (_Parent_Package.ToUpper() == "VOIP")
                            {
                                voipPackageInfo.IsPromoPackageInformation = true;
                                Voip_PromoPackagelist.Add(_promoInfo);
                            }


                        }

                    }
                    internetPackageinfo.InternetPackagelist = _InternetPackagelist;
                    internetPackageinfo.promoPackageInformation = Ineternet_PromoPackagelist;
                    _packageInfo.InternetPackageInfo = internetPackageinfo;

                    voipPackageInfo.VoipPackagelist = _VoipPackagelist;
                    potsPackageInfo.PotsPackagelist = _PotsPackagelist;
                    voipPackageInfo.promoPackageInformation = Voip_PromoPackagelist;
                    _packageInfo.VoipPackageInfo = voipPackageInfo;
                    _packageInfo.PotsPackageInfo = potsPackageInfo;
                    
                }
                if (ds.Tables[3].Rows.Count > 0)
                {
                    #region Document info

                    foreach (DataRow dr in ds.Tables[3].Rows)
                    {
                        OrderDocument docinfo = new OrderDocument();
                        docinfo.Document_RowId = Convert.ToInt32(dr["RowId"]);
                        docinfo.DocumentName = Convert.ToString(dr["Document_Name"]);
                        docinfo.DocumentType = Convert.ToString(dr["Document_Type"]);
                        docinfo.UserID = Convert.ToString(dr["AgentId"]);
                        if (Convert.ToString(dr["doc_Timestamp"]) != "")
                            docinfo.DocumentUpload_TimeStamp = DateTimeOffset.Parse(Convert.ToString(dr["doc_Timestamp"]));
                        if (Convert.ToString(dr["Document_Accepted"]) != "")
                            docinfo.DocumentUpload_Accepted = Convert.ToBoolean(Convert.ToString(dr["Document_Accepted"]));
                        docinfo.DocumentPath = Convert.ToString(dr["Document_Path"]);
                        documentlist.Add(docinfo);
                    }


                    #endregion
                }
                //rep comments info
                if (ds.Tables[4].Rows.Count > 0)
                {
                    foreach (DataRow item in ds.Tables[4].Rows)
                    {
                        string Note_Type=Convert.ToString(item["Note_Type"]);
                        string State_Id = Convert.ToString(item["State_Id"]);
                       
                        if(State_Id=="31" && Note_Type=="R")
                        {
                            if(!string.IsNullOrEmpty(Convert.ToString(item["Anticipated_Provisioning_Date"])))
                            {
                                orderInfo.anticipatedProvisioningDate = Convert.ToDateTime(Convert.ToString(item["Anticipated_Provisioning_Date"]));
                            }
                        }

                        RepNotesHistory repNotesHistory = new RepNotesHistory();  
                        //if(Convert.ToString(item["Rep_TimeStamp"])!=null)
                      //  repNotesHistory.Rep_TimeStamp = (Convert.ToDateTime(item["Rep_TimeStamp"])).ToString("MM/dd/yyyy hh:mm:ss tt");

                        repNotesHistory.Rep_TimeStamp = Convert.ToString(item["Rep_TimeStamp"]);
                        repNotesHistory.Rep_ID = Convert.ToString(item["Rep_ID"]);
                        repNotesHistory.Rep_Display_Response = Convert.ToString(item["Display_Response"]);
                        repNotesHistory.Comments = Convert.ToString(item["Rep_Comment_Text"]);
                       
                        if (Note_Type=="R")
                        {
                            _repcommentlist.Add(repNotesHistory);
                        }
                        else
                        {
                            _systemcommentlist.Add(repNotesHistory);
                        }

                    }
                }

                  if (ds.Tables[5].Rows.Count > 0)
                  {
                        foreach (DataRow item in ds.Tables[5].Rows)
                        {
                            ProductInstallationInfo _productInstallationInfo = new ProductInstallationInfo();

                        _productInstallationInfo.Product_RowId = Convert.ToInt32(item["RowId"]);
                        _productInstallationInfo.Product_Type= Convert.ToString(item["Product_Type"]);

                            if (Convert.ToString(item["Requested_Installation_Date"]) != "")
                                _productInstallationInfo.Requested_Installation_Date = DateTimeOffset.Parse(Convert.ToString(item["Requested_Installation_Date"]));

                            if (Convert.ToString(item["Requested_Installation_Time"]) != "")
                            {
                                _productInstallationInfo.Requested_Installation_DB_Input_time = DateTimeOffset.Parse(Convert.ToString(item["Requested_Installation_Time"]));
                                _productInstallationInfo.Requested_Installation_Time = _productInstallationInfo.Requested_Installation_DB_Input_time.ToString("HH:mm");
                            }


                        if (Convert.ToString(item["Schedule_Date"]) != "")
                            _productInstallationInfo.Scheduled_Installation_Date = DateTimeOffset.Parse(Convert.ToString(item["Schedule_Date"]));

                        if (Convert.ToString(item["Sechudle_start_Time"]) != "")
                        {
                           
                            _productInstallationInfo.Scheduled_Installation_StartTime = Convert.ToString(item["Sechudle_start_Time"]);
                        }
                        if (Convert.ToString(item["Sechudle_end_Time"]) != "")
                        {

                            _productInstallationInfo.Scheduled_Installation_EndTime = Convert.ToString(item["Sechudle_end_Time"]);
                        }
                        productinstallationlist.Add(_productInstallationInfo);
                        }
                   
                    }

                if (ds.Tables[7].Rows.Count > 0)
                {
                    foreach (DataRow item in ds.Tables[7].Rows)
                    {
                       string Category_Name = Convert.ToString(item["Category_Name"]);
                        if(!string.IsNullOrEmpty(Category_Name))
                        {

                            if(Category_Name.ToUpper()=="INTERNET")
                            {
                                orderInfo.InternetStateId = Convert.IsDBNull(item["State_Id"]) ? (int?)null : Convert.ToInt32(item["State_Id"]);
                                orderInfo.InternetReasonCodeId = Convert.IsDBNull(item["Reason_Code"]) ? (int?)null : Convert.ToInt32(item["Reason_Code"]);
                                orderInfo.IsInternetState = true;
                            }
                            if (Category_Name.ToUpper() == "VOIP")
                            {
                                orderInfo.VoipStateId = Convert.IsDBNull(item["State_Id"]) ? (int?)null : Convert.ToInt32(item["State_Id"]);
                                orderInfo.VoipReasonCodeId =Convert.IsDBNull(item["Reason_Code"]) ? (int?)null : Convert.ToInt32(item["Reason_Code"]);
                                orderInfo.IsVoipState = true;
                            }
                            if (Category_Name.ToUpper() == "AWB")
                            {
                                orderInfo.AwsStateId = Convert.IsDBNull(item["State_Id"]) ? (int?)null : Convert.ToInt32(item["State_Id"]);
                                orderInfo.AwsReasonCodeId = Convert.IsDBNull(item["Reason_Code"]) ? (int?)null : Convert.ToInt32(item["Reason_Code"]);
                                orderInfo.IsAwsState = true;
                            }
                            if (Category_Name.ToUpper() == "POTS")
                            {
                                orderInfo.PotsStateId = Convert.IsDBNull(item["State_Id"]) ? (int?)null : Convert.ToInt32(item["State_Id"]);
                                orderInfo.PotsReasonCodeId = Convert.IsDBNull(item["Reason_Code"]) ? (int?)null : Convert.ToInt32(item["Reason_Code"]);
                                orderInfo.IsPotsState = true;
                            }
                            

                        }
                    }

                }

                verifyInfo.BillingAddress = billingaddress;
                orderInfo.VerifyInfo = verifyInfo;
                orderInfo.DocumentList = documentlist;
                paymentinfo.CardBillingZip = billingaddress.Zip;
                orderInfo.PaymentInfo = paymentinfo;
                orderInfo.ServiceAddressInfo = serviceaddrres;
                orderInfo.BillingAddressInfo = billingaddress;
             
                orderInfo.BusinessInfo = businessinfo;
                orderInfo.PackageInfo = _packageInfo;
                orderInfo.ProductInstallationList = productinstallationlist;
                orderInfo.RepCommentsHistory = _repcommentlist;
                orderInfo.SystemNotes = _systemcommentlist;



            }  
            catch (Exception ex )
            {

                throw;
            }
            return orderInfo;
        }
        public List<OrderState> GetOrderAllStateInformation(string Order_Number)    
        {
            List<OrderState> orderStates = new List<OrderState>();
            try
            {
                SqlCommand cmd = new SqlCommand("usp_getStatebyOrder_Number");
                cmd.Parameters.AddWithValue("@Order_Number", Order_Number);
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
                        OrderState _ostate = new OrderState();
                        _ostate.CategoryId = Convert.ToInt32(dr["CategoryId"]);
                        _ostate.CategoryName = Convert.ToString(dr["Category_Name"]);
                        _ostate.StateId = Convert.ToInt32(dr["StateId"]);
                        _ostate.StateName = Convert.ToString(dr["StateName"]);
                        orderStates.Add(_ostate);
                    }
                }
               
            }
            catch (Exception)
            {

                throw;
            }
            return orderStates;
        }
        public List<StateReasonInformation> GetStateReasonInformation(string stateid)
        {
            List<StateReasonInformation> StateReasonInfos = new List<StateReasonInformation>(); 
            try
            {
                SqlCommand cmd = new SqlCommand("usp_getReasonCodeInfoByStateId");
                cmd.Parameters.AddWithValue("@StateId", stateid);
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
                        StateReasonInformation _ostatereason = new StateReasonInformation();
                        _ostatereason.StateId = Convert.ToInt32(dr["StateId"]);
                        _ostatereason.ReasonCode = Convert.ToInt32(dr["ReasonCode"]);
                        _ostatereason.ReasonCodeName = Convert.ToString(dr["ReasonCodeName"]);
                        StateReasonInfos.Add(_ostatereason);
                    }
                }

            }
            catch (Exception)
            {

                throw;
            }
            return StateReasonInfos;
        }

        public List<specialproject> GetAllSpecialProject()
        {
            List<specialproject> specialprojects = new List<specialproject>();  
            try
            {
                SqlCommand cmd = new SqlCommand("usp_get_specialproject_type_master");
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
                        specialproject _specialproject = new specialproject();
                        _specialproject.ProjectId = Convert.ToString(dr["ProjectId"]);
                        _specialproject.SpecialProjectName = Convert.ToString(dr["SpecialProjectName"]);

                        specialprojects.Add(_specialproject);
                    }
                }

            }
            catch (Exception)
            {

                throw;
            }
            return specialprojects;

        }

        public List<specialprojectAction> GetSpecialProjectActionById(string ProjectId)
        {
            List<specialprojectAction> specialprojectActions = new List<specialprojectAction>();
            try
            {
                if(!string.IsNullOrEmpty(ProjectId))
                {

                    SqlCommand cmd = new SqlCommand("usp_get_specialproject_action_master");
                    cmd.Parameters.AddWithValue("@ProjectId", ProjectId);
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
                            specialprojectAction _specialprojectAction = new specialprojectAction();
                         
                            _specialprojectAction.ActionId = Convert.ToString(dr["ActionId"]);
                            _specialprojectAction.SpecialProject_Action_Name = Convert.ToString(dr["SpecialProject_Action_Name"]);
                            specialprojectActions.Add(_specialprojectAction);
                        }
                    }

                }

            }
            catch (Exception)
            {

                throw;
            }
            return specialprojectActions;

        }

        public string Insert_Order_Request(string transactionid,string ordernumber,string UserId,string repComments,int ? InternetStateId,int ? InternetReasonCodeId
          ,int ? VoipStateId,int ? VoipReasonCodeId,int ? AwsStateId, int? AwsReasonCodeId, int? PotsStateId,int ? PotsReasonCodeId, DateTime Anticipated_Provisioning_Date
            , string Partner_AgentNotes, string Billing_Account_Number, string Common_OrderID, string Fiber_OMS_OrderID, string Payment_Confirmation_Number, string Ticket_Number
        , string Bolt_On_OrderNumber, string Authentication_State, DateTimeOffset Authentication_ExpirationDate, string Customer_Billing_Telephone_Number, string POTS_Order_Number
        , string RDS_Ticket_Number, DataTable Dt_ProductsInstallation, DataTable Dt_OrderDocument, DataTable Dt_ProductPackage,string message_to_seller)
        {

            SqlCommand cmd = new SqlCommand("usp_insert_order_info");
            cmd.Parameters.AddWithValue("@transactionid", transactionid);
            cmd.Parameters.AddWithValue("@ordernumber", ordernumber);
            cmd.Parameters.AddWithValue("@UserId", UserId);
            cmd.Parameters.AddWithValue("@repComments", repComments);
         
            if (InternetStateId.HasValue)
            {
                cmd.Parameters.AddWithValue("@InternetStateId", InternetStateId);
            }
            if (InternetReasonCodeId.HasValue)
            {
                cmd.Parameters.AddWithValue("@InternetReasonCodeId", InternetReasonCodeId);
            }
            if (VoipStateId.HasValue)
            {
                cmd.Parameters.AddWithValue("@VoipStateId", VoipStateId);
            }
            if (VoipReasonCodeId.HasValue)
            {
                cmd.Parameters.AddWithValue("@VoipReasonCodeId", VoipReasonCodeId);
            }
            if (AwsStateId.HasValue)
            {

                cmd.Parameters.AddWithValue("@AwsStateId", AwsStateId);
            }
            if (AwsReasonCodeId.HasValue)
            {
                cmd.Parameters.AddWithValue("@AwsReasonCodeId", AwsReasonCodeId);
            }
            if (PotsStateId.HasValue)
            {

                cmd.Parameters.AddWithValue("@PotsStateId", PotsStateId);
            }
            if (PotsReasonCodeId.HasValue)
            {

                cmd.Parameters.AddWithValue("@PotsReasonCodeId", PotsReasonCodeId);
            }
            

            if(Anticipated_Provisioning_Date.Year>1900)
            cmd.Parameters.AddWithValue("@Anticipated_Provisioning_Date", Anticipated_Provisioning_Date);
            cmd.Parameters.AddWithValue("@Partner_AgentNotes", Partner_AgentNotes);
            cmd.Parameters.AddWithValue("@Billing_Account_Number", Billing_Account_Number);
            cmd.Parameters.AddWithValue("@Common_OrderID", Common_OrderID);
            cmd.Parameters.AddWithValue("@Fiber_OMS_OrderID", Fiber_OMS_OrderID);
            cmd.Parameters.AddWithValue("@Payment_Confirmation_Number", Payment_Confirmation_Number);
            cmd.Parameters.AddWithValue("@Ticket_Number", Ticket_Number);
            cmd.Parameters.AddWithValue("@Bolt_On_OrderNumber", Bolt_On_OrderNumber);
            cmd.Parameters.AddWithValue("@Authentication_State", Authentication_State);
            cmd.Parameters.AddWithValue("@Authentication_licenseExpirationDate", Authentication_ExpirationDate);
            cmd.Parameters.AddWithValue("@Customer_Billing_Telephone_Number", Customer_Billing_Telephone_Number);
            cmd.Parameters.AddWithValue("@POTS_Order_Number", POTS_Order_Number);
            cmd.Parameters.AddWithValue("@RDS_Ticket_Number", RDS_Ticket_Number);
            cmd.Parameters.AddWithValue("@Dt_ProductsInstallation", Dt_ProductsInstallation);
            cmd.Parameters.AddWithValue("@Dt_OrderDocument", Dt_OrderDocument);
            cmd.Parameters.AddWithValue("@Dt_ProductPackage", Dt_ProductPackage);
            cmd.Parameters.AddWithValue("@message_to_seller", message_to_seller);


            cmd.Parameters.Add("@ERROR", SqlDbType.VarChar, 500);
            cmd.Parameters["@ERROR"].Direction = ParameterDirection.Output;

            string result = Insert_Edit_Delete_Out(cmd);

            return result;


         


           
        }
        public string Insert_Edit_Delete_Out(SqlCommand cmd)
        {
            string message = string.Empty;
            try
            {
                SqlConnection con = new SqlConnection(conn);
                con.Open();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                cmd.ExecuteNonQuery();
                message = (string)cmd.Parameters["@ERROR"].Value;
                con.Close();
                return message;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public List<UnassignedOrder> GetNonMovableOrder()

        {
            List<UnassignedOrder> lstunassignedOrder = new List<UnassignedOrder>();
          

            try
            {
                SqlCommand cmd = new SqlCommand("GetNonMovableOrder");
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
                        UnassignedOrder unassignedOrder = new UnassignedOrder();
                        unassignedOrder.Createddate = DateTimeOffsetHelper.FromString(dr["Created_Date"].ToString()).ToString("R");
                        unassignedOrder.OrderNumber = Convert.ToString(dr["Order_Number"]);
                        unassignedOrder.UserName = Convert.ToString(dr["Locked_User_Id"]);
                        lstunassignedOrder.Add(unassignedOrder);
                    }
                }

            }
            catch (Exception)
            {

                throw;
            }

            return lstunassignedOrder;
        }

        public class DateTimeOffsetHelper
        {
            public static DateTimeOffset FromString(string offsetString)
            {

                DateTimeOffset offset;
                if (!DateTimeOffset.TryParse(offsetString, out offset))
                {
                    offset = DateTimeOffset.Now;
                }

                return offset;
            }
        }

        public int UpdateUnassignOrder(string OrderNumber )
        { 
        
            List<UnassignedOrder> lstunassignedOrder = new List<UnassignedOrder>();
            int iresult = default(int);
            try
            {
                SqlCommand cmd = new SqlCommand("UpdateUnassignOrder");
                SqlConnection con = new SqlConnection(conn);
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@Order_Number", OrderNumber);
                iresult =  cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

                throw;
            }

            return iresult;
        }

    }
}
