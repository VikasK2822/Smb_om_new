using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace smb_om.Model
{
    public class CallTypeModel
    {
       public List<CallTypeReason> callTypeReasons { get; set; }

        public List<CallTypeReasonNAme> callTypeReasonNAmes {get; set;}

    }
    public class CallTypeReasonNAme
    {
        public int CallReasonId { get; set; }
        public string CallReasonName { get; set; }
        public bool CallReasonIsActive { get; set; }


    }

    public class CallTypeReason
    {
        public int CallType { get; set; }
        public string CallTypeName { get; set; }
    }
}
