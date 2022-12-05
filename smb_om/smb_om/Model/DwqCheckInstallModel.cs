using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace smb_om.Model
{
    public class DwqCheckInstallModel
    {
        public List<Product_type> CheckInstall3DayQueue { get; set; }   
        public List<Product_type> CheckInstall2DayQueue { get; set; }
        public List<Product_type> CheckInstall1DayQueue { get; set; }

        public List<Product_type> CheckInstallDayQueue { get; set; }

        public List<Product_type> PostInstallDayQueue { get; set; }
    }
}
