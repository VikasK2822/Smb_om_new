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
    public class OpsAdminController : Controller
    {
        readonly IOrderProcess _IOrderProcess;
        readonly IQueueSummary _IQueueSummary;
        readonly ISpecialProjectType _ISpecialProjectType;
        readonly IReasonCode _IReasonCode;
        readonly IProductReasonCode _IProductReasonCode;
        readonly ICallType _ICallType;


        public OpsAdminController(IOrderProcess IOrderProcess, IQueueSummary IqueueSummary, ISpecialProjectType IspecialProjectType, IReasonCode reasonCode, IProductReasonCode productReasonCode, ICallType ICallType)
        {
            _IOrderProcess = IOrderProcess;
            _IQueueSummary = IqueueSummary;
            _ISpecialProjectType = IspecialProjectType;
            _IReasonCode = reasonCode;
            _IProductReasonCode = productReasonCode;
            _ICallType = ICallType;
        }
        public IActionResult Index()
        {
            HttpContext.Session.Remove("Tab1CallReason");
            return View();
        }
        public IActionResult CallReason()
        {
            //var model = _ICallType.GetCalltype();
        //    var orderupdate = _ICallType.GetCalltypeReasonName(Convert.ToInt32(2));
            var model = _ICallType.GetCalltype();
          //  model.callTypeReasonNAmes = orderupdate.callTypeReasonNAmes;
            return View("CallReason", model);
          //  return View(model);
        }
        [HttpGet]
        public JsonResult CallReasonUpdate(string CallReasonID, string CallReasonName, int Isactive)
        {
            var orderupdate = _ICallType.UpdateCalltypeReasonName(Convert.ToInt32(CallReasonID), CallReasonName, Isactive);
            return Json(orderupdate);
        }
        [HttpGet]
        public JsonResult CallReasonInsert(string CallTypeID, string CallReasonName)
        {
           var v =   HttpContext.Session.GetString("UserId");

            var orderupdate = _ICallType.InsertCalltypeReasonName(Convert.ToInt32(CallTypeID), CallReasonName,1, v);
            return Json(orderupdate);
        }


        //[HttpGet]
        //public IActionResult GetCallReason(string Calltypeid)
        //{
        //    var orderupdate = _ICallType.GetCalltypeReasonName(Convert.ToInt32(Calltypeid));
        //    var model = _ICallType.GetCalltype();
        //    model.callTypeReasonNAmes = orderupdate.callTypeReasonNAmes;
        //    return View("CallReason", orderupdate);
        //}

        [HttpGet]
        public JsonResult GetCallReason(string Calltypeid)
        {
            var orderupdate = _ICallType.GetCalltypeReasonName(Convert.ToInt32(Calltypeid));
       //     var model = _ICallType.GetCalltype();
         //   model.callTypeReasonNAmes = orderupdate.callTypeReasonNAmes;
            return Json(orderupdate.callTypeReasonNAmes);
        }
        public IActionResult ReasonCode()
        {
            var result = _IReasonCode.GetReasonCode();
            return View(result);
        }

        [HttpGet]
        public JsonResult GetReasonCodeforState( string StateName)
        {
            var orderupdate = _IProductReasonCode.GetProductReasonCodeforState(StateName);
            return Json(orderupdate.reasonCodeNames);
        }
        [HttpPost]
        public IActionResult UpdateReasonCodeforState(IFormCollection keyValuePairs)
        {
            foreach (var item in keyValuePairs)
            {
                if (!item.Key.Contains("RequestVerification"))
                    _IProductReasonCode.UpdateReasonCode(Convert.ToInt32(item.Key), Convert.ToInt32( item.Value));
            }

            var model = _IProductReasonCode.GetProductReasonCode();
            return View("ProductReasonCode", model);
        }

        [HttpGet]
        public JsonResult ReasonCodeUpdate(string Rowid, string reasoncode)
        {
            var orderupdate = _IReasonCode.UpdateReasonCode(Rowid, reasoncode);
            return Json(orderupdate);
        }

        public IActionResult ProductReasonCode()
        {
            var model = _IProductReasonCode.GetProductReasonCode();
            return View(model);
        }
        public IActionResult SpecialHandleMessaging()
        {
            return View();
        }
        public IActionResult QueueSummary()
        {
             var model = _IQueueSummary.GetQueueSummary();
            return View(model);
        }
        public IActionResult UnAssign()
        {
            var lstorder = _IOrderProcess.GetNonMovableOrder();
            return View(lstorder);
        }
        [HttpGet]
        public JsonResult UnAssignOrder(string ordernumber )
        {
            var orderupdate = _IOrderProcess.UpdateUnassignOrder(ordernumber);
            return Json(orderupdate);
        }
        public IActionResult EscalationTracker()
        {
            return View();
        }
        public IActionResult SpecialProjectTracking()
        {
            var model =_ISpecialProjectType.GetPartnerAffiliate();
          //  SpecialProjectType specialProjectType = new SpecialProjectType();
            return View(model);
        }

        [HttpGet]
        public JsonResult SpecialProjectTrackingUpdate(string Rowid, string SpecialProjectType)
        {
            var orderupdate = _ISpecialProjectType.UpdateSpecialProject(Rowid, SpecialProjectType, 0, 1);
            return Json(orderupdate);
        }
        [HttpGet]
        public JsonResult SpecialProjectTrackingDelete(string Rowid, string SpecialProjectType)
        {
            var orderdelete = _ISpecialProjectType.UpdateSpecialProject(Rowid, SpecialProjectType, 1, 0);
            return Json(orderdelete);
        }
    }
}
