using AutoMapper;
using IUR.Common;
using IUR.Model.Models;
using IUR.Service;
using IUR.Web.Areas.Admin.Models;
using IUR.Web.Infrastructure.Extensions;
using IUR.Web.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace IUR.Web.Areas.Admin.Controllers
{
    public class UserController : BaseController
    {
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            this._userService = userService;
        }

        public ActionResult ChangePasswordView(string username)
        {
            var currentUser = _userService.GetByUsername(username);
            ViewBag.UserID = currentUser.ID;
            return View();
        }

        [HttpPost]
        public JsonResult ChangePassword(string model)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            ChangePasswordViewModel changePasswordVm = serializer.Deserialize<ChangePasswordViewModel>(model);
            var currentPassword = Encryptor.MD5Hash(changePasswordVm.CurrentPassword);
            var currentUser = _userService.GetById(changePasswordVm.ID);
            if (currentUser.HashedPassword == currentPassword)
            {
                if (changePasswordVm.NewPassword == changePasswordVm.ConfirmedPassword)
                {
                    currentUser.HashedPassword = Encryptor.MD5Hash(changePasswordVm.NewPassword);
                    _userService.Update(currentUser);
                    _userService.SaveChanges();
                    return Json(new
                    {
                        status = true,
                        message = "Change password successfully"
                    });
                }
                else
                {
                    return Json(new
                    {
                        status = false,
                        message = "Change password failed"
                    });
                }
            }
            else
            {
                return Json(new
                {
                    status = false,
                    message = "Password is incorrected"
                });
            }
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult LoadUsers()
        {
            var listUser = _userService.GetAll();
            var listUserVm = Mapper.Map<IEnumerable<User>, IEnumerable<UserViewModel>>(listUser);
            foreach (var user in listUserVm)
            {
                user.CreatedDateToString = user.CreatedDate.Value.ToString("dd/MM/yyyy");
            }
            return Json(new
            {
                data = listUserVm,
                status = true
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Create(string model)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            UserViewModel userVm = serializer.Deserialize<UserViewModel>(model);
            userVm.HashedPassword = Encryptor.MD5Hash(userVm.HashedPassword);
            userVm.CreatedDate = DateTime.Now;
            userVm.CreatedBy = currentUserName;
            var isExisted = _userService.CheckUsername(userVm.Username);
            if (isExisted)
            {
                return Json(new
                {
                    status = false,
                    message = "Username is already used"
                });
            }
            User user = new User();
            user.UpdateUser(userVm);
            TryValidateModel(user);
            if (ModelState.IsValid)
            {
                var newUser = _userService.Add(user);
                _userService.SaveChanges();
                return Json(new
                {
                    status = true,
                    message = "Create " + newUser.Username + " successfully"
                });
            }
            else
            {
                return Json(new
                {
                    status = false,
                    message = "ModelState is not valid"
                });
            }
        }

        [HttpPost]
        public JsonResult Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return Json(new
                {
                    status = false
                });
            }
            else
            {
                var user = _userService.Delete(id);
                _userService.SaveChanges();
                return Json(new
                {
                    message = "Delete " + user.Username + " successfully",
                    status = true
                });
            }
        }

        [HttpPost]
        public JsonResult DeleteAll(string listId)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            var Ids = serializer.Deserialize<string>(listId);
            int countDelete = 0;
            foreach (var id in Ids.Split('-'))
            {
                if (!string.IsNullOrEmpty(id))
                {
                    _userService.Delete(int.Parse(id));
                    countDelete++;
                }
            }
            _userService.SaveChanges();
            return Json(new
            {
                message = "Delete " + countDelete + " users successfully",
                status = true
            });
        }

        [HttpPost]
        public JsonResult UpdatePhone(string model)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            UserViewModel userVm = serializer.Deserialize<UserViewModel>(model);

            var user = _userService.GetById(userVm.ID);
            user.Phone = userVm.Phone;
            TryValidateModel(user);
            if (ModelState.IsValid)
            {
                user.UpdatedDate = DateTime.Now;
                user.UpdatedBy = currentUserName;
                _userService.Update(user);
                _userService.SaveChanges();
                return Json(new
                {
                    status = true,
                    message = "Update user's phone to " + user.Phone + " successfully"
                });
            }
            else
            {
                return Json(new
                {
                    status = false,
                });
            }
        }

        [HttpPost]
        public JsonResult UpdateFullname(string model)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            UserViewModel userVm = serializer.Deserialize<UserViewModel>(model);

            var user = _userService.GetById(userVm.ID);
            user.Fullname = userVm.Fullname;
            TryValidateModel(user);
            if (ModelState.IsValid)
            {
                user.UpdatedDate = DateTime.Now;
                user.UpdatedBy = currentUserName;
                _userService.Update(user);
                _userService.SaveChanges();
                return Json(new
                {
                    status = true,
                    message = "Update user's fullname to " + user.Fullname + " successfully"
                });
            }
            else
            {
                return Json(new
                {
                    status = false,
                });
            }
        }

        [HttpPost]
        public JsonResult ChangeStatus(int id)
        {
            var user = _userService.GetById(id);
            user.Status = !user.Status;
            user.UpdatedDate = DateTime.Now;
            user.UpdatedBy = currentUserName;
            _userService.Update(user);
            _userService.SaveChanges();
            return Json(new
            {
                status = user.Status,
                data = user.Username
            });
        }
    }
}