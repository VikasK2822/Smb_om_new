using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using smb_om.Infrastructure;
using smb_om.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;


namespace smb_om.Controllers
{
    public class OrderProcessController : Controller
    {

        private readonly IOrderProcess _orderProcess;    
        private readonly Iemail _email;
        private readonly IproductInformation _iproductInformation;
        private readonly INotificationUrl _InotificationUrl;
        private readonly IAffiliateReasonCode _affiliatereasoncode;
        public OrderProcessController(IOrderProcess _IorderProcess, Iemail iemail, IproductInformation iproductInformation, INotificationUrl InotificationUrl,IAffiliateReasonCode affiliateReasonCode) 
        {   
            this._orderProcess = _IorderProcess;
            _iproductInformation = iproductInformation;
            _email = iemail;
            _InotificationUrl = InotificationUrl;
            _affiliatereasoncode = affiliateReasonCode;

        }
        public IActionResult Index(string orderId)
        {
            
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("UserId")))
            {
                return RedirectToAction("Login", "Login");
            }
            OrderInformation orderInfo = new OrderInformation();
            
           // ViewBag.returnUrl = Request.Headers["Referer"].ToString();
            if (!string.IsNullOrEmpty(orderId))
            {
                //orderId = "G6WXKIIRPT6L";
                // orderId = "1696326553";
                orderInfo = _orderProcess.GetOrderInformation(orderId);

                List<OrderState> _allOrderstate = _orderProcess.GetOrderAllStateInformation(orderId);
                if (_allOrderstate.Count > 0)
                {
                    var _availableCategories = _allOrderstate.Select(o => new { CategoryName = o.CategoryName.ToUpper() }).Distinct().ToList();

                    if (_availableCategories.Any(a => a.CategoryName == "INTERNET"))
                    {
                        orderInfo.InternetState = _allOrderstate.Where(o => o.CategoryName.ToUpper() == "INTERNET").Select(P => new SelectListItem { Value = P.StateId.ToString(), Text = P.StateName }).ToList();
                        orderInfo.IsInternetState = true;
                    }
                    if (_availableCategories.Any(a => a.CategoryName == "VOIP"))
                    {
                        orderInfo.VoipState = _allOrderstate.Where(o => o.CategoryName.ToUpper() == "VOIP").Select(P => new SelectListItem { Value = P.StateId.ToString(), Text = P.StateName }).ToList();
                        orderInfo.IsVoipState = true;
                    }
                    if (_availableCategories.Any(a => a.CategoryName == "POTS"))
                    {
                        orderInfo.PotsState = _allOrderstate.Where(o => o.CategoryName.ToUpper() == "POTS").Select(P => new SelectListItem { Value = P.StateId.ToString(), Text = P.StateName }).ToList();
                        orderInfo.IsPotsState = true;
                    }
                    if (_availableCategories.Any(a => a.CategoryName == "AWB"))
                    {
                        orderInfo.AwsState = _allOrderstate.Where(o => o.CategoryName.ToUpper() == "AWB").Select(P => new SelectListItem { Value = P.StateId.ToString(), Text = P.StateName }).ToList();
                        orderInfo.IsAwsState = true;
                    }

                    var specialprojects = _orderProcess.GetAllSpecialProject();
                    if (specialprojects.Count > 0)
                        orderInfo.SpecialProjectType = specialprojects.Select(P => new SelectListItem { Value = P.ProjectId.ToString(), Text = P.SpecialProjectName }).ToList();


                }

            }
            orderInfo.previouspageinfo = HttpContext.Request.Query["returnurl"].ToString();
            
