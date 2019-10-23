using AutoMapper;
using IUR.Common;
using IUR.Model.Models;
using IUR.Service;
using IUR.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace IUR.Web.Areas.Admin.Controllers
{
    public class CommonController : BaseController
    {
        ICommonService _commonService;

        public CommonController(ICommonService commonService)
        {
            this._commonService = commonService;
        }

        public ActionResult Footer()
        {
            var footer = _commonService.GetFooterById(CommonConstants.MainFooterID);
            var footerVm = Mapper.Map<Footer, FooterViewModel>(footer);
            return View(footerVm);
        }

        [HttpPost]
        [ValidateInput(false)]
        public JsonResult SaveFooter(string model)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            var footerVm = serializer.Deserialize<FooterViewModel>(model);
            var footer = _commonService.GetFooterById(footerVm.ID);
            footer.Content = footerVm.Content;
            footer.UpdatedDate = DateTime.Now;
            footer.UpdatedBy = currentUserName;
            TryValidateModel(footer);
            if (ModelState.IsValid)
            {
                _commonService.Update(footer);
                _commonService.SaveChanges();
                SetAlert("Update footer successfully", "success");
                return Json(new
                {
                    status = true                    
                });
            }
            else
            {
                return Json(new
                {
                    status = true,
                    message = "ModelState is not valid"
                });
            }           
        }
    }
}