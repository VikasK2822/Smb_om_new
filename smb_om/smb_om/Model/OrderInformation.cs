using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace smb_om.Model
{
    public class OrderInformation
    {
        public string Order_Number { get; set; }
        public string TransactionId { get; set; }

        public OrderHearderInfo HearderInfo { get; set; }
        public Account AccountInfo { get; set; }
        public List<ProductInstallationInfo> ProductInstallationList { get; set; }  
        public Verify VerifyInfo { get; set; }
        public List<OrderDocument> DocumentList { get; set; }   
        public Payment PaymentInfo { get; set; }
        public BusinessDetails BusinessInfo { get; set; }
        public Address ServiceAddressInfo { get; set; } 
        public Address BillingAddressInfo { get; set; }
        public PackageInformation PackageInfo { get; set; }
        public List<RepNotesHistory> RepCommentsHistory { get; set; }
        public List<RepNotesHistory> SystemNotes { get; set; }
        public string Rep_text_Comments { get; set; }   
        public string Message_To_Seller { get; set; }

        [DataType(DataType.Date)]
        public DateTime anticipatedProvisioningDate { get; set; }

        public List<SelectListItem> InternetState { get; set; }
        public bool IsInternetState { get; set; }
        public int ? InternetStateId { get; set; }
        public int ? InternetReasonCodeId { get; set; }    

        
        public List<SelectListItem> VoipState { get; set; }
        public bool IsVoipState { get; set; }
        public int ? VoipStateId { get; set; }
        public int ? VoipReasonCodeId { get; set; }
       
        public List<SelectListItem> AwsState { get; set; }
        public bool IsAwsState { get; set; }
        public int ? AwsStateId { get; set; } 
        public int? AwsReasonCodeId { get; set; }    

        public List<SelectListItem> PotsState { get; set; }
        public bool IsPotsState { get; set; }

        public int ? PotsStateId { get; set; }
        public int ? PotsReasonCodeId { get; set; }

        public List<SelectListItem> SpecialProjectType { get; set; }

        public int? SpecialProjectTypeId { get; set; }

        public int? SpecialProjectActioneId { get; set; }

        public List<specialprojectInfo> specialprojects { get; set; }

        public string previouspageinfo { get; set; }    
    }
    public class OrderHearderInfo
    {
        public string BAN { get; set; }
       
      //  public DateTimeOffset Order_Create_Date { get; set; }
        public string Order_Create_Date { get; set; }
        public string UVSalesCode { get; set; }
        public string CustomerName { get; set; }
        public string UserId { get; set; }
        public string ServiceAddress { get; set; }
        public string OrderType { get; set; }
        public string Partner { get; set; }
        public string Affiliate { get; set; }
        public string CommonOrderId { get; set; }
        public string Canbereached { get; set; }
        public string Seller_Name { get; set; }
        public string Seller_PhoneNumber { get; set; }
        public string Seller_AgentID { get; set; }
        public string Seller_EmailAddress { get; set; }
        public string Seller_Contact_Phone_Number { get; set; }
        public string Seller_Preferred_Contact_Method { get; set; }

        public string Seller_Linkedorder { get; set; }

        public string Seller_Partner_Agent_Notes { get; set; }

       

    }

    public class Account    
    {
      
        public string Billing_Account_Number { get; set; }  
        public string Common_OrderID { get; set; }
        public string Fiber_OMS_OrderID { get; set; }   
        public string Payment_Confirmation_Number { get; set; }

        public string Ticket_Number { get; set; }

        public string Bolt_On_OrderNumber { get; set; }

        public string Unified_Credit_TransactionID { get; set; }
        public string Credit_Class { get; set; }

        public string Bureau_Name_Abbreviation { get; set; }    



    }
    public class ProductInstallationInfo
    {
        public int  Product_RowId { get; set; } 
        public string Product_Type { get; set; }    
        public DateTimeOffset Requested_Installation_Date { get; set; }
        public DateTimeOffset Requested_Installation_DB_Input_time { get; set; }
        public string Requested_Installation_Time { get; set; }
        public DateTimeOffset Scheduled_Installation_Date { get; set; }
        public string Scheduled_Installation_StartTime { get; set; }
        public string Scheduled_Installation_EndTime { get; set; }


    }
public class Verify 
    {
        public Address BillingAddress { get; set; }
        public DateTimeOffset Authentication_DOB { get; set; }
        public string Authentication_SSN { get; set; }  
        public string Authentication_FederalTaxID { get; set; }
        public string Authentication_DriversLicense { get; set; }
        public string Authentication_State { get; set; }
        public DateTimeOffset Authentication_ExpirationDate { get; set; }
        public string Authentication_Officer1SSN { get; set; }
        public string Authentication_Officer2SSN { get; set; }
        public string SecurityVerificationn_PIN { get; set; }
        public string SecurityVerificationn_Securit_Question { get; set; }  
        public string SecurityVerificationn_Security_Answer { get; set; }   

    }
    public class OrderDocument  
    {
        public int Document_RowId { get; set; } 
        public string DocumentName { get; set; }    
        public string DocumentType { get; set; }
        public string UserID { get; set; }
        public DateTimeOffset DocumentUpload_TimeStamp { get; set; }
        public bool DocumentUpload_Accepted { get; set; }
        public string DocumentPath { get; set; }   
        
    }
    public class Payment  
    {
      
        public string Payment_Type { get; set; }
        public string Amount { get; set; }
        public string DisclosureAccepted { get; set; }
        public string CreditCardType { get; set; }
        public string CreditCardNumber { get; set; }
        public string CardBillingZip { get; set; }
        public string CreditCardName { get; set; }
        public string AuthorizationNumber { get; set; }
        public string ExpirationDate { get; set; }
        public DateTimeOffset DB_ExpirationDate { get; set; }   
    }
    public class BusinessDetails    
    {
        public string BusinessName { get; set; }
        public string BusinessType { get; set; }
        public string FederalTaxID { get; set; }    
        public string DateOfIncorporation { get; set; } 
        public string StateOfIncorporation { get; set; }    
        public string Officer1_First_Name { get; set; } 
        public string Officer1_Last_Name { get; set; }
        public string Officer1_Phone_Number { get; set; }
        public string Officer1_Email_Address { get; set; }
    }
    public class Address
    {
        public string AddressType { get; set; }
        public string Street_Number_Prefix { get; set; }
        public string Street_Number { get; set; }
        public string Street_Number_Suffix { get; set; }
        public string Street_Direction { get; set; }
        public string Street_Name { get; set; }
        public string Street_Type { get; set; }
        public string Street_Trailing_Direction { get; set; }
        public string Assigned_Street_Number { get; set; }
        public string Structure_Type { get; set; }
        public string Structure_Value { get; set; }
        public string Level_Type { get; set; }
        public string Level_Value { get; set; }
        public string Apartment_Type { get; set; }
        public string Apartment_Value { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Country { get; set; }
        public string Post_Office_Box { get; set; }
        public string Rural_Route_Box_Ctr_Number { get; set; }
        public string Urbanization_Code { get; set; }
        public string Address_Ticket { get; set; }


    }
    public class PackageInformation  
    {
        public OrderPackageInformation orderPackageinfo { get; set; }

        public InternetPackage InternetPackageInfo   { get; set; }
        public VoipPackage VoipPackageInfo { get; set; }
        public AwbPackageInformation AwbPackageInformation { get; set; }

        public PotsPackage PotsPackageInfo { get; set; }    

        public bool  IsInternetPackageInformation { get; set; } 
        public bool IsVoipPackageInformation { get; set; }      
        public bool IsAWBPackageInformation { get; set; }
        public bool IsPotsPackageInformation { get; set; }  

    }
    public class OrderPackageInformation      
    {
        
        public string Display_Name { get; set; }    
        public string USOC { get; set; }    
        public string Price { get; set; }   
        public string Activation_Fee { get; set; }
       
    }
    public class InternetPackage    
    {
        public List<ProductPackageInformation> InternetPackagelist { get; set; }
        public bool IsPromoPackageInformation { get; set; }
        public List<PromoPackageInformation> promoPackageInformation { get; set; }
    }
    public class VoipPackage       
    {
        public List<ProductPackageInformation> VoipPackagelist { get; set; }
        public bool IsPromoPackageInformation { get; set; }
        public List<PromoPackageInformation> promoPackageInformation { get; set; }  
    }
    public class ProductPackageInformation
    {   
        public int Package_RowId { get; set; }
        public string Display_Name { get; set; }
        public string Package_Type { get; set; }    
        public string Order_Number { get; set; }    
        public bool Isprocessed { get; set; }   
        public string Price { get; set; }
        public string Text_Answer { get; set; }

    }
    public class PromoPackageInformation    
    {
        public int Package_RowId { get; set; }
        public string Display_Name { get; set; }
        public string USOC { get; set; }    
        public string Price { get; set; }
        public string Action { get; set; }

    }
    public class AwbPackageInformation  
    {
        public int Package_RowId { get; set; }

        public string Package_Type { get; set; }
        public string Order_Number { get; set; }

        public bool Isprocessed { get; set; }
        public string AWB_Agreement_Number { get; set; }
        public string AWB_CTN { get; set; } 
    }

    public class PotsPackage    
    {
        public List<ProductPackageInformation> PotsPackagelist { get; set; }
        public string POTS_Order_Number { get; set; }   
        public string Customer_Billing_Telephone_Number { get; set; }
        public string RDS_Ticket_Number { get; set; }   

    }

    public class RepNotesHistory    
    {
        public string Rep_TimeStamp { get; set; }
        public string Rep_ID { get; set; } 
        public string Rep_Display_Response { get; set; }
        public string Comments { get; set; }

    }

    public class OrderState 
    {
        public int CategoryId { get; set; }

        public string CategoryName { get; set; }    

        public int StateId { get; set; }    

        public string StateName { get; set; }  

    }
    public class StateReasonInformation 
    {
        
        public int StateId { get; set; }
        public int ReasonCode { get; set; }
        public string ReasonCodeName { get; set; }

    }
    public class ProductState   
    {
        public string Cat_StateId { get; set; } 

        public string StateName { get; set; }

    }
   
    public class specialproject  
    {
        public string  ProjectId { get; set; }   

        public string SpecialProjectName { get; set; }      

    }
    public class specialprojectAction   
    {
        public string ActionId { get; set; }

        public string SpecialProject_Action_Name { get; set; }  


    }
    public class specialprojectInfo 
    {
        public string ProjectId { get; set; }

        public string Project_Action_Id { get; set; }       


    }

}
   
