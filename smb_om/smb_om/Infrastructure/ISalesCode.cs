using smb_om.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace smb_om.Infrastructure
{
 public  interface ISalesCode
    {
        public SalesCodeModel GetSalesCode();
        public int UpdateSalesCode(int RowID, string salescode);
        int InsertSalesCode(string affiliateName, string service_type, string salescode);
    }
}
