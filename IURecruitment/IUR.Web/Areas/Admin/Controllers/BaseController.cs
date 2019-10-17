using IUR.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace IUR.Web.Areas.Admin.Controllers
{
    public class BaseController : Controller
    {
        //protected override void OnActionExecuted(ActionExecutedContext filterContext)
        //{
        //    var session = (UserLogin)Session[CommonConstants.USER_SESSION]; // Lấy user session và ép kiểu UserLogin
        //    if (session == null)
        //    {
        //        // Nếu session null thì trả về trang Admin/Login/Index
        //        TempData["isLogin"] = "";
        //        filterContext.Result = new RedirectToRouteResult(new
        //            RouteValueDictionary(new { controller = "Login", action = "Index", Area = "Admin" }));
        //    }
        //    else
        //    {
        //        TempData["isLogin"] = "admin";
        //        TempData["DisplayName"] = session.UserName;
        //    }
        //    base.OnActionExecuted(filterContext);
        //}

        protected void SetAlert(string message, string type)
        {
            TempData["AlertMessage"] = message;
            if (type == "success")
            {
                TempData["AlertType"] = "alert-success";
            }
            else if (type == "error")
            {
                TempData["AlertType"] = "alert-danger";
            }
            else if (type == "warning")
            {
                TempData["AlertType"] = "alert-warning";
            }
        }
    }
}