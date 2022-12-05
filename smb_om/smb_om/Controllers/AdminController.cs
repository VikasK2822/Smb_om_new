using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using smb_om.Infrastructure;
using smb_om.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace smb_om.Controllers
{
    public class AdminController : Controller
    {
        readonly IAffiliate _Iaffiliate;
        readonly Iviewlog _Iviewlog;
        readonly IHolidayCalendar _IIHolidayCalendar;
        readonly ISalesCode _ISalesCode;
        readonly IBrv _Ibrv;
        readonly IAffiliateReasonCode _IaffiliateReasonCode;





        public AdminController(IAffiliate Iaffiliate, Iviewlog iviewlog, IHolidayCalendar  holidayCalendar, ISalesCode salesCode, IBrv brv,IAffiliateReasonCode IaffiliateReasonCode)
        {
            _Iaffiliate = Iaffiliate;
            _Iviewlog = iviewlog;
            _IIHolidayCalendar = holidayCalendar;
            _ISalesCode = salesCode;
            _Ibrv = brv;
            _IaffiliateReasonCode = IaffiliateReasonCode;

        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult PartnerOnboarding()
        {
            var model = _Iaffiliate.GetPartnerAffiliate();
            return View("PartnerOnboarding", model);
        }
        public IActionResult AffiliateBrv()
        {
            var model = _Ibrv.GetBrvsuppress();
            return View(model);
        }
        [HttpPost]
        public IActionResult AffiliateBrvInsert(IFormCollection keyValuePairs)
        {
            foreach (var item in keyValuePairs)
            {
               if(!item.Key.Contains("RequestVerification"))
                _Ibrv.UpdateBrvAffiliate(Convert.ToInt32(item.Key), item.Value);
            }
            var model = _Ibrv.GetBrvsuppress();
            return View("AffiliateBrv", model);
        }
        public IActionResult AffiliateOsn()
        {
            var model = _IaffiliateReasonCode.GetAffiliateReasonCode();
            return View(model);
        }
        [HttpPost]
        public IActionResult AffiliateOsnUpdate(List<AffiliateReasonCode> affiliateReasonCodes)
        {

            foreach (var item in affiliateReasonCodes)
            {
                _IaffiliateReasonCode.UpdateAffiliateReasoncode(item.AffiliateName, Convert.ToInt32(item.Canceled), Convert.ToInt32(item.Pending), Convert.ToInt32(item.Submitted), Convert.ToInt32(item.Incomplete));
            }
            
            var model = _IaffiliateReasonCode.GetAffiliateReasonCode();


            return View("AffiliateOsn", model);
        }
        public IActionResult ViewLog()
        {
            List<ViewLog> viewLogs = null;
            return View("ViewLog", viewLogs);
        }

        public IActionResult ViewLogdata(List<ViewLog> viewLogs)
        {
            return View("ViewLog", viewLogs);
        }
        [HttpGet]
        public JsonResult GetLog(string ordernumber)
        {
            var v = _Iviewlog.GetViewLog(ordernumber);
            return Json(v);
            //return RedirectToAction("ViewLogdata", v);
        }

        public IActionResult SalesCode()
        {
            var model = _ISalesCode.GetSalesCode();
            return View(model);
        }

        [HttpGet]
        public JsonResult SalesCodeUpdate(string Rowid, string Salescode)
        {
            var orderupdate = _ISalesCode.UpdateSalesCode(Convert.ToInt32(Rowid),Salescode );
            return Json(orderupdate);
        }

        [HttpGet]
        public JsonResult InsertSalesCode(string affiliateName, string Servicetype, string salescode)
        {
            var orderupdate = _ISalesCode.InsertSalesCode(affiliateName, Servicetype, salescode);
            return Json(orderupdate);
        }


        public IActionResult HolidaySchedule()
        {
            var model = _IIHolidayCalendar.GetHolidayDetails();
            return View(model);
        }


        [HttpGet]
        public JsonResult HolidayScheduleUpdate(string Rowid, string HolidayName, string HolidayDate)
        {
            var orderupdate = _IIHolidayCalendar.UpdateHolidayMaster(Convert.ToInt32(Rowid), HolidayName,HolidayDate,0,1);
            return Json(orderupdate);
        }
        [HttpGet]
        public JsonResult HolidayScheduleDelete(string Rowid, string HolidayName, string HolidayDate)
        {
            var orderupdate = _IIHolidayCalendar.UpdateHolidayMaster(Convert.ToInt32(Rowid), HolidayName, HolidayDate, 1, 0);
            return Json(orderupdate);
        }
        [HttpGet]
        public JsonResult InsertSchedule(string HolidayName, string HolidayDate)
        {
            var orderupdate = _IIHolidayCalendar.InsertHolidayMaster(HolidayName, HolidayDate);
            return Json(orderupdate);
        }
    }
}
