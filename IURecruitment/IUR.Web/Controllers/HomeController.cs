using AutoMapper;
using IUR.Common;
using IUR.Controllers;
using IUR.Model.Models;
using IUR.Service;
using IUR.Web.Models;
using System.Web.Mvc;

namespace IUR.Web.Controllers
{
    public class HomeController : BaseController
    {
        private ICommonService _commonService;

        public HomeController(ICommonService commonService)
        {
            this._commonService = commonService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult HowToApply()
        {
            return View();
        }

        [ChildActionOnly]
        public ActionResult IntroText()
        {
            return PartialView();
        }

        [ChildActionOnly]
        public ActionResult Footer()
        {
            var footer = _commonService.GetFooterById(CommonConstants.MainFooterID);
            var footerVm = Mapper.Map<Footer, FooterViewModel>(footer);
            return PartialView(footerVm);
        }
    }
}