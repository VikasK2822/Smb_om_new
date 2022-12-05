using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace smb_om.Model
{
    public class MasterReasonCode
    {
       public List<ReasonCodeResult> reasonCodeResults { get; set; }
    }

    public class ReasonCodeResult
    {

        public string ReasonCode { get; set; }
        public string ReasonCodeName { get; set; }
        public int Row_ID { get; set; }

    }
}
