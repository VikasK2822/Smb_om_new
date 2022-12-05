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
    public class CallStartController : Controller
    {

        private readonly ICallTracker _callTracker;
        readonly IQuickSearch _IQuickSearch;
        public CallStartController(ICallTracker callTracker, IQuickSearch quickSearch)    
        {
            this._callTracker = callTracker;

            _IQuickSearch = quickSearch;
        }
        public IActionResult Index()
        {
            var request_number = _callTracker.GetRecentRequestNumber();
            CallTrackerModel trackerModel = new CallTrackerModel();
            trackerModel.RequestNumber = request_number;
            trackerModel.CallStartTime = DateTime.UtcNow.ToString();
            return View(trackerModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(CallTrackerModel callTrackerModel)
        {
            var user_id = Convert.ToString(HttpContext.Session.GetString("UserId"));
           int recordaffected= _callTracker.InsertCallTracker(callTrackerModel, user_id);

            return RedirectToAction("Index", "MLP");
        }
        public JsonResult GetCallTypes()    
        {
            var callTypes = _callTracker.GetCallTypes();
            callTypes.Insert(0, new CallType { CallTypeId = "", CallTypeName = "--Select--" });
            return Json(callTypes);
        }
        public JsonResult GetCallReasonByCallTypId(string CallTypId)    
        {
            var lsit = _callTracker.GetCallReasonByCallTypId(CallTypId);
            lsit.Insert(0, new CallReasonType { CallReasonId = "", CallReasonName = "--Select--" });

            return Json(lsit);
        }
        public JsonResult GetCallDispositionById(string CallReasonId)        
        {

            var lsit = _callTracker.GetCallDispositionById(CallReasonId);
            lsit.Insert(0, new CallDispositionType { DispositionTypeId="", CallDispositionName= "--Select--" });
            return Json(lsit);
        }


        [HttpPost]
        public IActionResult SearchDetails(OrderQuickSearch orderQuickSearch)
        {
            var request_number = _callTracker.GetRecentRequestNumber();
            CallTrackerModel trackerModel = new CallTrackerModel();
            trackerModel.RequestNumber = request_number;
            trackerModel.CallStartTime = DateTime.UtcNow.ToString();
            var model = _IQuickSearch.GetOrderSearchDetails(orderQuickSearch);
            trackerModel.quickSearchResults = model.quickSearchResults;
            return View("Index", trackerModel);
        }

    }
}
