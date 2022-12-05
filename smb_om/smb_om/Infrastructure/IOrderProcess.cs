using smb_om.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace smb_om.Infrastructure
{
   public interface IOrderProcess
    {
        public OrderInformation GetOrderInformation(string Order_Number);
        public List<OrderState> GetOrderAllStateInformation(string Order_Number);   
        public List<StateReasonInformation> GetStateReasonInformation(string stateid);

        public List<specialproject> GetAllSpecialProject();       

        public List<specialprojectAction> GetSpecialProjectActionById(string ProjectId);
        public string Insert_Order_Request(string transactionid, string ordernumber, string UserId, string repComments, int? InternetStateId, int? InternetReasonCodeId
          , int? VoipStateId, int? VoipReasonCodeId, int? AwsStateId, int? AwsReasonCodeId, int? PotsStateId, int? PotsReasonCodeId, DateTime Anticipated_Provisioning_Date
         ,string Partner_AgentNotes,string Billing_Account_Number,string Common_OrderID,string Fiber_OMS_OrderID,string Payment_Confirmation_Number,string Ticket_Number
        , string Bolt_On_OrderNumber,string Authentication_State,DateTimeOffset Authentication_ExpirationDate,string Customer_Billing_Telephone_Number,string POTS_Order_Number
        , string RDS_Ticket_Number, DataTable Dt_ProductsInstallation,DataTable Dt_OrderDocument,DataTable Dt_ProductPackage,string Message_To_Seller
            );

        public List<UnassignedOrder> GetNonMovableOrder();
        public int UpdateUnassignOrder(string OrderNumber);
    }
}   
