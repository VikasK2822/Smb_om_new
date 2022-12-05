using smb_om.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace smb_om.Infrastructure
{
  public  interface ISpecialProjectType
    {
        public SpecialProjectType GetPartnerAffiliate();
        public int UpdateSpecialProject(string Rowid, string SpecialProjectType, int Isdelete, int IsUpdate);
    }
}
