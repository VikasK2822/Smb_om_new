using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace smb_om.Model
{
    public class QueueSummary
    {
        public MLP MLP { get; set; }
        public Check_Install_3_Day check_Install_3_Day { get; set; }
        public Incomplete Incomplete { get; set; }
        public Check_Install_2_Day check_Install_2_Day { get; set; }
        public Check_Install_1_Day check_Install_1_Day { get; set; }
        public Check_Install_Day check_Install_Day { get; set; }
        public Post_Install_Day post_Install_Day { get; set; }
      

    }

    public class MLP
    {
        public string Queuetype { get; set; }
        public string ordercount { get; set; }
        public string MinimumDays { get; set; }

    }
    public class Check_Install_3_Day
    {
        public string Queuetype { get; set; }
        public string ordercount { get; set; }
        public string MinimumDays { get; set; }

    }
    public class Incomplete
    {
        public string Queuetype { get; set; }
        public string ordercount { get; set; }
        public string MinimumDays { get; set; }

    }
    public class Check_Install_2_Day
    {
        public string Queuetype { get; set; }
        public string ordercount { get; set; }
        public string MinimumDays { get; set; }

    }
    public class Check_Install_1_Day
    {
        public string Queuetype { get; set; }
        public string ordercount { get; set; }
        public string MinimumDays { get; set; }

    }
    public class Check_Install_Day
    {
        public string Queuetype { get; set; }
        public string ordercount { get; set; }
        public string MinimumDays { get; set; }

    }
    public class Post_Install_Day
    {
        public string Queuetype { get; set; }
        public string ordercount { get; set; }
        public string MinimumDays { get; set; }

    }
  

}
