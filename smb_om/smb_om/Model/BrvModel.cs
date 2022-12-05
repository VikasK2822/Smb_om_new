using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace smb_om.Model
{
    public class BrvModel
    {
      public List<BrvModelResult> brvModelResults { get; set; }

    }

    public class BrvModelResult
    {
        public string Affiliate { get; set; }
        public string BrvSuppress { get; set; }
        public int RowID { get; set; }

    }
}
