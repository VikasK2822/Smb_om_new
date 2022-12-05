using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace smb_om.Model
{
    public class SalesCodeModel
    {
        public List<SalesCoderesult> salesCoderesults { get; set; }
        public List<SalesCodeAffiliate> salesCodeAffiliates { get; set; }

    }

    public class SalesCoderesult
    {

        public int Row_Id { get; set; }
        public string Affiliate { get; set; }
        public string Service_Type { get; set; }
        public string SalesCode { get; set; }

    }

    public class SalesCodeAffiliate
    {
        public string AffiliateName { get; set; }
    

    }
}
