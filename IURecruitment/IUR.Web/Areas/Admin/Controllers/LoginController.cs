using IUR.Common;
using IUR.Web.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IUR.Web.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        //public ActionResult Login(LoginViewModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var dao = new UserDao();

        //        var result = dao.Login(model.UserName, Encryptor.MD5Hash(model.Password)); ; // kiểm tra username và password
        //        if (result != null)
        //        {
        //            var user = dao.GetUserByUsername(model.UserName); // lấy user trong database theo ID
        //            var userSession = new UserLogin();  // tạo user session
        //            userSession.UserID = user.ID; // gán userID vào session
        //            userSession.UserName = user.Username; // gán username vào session                    
        //            Session.Add(CommonConstants.USER_SESSION, userSession);
        //            TempData["isLogin"] = "admin";
        //            TempData["DisplayName"] = userSession.UserName;
        //            return RedirectToAction("Index", "Home", new { area = "" });
        //        }
        //        else
        //        {
        //            ModelState.AddModelError("", "Đăng nhập không đúng.");
        //        }
        //    }
        //    return View("Index");
        //}

        public ActionResult Logout()
        {
            Session.Remove(CommonConstants.USER_SESSION);
            TempData["isLogin"] = "";
            return RedirectToAction("Index", "Home", new { area = "" });
        }
    }
}