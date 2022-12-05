using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace smb_om.Model
{
    public class ProductReasonCode
    {
        public List<stateName> stateNames { get; set; }
        public List<ReasonCodeName> reasonCodeNames { get; set; }
    }

    public class stateName
    {
        public string statename { get; set; }

    }

    public class ReasonCodeName
    {
        public string ReasonCode { get; set; }
        public int statetId { get; set; }
        public int RowId { get; set; }
        public int FG_Flag { get; set; }
        public string ISchecked { get; set; }

    }
}
