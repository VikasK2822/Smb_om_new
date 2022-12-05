using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace smb_om.Model
{
    public class HolidayCalendarModel
    {
        public List<HolidayCalendarResult> holidayCalendarResults {get; set;}

    }

    public class HolidayCalendarResult
    {

        public string HolidayName { get; set; }
        public string HolidayDate { get; set; }
        public int RowID { get; set; }


    }
}
