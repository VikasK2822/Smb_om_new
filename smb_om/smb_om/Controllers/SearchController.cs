using Microsoft.AspNetCore.Mvc;
using smb_om.Infrastructure;
using smb_om.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace smb_om.Controllers
{
    public class SearchController : Controller
    {
        readonly IQuickSearch _IQuickSearch;
        public SearchController(IQuickSearch IQuickSearch)
        {
            _IQuickSearch = IQuickSearch;
           
        }
        public IActionResult Index()
        {
            var model = _IQuickSearch.GetOrderSearchDrp();

            return View("search",model);
        }
        public IActionResult Search()
        {
            OrderQuickSearch orderQuickSearch = new OrderQuickSearch();
            DetailSearch detailSearch = new DetailSearch();
            orderQuickSearch.detailSearch = detailSearch;
            return View("search", orderQuickSearch);
        }
        public JsonResult GetReasonById(string stateid)
        {
            var model = _IQuickSearch.GetReasonById(stateid);
            //var lsit = _callTracker.GetCallDispositionById(CallReasonId);
            //lsit.Insert(0, new CallDispositionType { DispositionTypeId = "", CallDispositionName = "--Select--" });
           
            return Json(model);
        }

        [HttpPost]
        public IActionResult SearchDetails(OrderQuickSearch orderQuickSearch)
        {
            var model = _IQuickSearch.GetOrderSearchDetails(orderQuickSearch);
            var model1 = _IQuickSearch.GetOrderSearchDrp();
            model.detailSearch = model1.detailSearch;
            model.affiliates = model1.affiliates;
            model.partners = model1.partners;
            model.orderstates = model1.orderstates;
            return View("search", model);
        }

        [HttpPost]
        public IActionResult SearchCompleteDetails(OrderQuickSearch orderQuickSearch)
        {
            var model = _IQuickSearch.GetOrderCompleteSearchDetails(orderQuickSearch.detailSearch);
            var model1 = _IQuickSearch.GetOrderSearchDrp();
            model.detailSearch = model1.detailSearch;
            model.detailSearch = model1.detailSearch;
            model.affiliates = model1.affiliates;
            model.partners = model1.partners;
            model.orderstates = model1.orderstates;
            return View("search", model);
        }
    }
}
