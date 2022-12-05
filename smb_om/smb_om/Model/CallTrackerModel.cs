using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace smb_om.Model
{
    public class CallTrackerModel
    {
        public string RequestNumber { get; set; }
        public string CallStartTime { get; set; }
        public string CallEndTime { get; set; } 

        public string Caller_First_Name { get; set; } 
        
        public string Caller_Last_Name { get; set; }

        public string Caller_Contact_TN { get; set; }

        public string Order_Number { get; set; }    

        public string CallTypeId { get; set; }  
        public string CallReasonId { get; set; }    
        public string CallDispositionId { get; set; }

        public string Call_Comments { get; set; }

        public List<QuickSearchResult> quickSearchResults { get; set; }

        public string CBRPhoneNumber { get; set; }
        public string BillingAccountNumber { get; set; }
        public string OrderNumber { get; set; }
        public string commonOrderNumber { get; set; }
        public string quickBusinessName { get; set; }
        public bool Isordertype { get; set; }


    }
    public class CallType   
    {
        public string CallTypeId { get; set; }  
        public string CallTypeName { get; set; }    
    }
    public class CallReasonType 
    {
        public string CallReasonId { get; set; }    
        public string CallReasonName { get; set; }  
    }
    public class CallDispositionType    
    {
        public string DispositionTypeId{ get; set; }    
        public string CallDispositionName { get; set; } 
    }
}
