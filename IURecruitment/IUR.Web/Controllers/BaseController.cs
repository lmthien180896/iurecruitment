using IUR.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace IUR.Controllers
{
    public class BaseController : Controller
    {
        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var session = (UserLogin)Session[CommonConstants.USER_SESSION]; // Lấy user session và ép kiểu UserLogin
            if (session == null)
            {            
                TempData["isLogin"] = "";
            }
            else
            {
                TempData["isLogin"] = "admin";
                TempData["Username"] = session.UserName;
            }
            base.OnActionExecuted(filterContext);
        }

        protected void SetAlert(string message, string type)
        {
            TempData["AlertMessage"] = message;
            TempData["AlertType"] = type;          
        }
    }
}