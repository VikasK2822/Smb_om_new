using smb_om.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace smb_om.Infrastructure
{
  public  interface ICallTracker
    {

        public int InsertCallTracker(CallTrackerModel callTrackerinput, string UserId);
        public string GetRecentRequestNumber();
        public List<CallType> GetCallTypes();   
        public List<CallReasonType> GetCallReasonByCallTypId(string CallTypId);
        public List<CallDispositionType> GetCallDispositionById(string CallReasonId);

    }

}
