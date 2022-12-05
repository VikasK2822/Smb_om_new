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
    public class MLPController : Controller
    {

        readonly Imlp _Imlp;
        public MLPController(Imlp Imlp)
        {
            _Imlp = Imlp;
        }
        public IActionResult Index()
        {

            var model = _Imlp.GetOrderMlp();
            //if(model.product_Types[0].PartnerDaysOrder[0].PartnerText == "")
            //{
            //    MlpModel mlpModel = new MlpModel();
            //    return View("Mlp", mlpModel);
            //}
            return View("Mlp", model);
        }
       
        [HttpPost]
        public IActionResult Index(MlpModel mlpModel)
        {

            var model = mlpModel;

            return View();
        }
        
        public JsonResult GetOrderTransactionId(string product_name,string partner_name)   
        {

            var user_id = Convert.ToString(HttpContext.Session.GetString("UserId"));

            var model = _Imlp.GetSmbOrderId(product_name, partner_name, user_id);

            return Json(model);
        }
    }
}
