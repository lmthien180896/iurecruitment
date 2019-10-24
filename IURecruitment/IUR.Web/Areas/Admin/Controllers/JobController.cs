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
    public class JobController : BaseController
    {
        private IJobService _jobService;
        private IDepartmentService _departmentService;

        public JobController(IJobService jobService, IDepartmentService departmentService)
        {
            this._jobService = jobService;
            this._departmentService = departmentService;
        }

        public ActionResult Index()
        {
            var listDepartment = _departmentService.GetAll();
            var listDepartmentVm = Mapper.Map<IEnumerable<Department>, IEnumerable<DepartmentViewModel>>(listDepartment);
            ViewBag.listDepartments = listDepartmentVm;
            return View();
        }

        [HttpGet]
        public JsonResult LoadJobs(string sortItem, int page, int pageSize)
        {
            IEnumerable<Job> listJob = _jobService.GetAllSort(sortItem);
            var listJobVm = Mapper.Map<IEnumerable<Job>, IEnumerable<JobViewModel>>(listJob);
            foreach (var job in listJobVm)
            {
                job.PostedDate = job.CreatedDate.Value.ToString("dd/MM/yyyy");
                job.DeadlineDate = job.Deadline.ToString("dd/MM/yyyy");
            }
            var totalRow = listJobVm.Count();
            var listJobs = listJobVm.Skip((page - 1) * pageSize).Take(pageSize);
            return Json(new
            {
                data = listJobVm,
                totalRow = totalRow,
                sortItem = sortItem,
                status = true
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetJobDetail(int id)
        {
            var job = _jobService.GetById(id);
            job.Department = _departmentService.GetById(job.DepartmentID);
            var jobVm = Mapper.Map<Job, JobViewModel>(job);
            jobVm.DeadlineDate = jobVm.Deadline.ToString("yyyy-MM-dd");
            return Json(new
            {
                data = jobVm,
                status = true
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateInput(false)]
        public JsonResult AddOrUpdate(string model)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            var jobViewModel = serializer.Deserialize<JobViewModel>(model);
            if (jobViewModel.ID == 0)
            {
                Job job = new Job();
                job.UpdateJob(jobViewModel);
                job.CreatedDate = DateTime.Now;
                job.CreatedBy = currentUserName;
                TryValidateModel(job);
                if (ModelState.IsValid)
                {
                    try
                    {
                        _jobService.Add(job);
                        _jobService.SaveChanges();
                        return Json(new
                        {
                            status = true,
                            message = "Create " + job.Name + " jobs successfully"
                        });
                    }
                    catch
                    {
                        return Json(new
                        {
                            status = false,
                            message = "Create failed"
                        });
                    }
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
                var updatedJob = _jobService.GetById(jobViewModel.ID);
                updatedJob.UpdateJob(jobViewModel);
                updatedJob.UpdatedDate = DateTime.Now;
                updatedJob.UpdatedBy = currentUserName;
                TryValidateModel(updatedJob);
                if (ModelState.IsValid)
                {
                    try
                    {
                        _jobService.Update(updatedJob);
                        _jobService.SaveChanges();
                        return Json(new
                        {
                            status = true,
                            message = "Update to " + updatedJob.Name + " successfully"
                        });
                    }
                    catch
                    {
                        return Json(new
                        {
                            status = false,
                            message = "Update failed"
                        });
                    }
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
                    message = "ModelSate is not valid",
                    status = false
                });
            }
            else
            {
                var job = _jobService.Delete(id);
                _jobService.SaveChanges();
                return Json(new
                {
                    message = "Delete " + job.Name + " successfully",
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
                    _jobService.Delete(int.Parse(id));
                    countDelete++;
                }
            }
            _jobService.SaveChanges();
            return Json(new
            {
                message = "Delete " + countDelete + "jobs successfully",
                status = true
            });
        }

        [HttpPost]
        public JsonResult ChangeStatus(int id)
        {
            var job = _jobService.GetById(id);
            job.Status = !job.Status;
            job.UpdatedDate = DateTime.Now;
            job.UpdatedBy = currentUserName;
            _jobService.Update(job);
            _jobService.SaveChanges();
            return Json(new
            {
                status = job.Status,
                data = job.Name
            });
        }
    }
}