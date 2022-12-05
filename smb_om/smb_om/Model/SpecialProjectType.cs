using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace smb_om.Model
{
    public class SpecialProjectType
    {
        public List<specialprojectN> specialprojectNs { get; set; }
    }

    public class specialprojectN
    {

        public string specialProjectName { get; set; }
        public int Rowid { get; set; }

    }
}
