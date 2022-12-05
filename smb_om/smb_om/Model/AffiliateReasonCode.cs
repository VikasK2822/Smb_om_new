using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace smb_om.Model
{
    public class AffiliateReasonCode
    {
        public  int RowID { get; set; } 
        public string AffiliateName { get; set; }
        public bool Canceled { get; set; }
        public bool Incomplete { get; set; }
        public bool Pending { get; set; }
        public bool Submitted { get; set; }
       // public string AffiliateName { get; set; }

    }
}
