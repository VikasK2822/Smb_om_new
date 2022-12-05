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
    public class DwqController : Controller
    {

        private readonly IDwqIncomplete _dwqIncomplete;
        private readonly IDwqCheckInstall _dwqCheckInstall; 
        public DwqController(IDwqIncomplete dwqIncomplete, IDwqCheckInstall dwqCheckInstall)  
        {
            this._dwqIncomplete = dwqIncomplete;
            this._dwqCheckInstall = dwqCheckInstall;

        }
        public IActionResult Index()
        {

            return View();
        }

        public IActionResult Incomplete()
        {
            DqwIncompleteModel incompleteModel = new DqwIncompleteModel();
            incompleteModel = _dwqIncomplete.GetIncompleteQueueOrder();
            return View(incompleteModel);
        }
        public JsonResult GetInCompleteOrderId(string productType, string partnerName,string reasoncodeName)    
        {   
            var user_id = Convert.ToString(HttpContext.Session.GetString("UserId"));

            var model = _dwqIncomplete.GetDwqInCompleteOrderId(productType, partnerName, reasoncodeName, user_id);

            return Json(model);
        }
        public IActionResult CheckInstall()
        {
            DwqCheckInstallModel dwqCheckInstallobj = new DwqCheckInstallModel();
            dwqCheckInstallobj = _dwqCheckInstall.GetCheckInstallQueueOrder();
            return View(dwqCheckInstallobj);
        }
        public JsonResult GetCheckInstallOrderId(string productType, string partnerName, string queueName)  
        {
            var user_id = Convert.ToString(HttpContext.Session.GetString("UserId"));

            var model = _dwqCheckInstall.GetDwqCheckInstallOrderId(productType, partnerName, queueName, user_id);

            return Json(model);
        }
    }
}