            //orderInfo.InternetStateId = 25;
            return View(orderInfo);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(string buttonVal , OrderInformation _orderInfo)          
        {
            var user_id = Convert.ToString(HttpContext.Session.GetString("UserId"));
            if(!string.IsNullOrEmpty(_orderInfo.Order_Number))
            {
                try
                {
                    string seller_partner_agents_notes = _orderInfo.HearderInfo.Seller_Partner_Agent_Notes;
                    //instalation_dates  --Uverse/POTS both
                    var _all_ProductInstallationList = _orderInfo.ProductInstallationList;
                    #region create table  ProductInstallationList

                    DataTable DT_TProductInstallation = new DataTable();
                    DT_TProductInstallation.Columns.Add("RowId", typeof(int));
                    DT_TProductInstallation.Columns.Add("Order_Number", typeof(string));
                    DT_TProductInstallation.Columns.Add("Product_Type", typeof(string));
                    DT_TProductInstallation.Columns.Add("Requested_Installation_Date", typeof(DateTimeOffset));
                    DT_TProductInstallation.Columns.Add("Requested_Installation_Time", typeof(DateTimeOffset));
                    DT_TProductInstallation.Columns.Add("Schedule_Date", typeof(DateTimeOffset));
                    DT_TProductInstallation.Columns.Add("Sechudle_start_Time", typeof(string));
                    DT_TProductInstallation.Columns.Add("Sechudle_end_Time", typeof(string));
                    DT_TProductInstallation.Columns.Add("Updated_By", typeof(string));

                    if (_all_ProductInstallationList != null && _all_ProductInstallationList.Count > 0)
                    {
                        foreach (var item in _all_ProductInstallationList)
                        {
                            DataRow drProductInstallationInput = DT_TProductInstallation.NewRow();

                            drProductInstallationInput["RowId"] = item.Product_RowId;
                            drProductInstallationInput["Order_Number"] = _orderInfo.Order_Number;
                            drProductInstallationInput["Product_Type"] = item.Product_Type;
                            var dt_requested_date = item.Requested_Installation_Date;
                            drProductInstallationInput["Requested_Installation_Date"] = dt_requested_date;

                            var requested_time = item.Requested_Installation_Time;
                            if (!string.IsNullOrEmpty(requested_time))
                            {
                                string[] hh_mm = requested_time.Split(":");
                                DateTime cal_installtion_date = new DateTime(dt_requested_date.Year, dt_requested_date.Month, dt_requested_date.Day, Convert.ToInt32(hh_mm[0]), Convert.ToInt32(hh_mm[1]), 00);

                                DateTime universal_request_time = cal_installtion_date.ToUniversalTime();
                                DateTimeOffset universal_request_time_dtoffset = DateTimeOffset.Parse(Convert.ToString(universal_request_time));
                                drProductInstallationInput["Requested_Installation_Time"] = universal_request_time_dtoffset;
                            }

                            drProductInstallationInput["Schedule_Date"] = item.Scheduled_Installation_Date;
                            drProductInstallationInput["Sechudle_start_Time"] = item.Scheduled_Installation_StartTime;
                            drProductInstallationInput["Sechudle_end_Time"] = item.Scheduled_Installation_EndTime;
                            drProductInstallationInput["Updated_By"] = user_id;

                            DT_TProductInstallation.Rows.Add(drProductInstallationInput);

                        }

                    }


                    #endregion

                    string Billing_Account_Number = _orderInfo.AccountInfo.Billing_Account_Number;
                    string Common_Order_ID = _orderInfo.AccountInfo.Common_OrderID;
                    string Fiber_OMS_Order_ID = _orderInfo.AccountInfo.Fiber_OMS_OrderID;
                    string Payment_Confirmation_Number = _orderInfo.AccountInfo.Payment_Confirmation_Number;
                    string Ticket_Number = _orderInfo.AccountInfo.Ticket_Number;
                    string Bolt_On_OrderNumber = _orderInfo.AccountInfo.Bolt_On_OrderNumber;
                    string Authentication_State = _orderInfo.VerifyInfo.Authentication_State;


                    var Authentication_ExpirationDate = _orderInfo.VerifyInfo.Authentication_ExpirationDate;

                    //Uploaded Document list--Accepted

                    var Uploaded_Document_Accepted_list = _orderInfo.DocumentList;

                    #region create table  DocumentList

                    DataTable DT_DocumentInfo = new DataTable();
                    DT_DocumentInfo.Columns.Add("Document_RowId", typeof(int));
                    DT_DocumentInfo.Columns.Add("Document_Accepted", typeof(bool));
                    DT_DocumentInfo.Columns.Add("Updated_By", typeof(string));


                    if (Uploaded_Document_Accepted_list != null && Uploaded_Document_Accepted_list.Count > 0)
                    {
                        foreach (var item in Uploaded_Document_Accepted_list)
                        {
                            DataRow drDocumentInfoInput = DT_DocumentInfo.NewRow();

                            drDocumentInfoInput["Document_RowId"] = item.Document_RowId;
                            drDocumentInfoInput["Document_Accepted"] = item.DocumentUpload_Accepted;
                            drDocumentInfoInput["Updated_By"] = user_id;
                            DT_DocumentInfo.Rows.Add(drDocumentInfoInput);

                        }

                    }


                    #endregion

                    //  Internet/VOIP/AWB/POTS Packge Info list

                    #region create table  PackageList

                    DataTable DT_ProductPackage = new DataTable();
                    DT_ProductPackage.Columns.Add("PackageRowId", typeof(int));
                    DT_ProductPackage.Columns.Add("Order_Number", typeof(string));
                    DT_ProductPackage.Columns.Add("Package_Type", typeof(string));
                    DT_ProductPackage.Columns.Add("IsProcessed", typeof(bool));
                    DT_ProductPackage.Columns.Add("AWB_Agreement_Number", typeof(string));
                    DT_ProductPackage.Columns.Add("AWB_CTN", typeof(string));
                    DT_ProductPackage.Columns.Add("Updated_By", typeof(string));

                    if (_orderInfo.PackageInfo.IsInternetPackageInformation)
                    {
                        var internet_package_list = _orderInfo.PackageInfo.InternetPackageInfo.InternetPackagelist;
                        if (internet_package_list != null && internet_package_list.Count > 0)
                        {

                            foreach (var item in internet_package_list)
                            {
                                DataRow drProductPackageInput = DT_ProductPackage.NewRow();
                                drProductPackageInput["PackageRowId"] = item.Package_RowId;
                                drProductPackageInput["Order_Number"] = _orderInfo.Order_Number;
                                drProductPackageInput["Package_Type"] = item.Package_Type;
                                drProductPackageInput["IsProcessed"] = item.Isprocessed;
                                drProductPackageInput["AWB_Agreement_Number"] = "";
                                drProductPackageInput["AWB_CTN"] = "";
                                drProductPackageInput["Updated_By"] = user_id;
                                DT_ProductPackage.Rows.Add(drProductPackageInput);
                            }
                        }

                    }
                    if (_orderInfo.PackageInfo.IsVoipPackageInformation)
                    {
                        var Voip_package_list = _orderInfo.PackageInfo.VoipPackageInfo.VoipPackagelist;
                        if (Voip_package_list != null && Voip_package_list.Count > 0)
                        {

                            foreach (var item in Voip_package_list)
                            {
                                DataRow drProductPackageInput = DT_ProductPackage.NewRow();
                                drProductPackageInput["PackageRowId"] = item.Package_RowId;
                                drProductPackageInput["Order_Number"] = _orderInfo.Order_Number;
                                drProductPackageInput["Package_Type"] = item.Package_Type;
                                drProductPackageInput["IsProcessed"] = item.Isprocessed;
                                drProductPackageInput["AWB_Agreement_Number"] = "";
                                drProductPackageInput["AWB_CTN"] = "";
                                drProductPackageInput["Updated_By"] = user_id;
                                DT_ProductPackage.Rows.Add(drProductPackageInput);
                            }
                        }

                    }
                    if (_orderInfo.PackageInfo.IsPotsPackageInformation)
                    {
                        var Pots_package_list = _orderInfo.PackageInfo.PotsPackageInfo.PotsPackagelist;
                        if (Pots_package_list != null && Pots_package_list.Count > 0)
                        {

                            foreach (var item in Pots_package_list)
                            {
                                DataRow drProductPackageInput = DT_ProductPackage.NewRow();
                                drProductPackageInput["PackageRowId"] = item.Package_RowId;
                                drProductPackageInput["Order_Number"] = _orderInfo.Order_Number;
                                drProductPackageInput["Package_Type"] = item.Package_Type;
                                drProductPackageInput["IsProcessed"] = item.Isprocessed;
                                drProductPackageInput["AWB_Agreement_Number"] = "";
                                drProductPackageInput["AWB_CTN"] = "";
                                drProductPackageInput["Updated_By"] = user_id;
                                DT_ProductPackage.Rows.Add(drProductPackageInput);
                            }
                        }

                    }
                    if (_orderInfo.PackageInfo.IsAWBPackageInformation)
                    {
                        var AWB_package_info = _orderInfo.PackageInfo.AwbPackageInformation;


                        DataRow drProductPackageInput = DT_ProductPackage.NewRow();
                        drProductPackageInput["PackageRowId"] = AWB_package_info.Package_RowId;
                        drProductPackageInput["Order_Number"] = _orderInfo.Order_Number;
                        drProductPackageInput["Package_Type"] = AWB_package_info.Package_Type;
                        drProductPackageInput["IsProcessed"] = AWB_package_info.Isprocessed;
                        drProductPackageInput["AWB_Agreement_Number"] = AWB_package_info.AWB_Agreement_Number;
                        drProductPackageInput["AWB_CTN"] = AWB_package_info.AWB_CTN;
                        drProductPackageInput["Updated_By"] = user_id;
                        DT_ProductPackage.Rows.Add(drProductPackageInput);
                    }

                    #endregion
                    string Customer_Billing_Telephone_Number = "", POTS_Order_Number = "", RDS_Ticket_Number = "";

                    if (_orderInfo.PackageInfo.IsPotsPackageInformation)
                    {

                        Customer_Billing_Telephone_Number = _orderInfo.PackageInfo.PotsPackageInfo.Customer_Billing_Telephone_Number;
                        POTS_Order_Number = _orderInfo.PackageInfo.PotsPackageInfo.POTS_Order_Number;
                        RDS_Ticket_Number = _orderInfo.PackageInfo.PotsPackageInfo.RDS_Ticket_Number;
                    }


                    string message_to_seller = string.IsNullOrEmpty(_orderInfo.Message_To_Seller) ? "" : _orderInfo.Message_To_Seller;

                    var response = _orderProcess.Insert_Order_Request(_orderInfo.TransactionId, _orderInfo.Order_Number, user_id, _orderInfo.Rep_text_Comments, _orderInfo.InternetStateId,
                      _orderInfo.InternetReasonCodeId, _orderInfo.VoipStateId, _orderInfo.VoipReasonCodeId, _orderInfo.AwsStateId, _orderInfo.AwsReasonCodeId, _orderInfo.PotsStateId, _orderInfo.PotsReasonCodeId
                      , _orderInfo.anticipatedProvisioningDate, seller_partner_agents_notes, Billing_Account_Number, Common_Order_ID, Fiber_OMS_Order_ID, Payment_Confirmation_Number, Ticket_Number
                      , Bolt_On_OrderNumber, Authentication_State, Authentication_ExpirationDate, Customer_Billing_Telephone_Number, POTS_Order_Number, RDS_Ticket_Number, DT_TProductInstallation
                      , DT_DocumentInfo, DT_ProductPackage, message_to_seller

                      );
                    List<OrderState> _allOrderstate = _orderProcess.GetOrderAllStateInformation(_orderInfo.Order_Number);

                    var Internetstate = _allOrderstate.Where(o => o.StateId == _orderInfo.InternetStateId).Select(P => new SelectListItem { Value = P.StateId.ToString(), Text = P.StateName }).ToList();
                    var Voipstate = _allOrderstate.Where(o => o.StateId == _orderInfo.VoipStateId).Select(P => new SelectListItem { Value = P.StateId.ToString(), Text = P.StateName }).ToList();
                    var Potstate = _allOrderstate.Where(o => o.StateId == _orderInfo.PotsStateId).Select(P => new SelectListItem { Value = P.StateId.ToString(), Text = P.StateName }).ToList();
                    var AWsstate = _allOrderstate.Where(o => o.StateId == _orderInfo.AwsStateId).Select(P => new SelectListItem { Value = P.StateId.ToString(), Text = P.StateName }).ToList();

                    var affiliateaccess = _affiliatereasoncode.CheckAffiliateReasonCode(_orderInfo.HearderInfo.Affiliate);

                    if (affiliateaccess != null)
                    {

                        if ((affiliateaccess.Pending) && Internetstate[0].Text.ToLower() == "Pending".ToLower() || Voipstate[0].Text.ToLower() == "Pending".ToLower() || Potstate[0].Text.ToLower() == "Pending".ToLower() || AWsstate[0].Text.ToLower() == "Pending".ToLower())
                        {
                            string stateid = "";
                            string statename = "";
                            string prdtype2 = "";
                            string ProductName2 = "";
                            string productcode1 = "";
                            string productcode2 = "";
                            string reasoncodeid = "";
                            string reasoncodename = "";
                            string stateid2 = "";
                            string statename2 = "";
                            string reasoncodeid2 = "";
                            string reasoncodename2 = "";

                            var productInformation = _iproductInformation.GetProductInformation(_orderInfo.Order_Number);
                            if (productInformation.Count > 1)
                            {
                                prdtype2 = productInformation[1].producttype;
                                ProductName2 = productInformation[1].productName;
                                productcode2 = productInformation[1].productCode;

                            }

                            EmailPendingOrderTemplate emailPendingOrderTemplate = new EmailPendingOrderTemplate();
                            string subject = EmailPendingOrderTemplate.EmailHeader(_orderInfo.HearderInfo.CustomerName);
                            string body = EmailPendingOrderTemplate.EmailBody(_orderInfo.HearderInfo.CustomerName, _orderInfo.Order_Number, _orderInfo.HearderInfo.Seller_AgentID, productInformation[0].productName, "", false, _orderInfo.HearderInfo.ServiceAddress, _orderInfo.HearderInfo.ServiceAddress);
                            _email.sendmail(_orderInfo.HearderInfo.Seller_EmailAddress, "", subject, body, "Pending", _orderInfo.HearderInfo.Seller_AgentID, _orderInfo.Order_Number);
                            NotificationUrlPending notificationUrlPending = new NotificationUrlPending();
                            string timestamp = DateTimeOffset.Now.DateTime.ToString("yyyy-MM-dd'T'HH:mm:ss'Z'");
                            var name = _orderInfo.HearderInfo.CustomerName.Split(' ');
                            string fname = "";
                            if (name.Length > 1)
                                fname = name[0];
                            else
                                fname = _orderInfo.HearderInfo.CustomerName;



                            List<StateReasonInformation> stateReasonInformation = new List<StateReasonInformation>();

                            if (Internetstate.Count > 0 && !string.IsNullOrEmpty(Internetstate[0].Text) && _orderInfo.InternetReasonCodeId != null)
                            {
                                //  prdtype1 = "INTERNET";
                                stateReasonInformation = _orderProcess.GetStateReasonInformation(Internetstate[0].Value);
                                var reasoncodenamevalue = stateReasonInformation.Where(o => o.ReasonCode == _orderInfo.InternetReasonCodeId).Select(P => new SelectListItem { Value = P.ReasonCode.ToString(), Text = P.ReasonCodeName }).ToList();
                                reasoncodeid = reasoncodenamevalue[0].Value;
                                reasoncodename = reasoncodenamevalue[0].Text;
                                stateid = Internetstate[0].Value;
                                statename = Internetstate[0].Text;


                            }
                            if (Voipstate.Count > 0 && !string.IsNullOrEmpty(Voipstate[0].Text) && (_orderInfo.VoipReasonCodeId != null))
                            {
                                stateReasonInformation = _orderProcess.GetStateReasonInformation(Voipstate[0].Value);
                                var reasoncodenamevalue = stateReasonInformation.Where(o => o.ReasonCode == _orderInfo.VoipReasonCodeId).Select(P => new SelectListItem { Value = P.ReasonCode.ToString(), Text = P.ReasonCodeName }).ToList();
                                //     reasoncodeid = reasoncodenamevalue[0].Value;
                                //   reasoncodename = reasoncodenamevalue[0].Text;
                                if (string.IsNullOrEmpty(stateid))
                                {
                                    stateid = Voipstate[0].Value;
                                    statename = Voipstate[0].Text;
                                }
                                else
                                {
                                    stateid2 = Voipstate[0].Value;
                                    statename2 = Voipstate[0].Text;
                                }

                                if (string.IsNullOrEmpty(reasoncodeid))
                                {
                                    reasoncodeid = reasoncodenamevalue[0].Value;
                                    reasoncodename = reasoncodenamevalue[0].Text;
                                }
                                else
                                {
                                    reasoncodeid2 = reasoncodenamevalue[0].Value;
                                    reasoncodename2 = reasoncodenamevalue[0].Text;
                                }
                            }
                            if (AWsstate.Count > 0 && !string.IsNullOrEmpty(AWsstate[0].Text) && _orderInfo.AwsReasonCodeId != null)
                            {
                                stateReasonInformation = _orderProcess.GetStateReasonInformation(AWsstate[0].Value);
                                var reasoncodenamevalue = stateReasonInformation.Where(o => o.ReasonCode == _orderInfo.AwsReasonCodeId).Select(P => new SelectListItem { Value = P.ReasonCode.ToString(), Text = P.ReasonCodeName }).ToList();
                                reasoncodeid = reasoncodenamevalue[0].Value;
                                reasoncodename = reasoncodenamevalue[0].Text;
                                stateid = AWsstate[0].Value;
                                statename = AWsstate[0].Text;


                            }
                            if (Potstate.Count > 0 && !string.IsNullOrEmpty(Potstate[0].Text) && _orderInfo.PotsReasonCodeId != null)
                            {
                                stateReasonInformation = _orderProcess.GetStateReasonInformation(Potstate[0].Value);
                                var reasoncodenamevalue = stateReasonInformation.Where(o => o.ReasonCode == _orderInfo.PotsReasonCodeId).Select(P => new SelectListItem { Value = P.ReasonCode.ToString(), Text = P.ReasonCodeName }).ToList();
                                reasoncodeid = reasoncodenamevalue[0].Value;
                                reasoncodename = reasoncodenamevalue[0].Text;
                                stateid = Potstate[0].Value;
                                statename = Potstate[0].Text;

                            }

                            var payload = notificationUrlPending.NotificationCancel(productInformation.Count, timestamp, _orderInfo.HearderInfo.CustomerName, fname, "Pending", true, _orderInfo.HearderInfo.Affiliate, _orderInfo.TransactionId, _orderInfo.HearderInfo.Affiliate, _orderInfo.HearderInfo.Partner, _orderInfo.AccountInfo.Billing_Account_Number, productInformation[0].productName, productInformation[0].productCode, productInformation[0].producttype, reasoncodename, reasoncodeid, statename, stateid, _orderInfo.HearderInfo.Canbereached, "", "", "", ProductName2, productcode2, prdtype2, reasoncodeid2, reasoncodename2, statename2, stateid2);

                            NotificationSend notificationSend = new NotificationSend();
                            var url = _InotificationUrl.GetNotificationUrl(_orderInfo.Order_Number);
                            notificationSend.notificationsend(payload, url.Request_Xml);
                        }



                        else if ((affiliateaccess.Canceled) && Internetstate[0].Text.ToLower() == "Canceled".ToLower() || Voipstate[0].Text.ToLower() == "Canceled".ToLower() || Potstate[0].Text.ToLower() == "Canceled".ToLower() || AWsstate[0].Text.ToLower() == "Canceled".ToLower())
                        {
                            string stateid = "";
                            string statename = "";
                            string prdtype2 = "";
                            string ProductName2 = "";
                            string productcode1 = "";
                            string productcode2 = "";
                            string reasoncodeid = "";
                            string reasoncodename = "";
                            string stateid2 = "";
                            string statename2 = "";
                            string reasoncodeid2 = "";
                            string reasoncodename2 = "";

                            var productInformation = _iproductInformation.GetProductInformation(_orderInfo.Order_Number);
                            if (productInformation.Count > 1)
                            {
                                prdtype2 = productInformation[1].producttype;
                                ProductName2 = productInformation[1].productName;
                                productcode2 = productInformation[1].productCode;

                            }


                            EmailCancel emailcancelOrderTemplate = new EmailCancel();
                            string subject = emailcancelOrderTemplate.EmailHeader(_orderInfo.HearderInfo.CustomerName);
                            string body = emailcancelOrderTemplate.EmailBody(_orderInfo.HearderInfo.CustomerName, _orderInfo.Order_Number, _orderInfo.AccountInfo.Billing_Account_Number, _orderInfo.HearderInfo.Seller_AgentID, productInformation[0].productName, _orderInfo.HearderInfo.ServiceAddress, _orderInfo.HearderInfo.ServiceAddress);
                            _email.sendmail(_orderInfo.HearderInfo.Seller_EmailAddress, "", subject, body, "Canceled", _orderInfo.HearderInfo.Seller_AgentID, _orderInfo.Order_Number);


                            string timestamp = DateTimeOffset.Now.DateTime.ToString("yyyy-MM-dd'T'HH:mm:ss'Z'");
                            var name = _orderInfo.HearderInfo.CustomerName.Split(' ');
                            string fname = "";
                            if (name.Length > 1)
                                fname = name[0];
                            else
                                fname = _orderInfo.HearderInfo.CustomerName;



                            List<StateReasonInformation> stateReasonInformation = new List<StateReasonInformation>();

                            if (Internetstate.Count > 0 && !string.IsNullOrEmpty(Internetstate[0].Text) && _orderInfo.InternetReasonCodeId != null)
                            {
                                //  prdtype1 = "INTERNET";
                                stateReasonInformation = _orderProcess.GetStateReasonInformation(Internetstate[0].Value);
                                var reasoncodenamevalue = stateReasonInformation.Where(o => o.ReasonCode == _orderInfo.InternetReasonCodeId).Select(P => new SelectListItem { Value = P.ReasonCode.ToString(), Text = P.ReasonCodeName }).ToList();
                                reasoncodeid = reasoncodenamevalue[0].Value;
                                reasoncodename = reasoncodenamevalue[0].Text;
                                stateid = Internetstate[0].Value;
                                statename = Internetstate[0].Text;


                            }
                            if (Voipstate.Count > 0 && !string.IsNullOrEmpty(Voipstate[0].Text) && _orderInfo.VoipReasonCodeId != null)
                            {
                                stateReasonInformation = _orderProcess.GetStateReasonInformation(Voipstate[0].Value);
                                var reasoncodenamevalue = stateReasonInformation.Where(o => o.ReasonCode == _orderInfo.VoipReasonCodeId).Select(P => new SelectListItem { Value = P.ReasonCode.ToString(), Text = P.ReasonCodeName }).ToList();
                                //     reasoncodeid = reasoncodenamevalue[0].Value;
                                //   reasoncodename = reasoncodenamevalue[0].Text;
                                if (string.IsNullOrEmpty(stateid))
                                {
                                    stateid = Voipstate[0].Value;
                                    statename = Voipstate[0].Text;
                                }
                                else
                                {
                                    stateid2 = Voipstate[0].Value;
                                    statename2 = Voipstate[0].Text;
                                }

                                if (string.IsNullOrEmpty(reasoncodeid))
                                {
                                    reasoncodeid = reasoncodenamevalue[0].Value;
                                    reasoncodename = reasoncodenamevalue[0].Text;
                                }
                                else
                                {
                                    reasoncodeid2 = reasoncodenamevalue[0].Value;
                                    reasoncodename2 = reasoncodenamevalue[0].Text;
                                }
                            }
                            if (AWsstate.Count > 0 && !string.IsNullOrEmpty(AWsstate[0].Text) && _orderInfo.AwsReasonCodeId != null)
                            {
                                stateReasonInformation = _orderProcess.GetStateReasonInformation(AWsstate[0].Value);
                                var reasoncodenamevalue = stateReasonInformation.Where(o => o.ReasonCode == _orderInfo.AwsReasonCodeId).Select(P => new SelectListItem { Value = P.ReasonCode.ToString(), Text = P.ReasonCodeName }).ToList();
                                reasoncodeid = reasoncodenamevalue[0].Value;
                                reasoncodename = reasoncodenamevalue[0].Text;
                                stateid = AWsstate[0].Value;
                                statename = AWsstate[0].Text;


                            }
                            if (Potstate.Count > 0 && !string.IsNullOrEmpty(Potstate[0].Text) && _orderInfo.AwsReasonCodeId != null)
                            {
                                stateReasonInformation = _orderProcess.GetStateReasonInformation(Potstate[0].Value);
                                var reasoncodenamevalue = stateReasonInformation.Where(o => o.ReasonCode == _orderInfo.AwsReasonCodeId).Select(P => new SelectListItem { Value = P.ReasonCode.ToString(), Text = P.ReasonCodeName }).ToList();
                                reasoncodeid = reasoncodenamevalue[0].Value;
                                reasoncodename = reasoncodenamevalue[0].Text;
                                stateid = Potstate[0].Value;
                                statename = Potstate[0].Text;

                            }


                            notificationcancel notificationcancel = new notificationcancel();

                            var payload = notificationcancel.NotificationCancel(productInformation.Count, timestamp, _orderInfo.HearderInfo.CustomerName, fname, "Pending", true, _orderInfo.HearderInfo.Affiliate, _orderInfo.TransactionId, _orderInfo.HearderInfo.Affiliate, _orderInfo.HearderInfo.Partner, _orderInfo.AccountInfo.Billing_Account_Number, productInformation[0].productName, productInformation[0].productCode, productInformation[0].producttype, reasoncodename, reasoncodeid, statename, stateid, _orderInfo.HearderInfo.Canbereached, "", "", "", ProductName2, productcode2, prdtype2, reasoncodeid2, reasoncodename2, statename2, stateid2);

                            NotificationSend notificationSend = new NotificationSend();
                            var url = _InotificationUrl.GetNotificationUrl(_orderInfo.Order_Number);
                            notificationSend.notificationsend(payload, url.Request_Xml);


                        }
                        else if (Internetstate[0].Text.ToLower() == "Complete".ToLower() || Voipstate[0].Text.ToLower() == "Complete".ToLower() || Potstate[0].Text.ToLower() == "Complete".ToLower() || AWsstate[0].Text.ToLower() == "Complete".ToLower())
                        {
                            string stateid = "";
                            string statename = "";
                            string prdtype2 = "";
                            string ProductName2 = "";
                            string productcode1 = "";
                            string productcode2 = "";
                            string reasoncodeid = "";
                            string reasoncodename = "";
                            string stateid2 = "";
                            string statename2 = "";
                            string reasoncodeid2 = "";
                            string reasoncodename2 = "";

                            var productInformation = _iproductInformation.GetProductInformation(_orderInfo.Order_Number);
                            if (productInformation.Count > 1)
                            {
                                prdtype2 = productInformation[1].producttype;
                                ProductName2 = productInformation[1].productName;
                                productcode2 = productInformation[1].productCode;

                            }


                            EmailOrderConfirmation emailorderconfirmation = new EmailOrderConfirmation();
                            string subject = emailorderconfirmation.EmailHeader(_orderInfo.HearderInfo.CustomerName);
                            string body = emailorderconfirmation.EmailBody(_orderInfo.HearderInfo.CustomerName, _orderInfo.Order_Number, _orderInfo.HearderInfo.Seller_AgentID, _orderInfo.PackageInfo.orderPackageinfo == null ? "" : _orderInfo.PackageInfo.orderPackageinfo.Display_Name, "", "", _orderInfo.HearderInfo.ServiceAddress, _orderInfo.HearderInfo.ServiceAddress);
                            _email.sendmail(_orderInfo.HearderInfo.Seller_EmailAddress, "", subject, body, "Complete", _orderInfo.HearderInfo.Seller_AgentID, _orderInfo.Order_Number);



                            string timestamp = DateTimeOffset.Now.DateTime.ToString("yyyy-MM-dd'T'HH:mm:ss'Z'");
                            var name = _orderInfo.HearderInfo.CustomerName.Split(' ');
                            string fname = "";
                            if (name.Length > 1)
                                fname = name[0];
                            else
                                fname = _orderInfo.HearderInfo.CustomerName;



                            List<StateReasonInformation> stateReasonInformation = new List<StateReasonInformation>();

                            if (Internetstate.Count > 0 && !string.IsNullOrEmpty(Internetstate[0].Text) && _orderInfo.InternetReasonCodeId != null)
                            {
                                //  prdtype1 = "INTERNET";
                                stateReasonInformation = _orderProcess.GetStateReasonInformation(Internetstate[0].Value);
                                var reasoncodenamevalue = stateReasonInformation.Where(o => o.ReasonCode == _orderInfo.InternetReasonCodeId).Select(P => new SelectListItem { Value = P.ReasonCode.ToString(), Text = P.ReasonCodeName }).ToList();
                                reasoncodeid = reasoncodenamevalue[0].Value;
                                reasoncodename = reasoncodenamevalue[0].Text;
                                stateid = Internetstate[0].Value;
                                statename = Internetstate[0].Text;


                            }
                            if (Voipstate.Count > 0 && !string.IsNullOrEmpty(Voipstate[0].Text) && _orderInfo.VoipReasonCodeId != null)
                            {
                                stateReasonInformation = _orderProcess.GetStateReasonInformation(Voipstate[0].Value);
                                var reasoncodenamevalue = stateReasonInformation.Where(o => o.ReasonCode == _orderInfo.VoipReasonCodeId).Select(P => new SelectListItem { Value = P.ReasonCode.ToString(), Text = P.ReasonCodeName }).ToList();
                                //     reasoncodeid = reasoncodenamevalue[0].Value;
                                //   reasoncodename = reasoncodenamevalue[0].Text;
                                if (string.IsNullOrEmpty(stateid))
                                {
                                    stateid = Voipstate[0].Value;
                                    statename = Voipstate[0].Text;
                                }
                                else
                                {
                                    stateid2 = Voipstate[0].Value;
                                    statename2 = Voipstate[0].Text;
                                }

                                if (string.IsNullOrEmpty(reasoncodeid))
                                {
                                    reasoncodeid = reasoncodenamevalue[0].Value;
                                    reasoncodename = reasoncodenamevalue[0].Text;
                                }
                                else
                                {
                                    reasoncodeid2 = reasoncodenamevalue[0].Value;
                                    reasoncodename2 = reasoncodenamevalue[0].Text;
                                }
                            }
                            if (AWsstate.Count > 0 && !string.IsNullOrEmpty(AWsstate[0].Text) && _orderInfo.AwsReasonCodeId != null)
                            {
                                stateReasonInformation = _orderProcess.GetStateReasonInformation(AWsstate[0].Value);
                                var reasoncodenamevalue = stateReasonInformation.Where(o => o.ReasonCode == _orderInfo.AwsReasonCodeId).Select(P => new SelectListItem { Value = P.ReasonCode.ToString(), Text = P.ReasonCodeName }).ToList();
                                reasoncodeid = reasoncodenamevalue[0].Value;
                                reasoncodename = reasoncodenamevalue[0].Text;
                                stateid = AWsstate[0].Value;
                                statename = AWsstate[0].Text;


                            }
                            if (Potstate.Count > 0 && !string.IsNullOrEmpty(Potstate[0].Text) && _orderInfo.PotsReasonCodeId != null)
                            {
                                stateReasonInformation = _orderProcess.GetStateReasonInformation(Potstate[0].Value);
                                var reasoncodenamevalue = stateReasonInformation.Where(o => o.ReasonCode == _orderInfo.PotsReasonCodeId).Select(P => new SelectListItem { Value = P.ReasonCode.ToString(), Text = P.ReasonCodeName }).ToList();
                                reasoncodeid = reasoncodenamevalue[0].Value;
                                reasoncodename = reasoncodenamevalue[0].Text;
                                stateid = Potstate[0].Value;
                                statename = Potstate[0].Text;

                            }


                            NotificationCompleteUrl notificationcomplete = new NotificationCompleteUrl();

                            var payload = notificationcomplete.NotificationCancel(productInformation.Count, timestamp, _orderInfo.HearderInfo.CustomerName, fname, "Pending", true, _orderInfo.HearderInfo.Affiliate, _orderInfo.TransactionId, _orderInfo.HearderInfo.Affiliate, _orderInfo.HearderInfo.Partner, _orderInfo.AccountInfo.Billing_Account_Number, productInformation[0].productName, productInformation[0].productCode, productInformation[0].producttype, reasoncodename, reasoncodeid, statename, stateid, _orderInfo.HearderInfo.Canbereached, "", "", "", ProductName2, productcode2, prdtype2, reasoncodeid2, reasoncodename2, statename2, stateid2);

                            NotificationSend notificationSend = new NotificationSend();
                            var url = _InotificationUrl.GetNotificationUrl(_orderInfo.Order_Number);
                            notificationSend.notificationsend(payload, url.Request_Xml);
                        }
                        else if ((affiliateaccess.Incomplete) && Internetstate[0].Text.ToLower() == "Incomplete".ToLower() || Voipstate[0].Text.ToLower() == "Incomplete".ToLower() || Potstate[0].Text.ToLower() == "Incomplete".ToLower() || AWsstate[0].Text.ToLower() == "Incomplete".ToLower())
                        {
                            string stateid = "";
                            string statename = "";
                            string prdtype2 = "";
                            string ProductName2 = "";
                            string productcode1 = "";
                            string productcode2 = "";
                            string reasoncodeid = "";
                            string reasoncodename = "";
                            string stateid2 = "";
                            string statename2 = "";
                            string reasoncodeid2 = "";
                            string reasoncodename2 = "";

                            var productInformation = _iproductInformation.GetProductInformation(_orderInfo.Order_Number);
                            if (productInformation.Count > 1)
                            {
                                prdtype2 = productInformation[1].producttype;
                                ProductName2 = productInformation[1].productName;
                                productcode2 = productInformation[1].productCode;

                            }
                            string timestamp = DateTimeOffset.Now.DateTime.ToString("yyyy-MM-dd'T'HH:mm:ss'Z'");
                            var name = _orderInfo.HearderInfo.CustomerName.Split(' ');
                            string fname = "";
                            if (name.Length > 1)
                                fname = name[0];
                            else
                                fname = _orderInfo.HearderInfo.CustomerName;



                            List<StateReasonInformation> stateReasonInformation = new List<StateReasonInformation>();

                            if (Internetstate != null && Internetstate.Count > 0 && !string.IsNullOrEmpty(Internetstate[0].Text) && _orderInfo.InternetReasonCodeId != null)
                            {
                                //  prdtype1 = "INTERNET";
                                stateReasonInformation = _orderProcess.GetStateReasonInformation(Internetstate[0].Value);
                                var reasoncodenamevalue = stateReasonInformation.Where(o => o.ReasonCode == _orderInfo.InternetReasonCodeId).Select(P => new SelectListItem { Value = P.ReasonCode.ToString(), Text = P.ReasonCodeName }).ToList();
                                reasoncodeid = reasoncodenamevalue[0].Value;
                                reasoncodename = reasoncodenamevalue[0].Text;
                                stateid = Internetstate[0].Value;
                                statename = Internetstate[0].Text;


                            }
                            if (Voipstate != null && Voipstate.Count > 0 && !string.IsNullOrEmpty(Voipstate[0].Text) && _orderInfo.VoipReasonCodeId != null)
                            {
                                stateReasonInformation = _orderProcess.GetStateReasonInformation(Voipstate[0].Value);
                                var reasoncodenamevalue = stateReasonInformation.Where(o => o.ReasonCode == _orderInfo.VoipReasonCodeId).Select(P => new SelectListItem { Value = P.ReasonCode.ToString(), Text = P.ReasonCodeName }).ToList();
                                //     reasoncodeid = reasoncodenamevalue[0].Value;
                                //   reasoncodename = reasoncodenamevalue[0].Text;
                                if (string.IsNullOrEmpty(stateid))
                                {
                                    stateid = Voipstate[0].Value;
                                    statename = Voipstate[0].Text;
                                }
                                else
                                {
                                    stateid2 = Voipstate[0].Value;
                                    statename2 = Voipstate[0].Text;
                                }

                                if (string.IsNullOrEmpty(reasoncodeid))
                                {
                                    reasoncodeid = reasoncodenamevalue[0].Value;
                                    reasoncodename = reasoncodenamevalue[0].Text;
                                }
                                else
                                {
                                    reasoncodeid2 = reasoncodenamevalue[0].Value;
                                    reasoncodename2 = reasoncodenamevalue[0].Text;
                                }
                            }
                            if (AWsstate != null && AWsstate.Count > 0 && !string.IsNullOrEmpty(AWsstate[0].Text) && _orderInfo.AwsReasonCodeId != null)
                            {
                                stateReasonInformation = _orderProcess.GetStateReasonInformation(AWsstate[0].Value);
                                var reasoncodenamevalue = stateReasonInformation.Where(o => o.ReasonCode == _orderInfo.AwsReasonCodeId).Select(P => new SelectListItem { Value = P.ReasonCode.ToString(), Text = P.ReasonCodeName }).ToList();
                                reasoncodeid = reasoncodenamevalue[0].Value;
                                reasoncodename = reasoncodenamevalue[0].Text;
                                stateid = AWsstate[0].Value;
                                statename = AWsstate[0].Text;


                            }
                            if (Potstate != null && Potstate.Count > 0 && !string.IsNullOrEmpty(Potstate[0].Text) && _orderInfo.PotsReasonCodeId != null)
                            {
                                stateReasonInformation = _orderProcess.GetStateReasonInformation(Potstate[0].Value);
                                var reasoncodenamevalue = stateReasonInformation.Where(o => o.ReasonCode == _orderInfo.PotsReasonCodeId).Select(P => new SelectListItem { Value = P.ReasonCode.ToString(), Text = P.ReasonCodeName }).ToList();
                                reasoncodeid = reasoncodenamevalue[0].Value;
                                reasoncodename = reasoncodenamevalue[0].Text;
                                stateid = Potstate[0].Value;
                                statename = Potstate[0].Text;

                            }


                            NotificatiourlIncomplete notificationINcomplete = new NotificatiourlIncomplete();

                            var payload = notificationINcomplete.NotificationCancel(productInformation.Count, timestamp, _orderInfo.HearderInfo.CustomerName, fname, "Pending", true, _orderInfo.HearderInfo.Affiliate, _orderInfo.TransactionId, _orderInfo.HearderInfo.Affiliate, _orderInfo.HearderInfo.Partner, _orderInfo.AccountInfo.Billing_Account_Number, productInformation[0].productName, productInformation[0].productCode, productInformation[0].producttype, reasoncodename, reasoncodeid, statename, stateid, _orderInfo.HearderInfo.Canbereached, "", "", "", ProductName2, productcode2, prdtype2, reasoncodeid2, reasoncodename2, statename2, stateid2);

                            NotificationSend notificationSend = new NotificationSend();
                            var url = _InotificationUrl.GetNotificationUrl(_orderInfo.Order_Number);
                            notificationSend.notificationsend(payload, url.Request_Xml);

                            //EmailOrderConfirmation emailorderconfirmation = new EmailOrderConfirmation();
                            //string subject = emailorderconfirmation.EmailHeader(_orderInfo.HearderInfo.CustomerName);
                            //string body = emailorderconfirmation.EmailBody(_orderInfo.HearderInfo.CustomerName, _orderInfo.Order_Number, _orderInfo.HearderInfo.Seller_AgentID, _orderInfo.PackageInfo.orderPackageinfo == null ? "" : _orderInfo.PackageInfo.orderPackageinfo.Display_Name, "", "", _orderInfo.HearderInfo.ServiceAddress, _orderInfo.HearderInfo.ServiceAddress);
                            //_email.sendmail(_orderInfo.HearderInfo.Seller_EmailAddress, "", subject, body, "Complete", _orderInfo.HearderInfo.Seller_AgentID, _orderInfo.Order_Number);

                        }
                        else if ((affiliateaccess.Submitted) && Internetstate[0].Text.ToLower() == "Submitted".ToLower() || Voipstate[0].Text.ToLower() == "Submitted".ToLower() || Potstate[0].Text.ToLower() == "Submitted".ToLower() || AWsstate[0].Text.ToLower() == "Submitted".ToLower())
                        {

                            //EmailOrderConfirmation emailorderconfirmation = new EmailOrderConfirmation();
                            //string subject = emailorderconfirmation.EmailHeader(_orderInfo.HearderInfo.CustomerName);
                            //string body = emailorderconfirmation.EmailBody(_orderInfo.HearderInfo.CustomerName, _orderInfo.Order_Number, _orderInfo.HearderInfo.Seller_AgentID, _orderInfo.PackageInfo.orderPackageinfo == null ? "" : _orderInfo.PackageInfo.orderPackageinfo.Display_Name, "", "", _orderInfo.HearderInfo.ServiceAddress, _orderInfo.HearderInfo.ServiceAddress);
                            //_email.sendmail(_orderInfo.HearderInfo.Seller_EmailAddress, "", subject, body, "Complete", _orderInfo.HearderInfo.Seller_AgentID, _orderInfo.Order_Number);

                            string stateid = "";
                            string statename = "";
                            string prdtype2 = "";
                            string ProductName2 = "";
                            string productcode1 = "";
                            string productcode2 = "";
                            string reasoncodeid = "";
                            string reasoncodename = "";
                            string stateid2 = "";
                            string statename2 = "";
                            string reasoncodeid2 = "";
                            string reasoncodename2 = "";

                            var productInformation = _iproductInformation.GetProductInformation(_orderInfo.Order_Number);
                            if (productInformation.Count > 1)
                            {
                                prdtype2 = productInformation[1].producttype;
                                ProductName2 = productInformation[1].productName;
                                productcode2 = productInformation[1].productCode;

                            }
                            string timestamp = DateTimeOffset.Now.DateTime.ToString("yyyy-MM-dd'T'HH:mm:ss'Z'");
                            var name = _orderInfo.HearderInfo.CustomerName.Split(' ');
                            string fname = "";
                            if (name.Length > 1)
                                fname = name[0];
                            else
                                fname = _orderInfo.HearderInfo.CustomerName;



                            List<StateReasonInformation> stateReasonInformation = new List<StateReasonInformation>();

                            if (!string.IsNullOrEmpty(Internetstate[0].Text) && _orderInfo.InternetReasonCodeId != null)
                            {
                                //  prdtype1 = "INTERNET";
                                stateReasonInformation = _orderProcess.GetStateReasonInformation(Internetstate[0].Value);
                                var reasoncodenamevalue = stateReasonInformation.Where(o => o.ReasonCode == _orderInfo.InternetReasonCodeId).Select(P => new SelectListItem { Value = P.ReasonCode.ToString(), Text = P.ReasonCodeName }).ToList();
                                reasoncodeid = reasoncodenamevalue[0].Value;
                                reasoncodename = reasoncodenamevalue[0].Text;
                                stateid = Internetstate[0].Value;
                                statename = Internetstate[0].Text;


                            }
                            if (Voipstate.Count > 0 && !string.IsNullOrEmpty(Voipstate[0].Text) && _orderInfo.VoipReasonCodeId != null)
                            {
                                stateReasonInformation = _orderProcess.GetStateReasonInformation(Voipstate[0].Value);
                                var reasoncodenamevalue = stateReasonInformation.Where(o => o.ReasonCode == _orderInfo.VoipReasonCodeId).Select(P => new SelectListItem { Value = P.ReasonCode.ToString(), Text = P.ReasonCodeName }).ToList();
                                //     reasoncodeid = reasoncodenamevalue[0].Value;
                                //   reasoncodename = reasoncodenamevalue[0].Text;
                                if (string.IsNullOrEmpty(stateid))
                                {
                                    stateid = Voipstate[0].Value;
                                    statename = Voipstate[0].Text;
                                }
                                else
                                {
                                    stateid2 = Voipstate[0].Value;
                                    statename2 = Voipstate[0].Text;
                                }

                                if (string.IsNullOrEmpty(reasoncodeid))
                                {
                                    reasoncodeid = reasoncodenamevalue[0].Value;
                                    reasoncodename = reasoncodenamevalue[0].Text;
                                }
                                else
                                {
                                    reasoncodeid2 = reasoncodenamevalue[0].Value;
                                    reasoncodename2 = reasoncodenamevalue[0].Text;
                                }
                            }
                            if (AWsstate.Count > 0 && !string.IsNullOrEmpty(AWsstate[0].Text) && _orderInfo.AwsReasonCodeId != null)
                            {
                                stateReasonInformation = _orderProcess.GetStateReasonInformation(AWsstate[0].Value);
                                var reasoncodenamevalue = stateReasonInformation.Where(o => o.ReasonCode == _orderInfo.AwsReasonCodeId).Select(P => new SelectListItem { Value = P.ReasonCode.ToString(), Text = P.ReasonCodeName }).ToList();
                                reasoncodeid = reasoncodenamevalue[0].Value;
                                reasoncodename = reasoncodenamevalue[0].Text;
                                stateid = AWsstate[0].Value;
                                statename = AWsstate[0].Text;


                            }
                            if (AWsstate.Count > 0 && !string.IsNullOrEmpty(Potstate[0].Text) && _orderInfo.PotsReasonCodeId != null)
                            {
                                stateReasonInformation = _orderProcess.GetStateReasonInformation(Potstate[0].Value);
                                var reasoncodenamevalue = stateReasonInformation.Where(o => o.ReasonCode == _orderInfo.PotsReasonCodeId).Select(P => new SelectListItem { Value = P.ReasonCode.ToString(), Text = P.ReasonCodeName }).ToList();
                                reasoncodeid = reasoncodenamevalue[0].Value;
                                reasoncodename = reasoncodenamevalue[0].Text;
                                stateid = Potstate[0].Value;
                                statename = Potstate[0].Text;

                            }


                            NotificationUrlSubmitted notificationsubmited = new NotificationUrlSubmitted();

                            var payload = notificationsubmited.NotificationCancel(productInformation.Count, timestamp, _orderInfo.HearderInfo.CustomerName, fname, "Pending", true, _orderInfo.HearderInfo.Affiliate, _orderInfo.TransactionId, _orderInfo.HearderInfo.Affiliate, _orderInfo.HearderInfo.Partner, _orderInfo.AccountInfo.Billing_Account_Number, productInformation[0].productName, productInformation[0].productCode, productInformation[0].producttype, reasoncodename, reasoncodeid, statename, stateid, _orderInfo.HearderInfo.Canbereached, "", "", "", ProductName2, productcode2, prdtype2, reasoncodeid2, reasoncodename2, statename2, stateid2);

                            NotificationSend notificationSend = new NotificationSend();
                            var url = _InotificationUrl.GetNotificationUrl(_orderInfo.Order_Number);
                            notificationSend.notificationsend(payload, url.Request_Xml);
                        }
                    }
                }
                catch (Exception ex)
                {
                    if (!string.IsNullOrEmpty(_orderInfo.previouspageinfo))
                    {
                        if (_orderInfo.previouspageinfo == "incomdwq")
                        {
                            return RedirectToAction("Incomplete", "DWQ");
                        }
                        else if (_orderInfo.previouspageinfo == "mlp")
                        {
                            return RedirectToAction("Index", "MLP");
                        }
                        else if (_orderInfo.previouspageinfo == "checkInstalldwq")
                        {
                            return RedirectToAction("CheckInstall", "DWQ");
                        }
                    }



                    return RedirectToAction("Index", "MLp");

                    //throw;
                }

            }


            if(!string.IsNullOrEmpty(_orderInfo.previouspageinfo))
            {
                if(_orderInfo.previouspageinfo== "incomdwq")
                {
                    return RedirectToAction("Incomplete", "DWQ");
                }
                else if (_orderInfo.previouspageinfo == "mlp")
                {
                    return RedirectToAction("Index", "MLP");
                }
                else if (_orderInfo.previouspageinfo == "checkInstalldwq")
                {
                    return RedirectToAction("CheckInstall", "DWQ");
                }
            }



            return RedirectToAction("Index", "MLp");
        }
       
        public JsonResult GetReasonCodeByStateId(string stateid)    
        {

            var lsit = _orderProcess.GetStateReasonInformation(stateid);
            return Json(lsit);
        }
        public JsonResult GetSpecialProjectActionId(string projectid)   
        {

            var lsit = _orderProcess.GetSpecialProjectActionById(projectid);
            lsit.Insert(0, new specialprojectAction { ActionId = "", SpecialProject_Action_Name = "--Select--" });
            return Json(lsit);
        }
        public JsonResult GetSpecialProjectType()   
        {
            var specialprojects = _orderProcess.GetAllSpecialProject();
           
            specialprojects.Insert(0, new specialproject { ProjectId = "", SpecialProjectName = "--Select--" });
            return Json(specialprojects);
        }
    }
}
