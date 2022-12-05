using smb_om.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace smb_om.Infrastructure
{
 public interface IHolidayCalendar
    {

        public HolidayCalendarModel GetHolidayDetails();
        public int UpdateHolidayMaster(int RowID, string HolidayName, string HolidayDate, int Isdeleted, int Isupdated);
        int InsertHolidayMaster(string HolidayName, string HolidayDate);
    }
}
