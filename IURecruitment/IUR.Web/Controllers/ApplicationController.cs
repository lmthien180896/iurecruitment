using IUR.Service;
using IUR.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IUR.Web.Controllers
{
    public class ApplicationController : Controller
    {
        IJobService _jobService;
        IDepartmentService _departmentService;
        public ApplicationController(IJobService jobService, IDepartmentService departmentService)
        {
            this._jobService = jobService;
            this._departmentService = departmentService;
        }

        public ActionResult ApplyForm(int jobid)
        {
            ViewBag.JobID = jobid;
            var job = _jobService.GetById(jobid);
            ViewBag.JobName = job.Name;
            ViewBag.Department = _departmentService.GetById(job.DepartmentID).Name;
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult SubmitApplication(ApplicationViewModel applicationVm)
        {
            return View();
        }
    }
}