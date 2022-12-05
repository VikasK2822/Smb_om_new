using smb_om.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace smb_om.Infrastructure
{
    public interface IDwqIncomplete
    {
        public DqwIncompleteModel GetIncompleteQueueOrder();    
        
        public string GetDwqInCompleteOrderId(string ProductType, string PartnerName, string reasoncodeName, string user_id);
    }
}
