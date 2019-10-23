using IUR.Common;
using System.Web.Mvc;
using System.Web.Routing;

namespace IUR.Web.Areas.Admin.Controllers
{
    public class BaseController : Controller
    {
        public string currentUserName;
        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var session = (UserLogin)Session[CommonConstants.USER_SESSION]; // Lấy user session và ép kiểu UserLogin
            if (session == null)
            {
                TempData["isLogin"] = "";
                SetAlert("Access denied", "error");
                filterContext.Result = new RedirectToRouteResult(new
                    RouteValueDictionary(new { controller = "Login", action = "Index", Area = "Admin" }));
            }
            else
            {
                TempData["isLogin"] = "admin";
                TempData["Username"] = session.UserName;
                currentUserName = session.UserName;
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