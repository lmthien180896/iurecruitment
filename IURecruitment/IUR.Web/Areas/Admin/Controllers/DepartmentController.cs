using AutoMapper;
using IUR.Model.Models;
using IUR.Service;
using IUR.Web.Infrastructure.Extensions;
using IUR.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace IUR.Web.Areas.Admin.Controllers
{
    public class DepartmentController : BaseController
    {
        private IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            this._departmentService = departmentService;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult LoadDepartments(int page, int pageSize)
        {
            var totalDepartments = _departmentService.GetAll();
            var totalDepartmentVm = Mapper.Map<IEnumerable<Department>, IEnumerable<DepartmentViewModel>>(totalDepartments);
            var listDepartments = totalDepartmentVm.Skip((page - 1) * pageSize).Take(pageSize);
            var totalRow = totalDepartmentVm.Count();
            return Json(new
            {
                data = listDepartments,
                totalRow = totalRow,
                status = true
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetDepartmentDetail(int id)
        {
            var department = _departmentService.GetById(id);
            var departmentVm = Mapper.Map<Department, DepartmentViewModel>(department);
            return Json(new
            {
                data = departmentVm,
                status = true
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult AddOrUpdate(string model)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            var departmentViewModel = serializer.Deserialize<DepartmentViewModel>(model);
            if (departmentViewModel.ID == 0)
            {
                Department department = new Department();
                department.UpdateDepartment(departmentViewModel);
                department.CreatedDate = DateTime.Now;
                department.CreatedBy = currentUserName;
                TryValidateModel(department);
                if (ModelState.IsValid)
                {
                    _departmentService.Add(department);
                    _departmentService.SaveChanges();
                    return Json(new
                    {
                        status = true,
                        message = "Create " + department.Name + " departments successfully"
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
            else
            {
                var updatedDepartment = _departmentService.GetById(departmentViewModel.ID);
                updatedDepartment.UpdateDepartment(departmentViewModel);
                updatedDepartment.UpdatedDate = DateTime.Now;
                updatedDepartment.UpdatedBy = currentUserName;
                TryValidateModel(updatedDepartment);
                if (ModelState.IsValid)
                {
                    _departmentService.Update(updatedDepartment);
                    _departmentService.SaveChanges();
                    return Json(new
                    {
                        status = true,
                        message = "Update to " + updatedDepartment.Name + " successfully"
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
                var department = _departmentService.Delete(id);
                _departmentService.SaveChanges();
                return Json(new
                {
                    message = "Delete " + department.Name + " successfully",
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
                    _departmentService.Delete(int.Parse(id));
                    countDelete++;
                }
            }
            _departmentService.SaveChanges();
            return Json(new
            {
                message = "Delete " + countDelete + " departments successfully",
                status = true
            });
        }

        [HttpPost]
        public JsonResult ChangeStatus(int id)
        {
            var department = _departmentService.GetById(id);
            department.Status = !department.Status;
            department.UpdatedDate = DateTime.Now;
            department.UpdatedBy = currentUserName;
            _departmentService.Update(department);
            _departmentService.SaveChanges();
            return Json(new
            {
                status = department.Status,
                data = department.Name
            });
        }
    }
}