using AutoMapper;
using IUR.Model.Models;
using IUR.Service;
using IUR.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IUR.Web.Controllers
{
    public class JobController : Controller
    {
        IJobService _jobService;
        IDepartmentService _departmentService;
        public JobController(IJobService jobService, IDepartmentService departmentService)
        {
            this._jobService = jobService;
            this._departmentService = departmentService;
        }

        public ActionResult JobListing()
        {
            var managementAndStaffJobs = _jobService.GetAllManagementAndStaffJobs();
            var managementAndStaffJobsVm = Mapper.Map<IEnumerable<Job>, IEnumerable<JobViewModel>>(managementAndStaffJobs);

            var fulltimeJobs = _jobService.GetAllManagementAndStaffJobs();
            var fulltimeJobsVm = Mapper.Map<IEnumerable<Job>, IEnumerable<JobViewModel>>(fulltimeJobs);

            var parttimeJobs = _jobService.GetAllManagementAndStaffJobs();
            var parttimeJobsVm = Mapper.Map<IEnumerable<Job>, IEnumerable<JobViewModel>>(parttimeJobs);

            JobListingViewModel jobListingVm = new JobListingViewModel();
            jobListingVm.ManagementAndStaffJobs = managementAndStaffJobsVm;
            jobListingVm.FulltimeJobs = fulltimeJobsVm;
            jobListingVm.ParttimeJobs = parttimeJobsVm;
            return View(jobListingVm);
        }

        public ActionResult ViewJobDetail(int id)
        {
            var job = _jobService.GetById(id);
            job.Department = _departmentService.GetById(job.DepartmentID);
            var jobVm = Mapper.Map<Job, JobViewModel>(job);
            return View(jobVm);
        }
        
    }
}