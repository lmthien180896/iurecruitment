using IUR.Common;
using IUR.Service;
using IUR.Web.Areas.Admin.Models;
using System.Web.Mvc;

namespace IUR.Web.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        protected void SetAlert(string message, string type)
        {
            TempData["AlertMessage"] = message;
            TempData["AlertType"] = type;
        }

        private IUserService _userService;

        public LoginController(IUserService userService)
        {
            this._userService = userService;
        }

        public ActionResult Index()
        {
            TempData["isLogin"] = "";
            return View();
        }

        public ActionResult Login(LoginViewModel model)
        {
            model.HashedPassword = Encryptor.MD5Hash(model.HashedPassword);
            var userId = _userService.CheckLogin(model.UserName, model.HashedPassword);
            if (userId > 0)
            {
                var user = _userService.GetById(userId);
                if (user.Status)
                {
                    var userSession = new UserLogin();  // tạo user session
                    userSession.UserID = user.ID; // gán userID vào session
                    userSession.UserName = user.Username; // gán username vào session
                    Session.Add(CommonConstants.USER_SESSION, userSession);
                    TempData["isLogin"] = "admin";
                    TempData["DisplayName"] = userSession.UserName;
                    return RedirectToAction("Index", "Home", new { area = "" });
                }
                else
                {
                    SetAlert("This account has been disabled", "error");
                }
            }
            else
            {
                SetAlert("Authentication is invalid", "error");
            }
            return View("Index");
        }

        public ActionResult Logout()
        {
            Session.Remove(CommonConstants.USER_SESSION);
            TempData["isLogin"] = "";
            return RedirectToAction("Index", "Home", new { area = "" });
        }
    }
}