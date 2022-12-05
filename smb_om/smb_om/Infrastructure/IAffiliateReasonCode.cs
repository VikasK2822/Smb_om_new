using smb_om.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace smb_om.Infrastructure
{
    public interface IAffiliateReasonCode
    {
        public List<AffiliateReasonCode> GetAffiliateReasonCode();
        public int UpdateAffiliateReasoncode(string affiliatename, int cancelled, int pending, int submitted, int incomplete);
        public AffiliateReasonCode CheckAffiliateReasonCode(string affiliatename);
    }
}
