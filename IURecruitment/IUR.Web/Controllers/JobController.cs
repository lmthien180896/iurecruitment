using AutoMapper;
using IUR.Controllers;
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
    public class JobController : BaseController
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
            foreach (var job in managementAndStaffJobs)
            {
                job.Department = _departmentService.GetById(job.DepartmentID);
            }
            var managementAndStaffJobsVm = Mapper.Map<IEnumerable<Job>, IEnumerable<JobViewModel>>(managementAndStaffJobs);

            var fulltimeJobs = _jobService.GetAllFullTimeJobs();
            foreach (var job in fulltimeJobs)
            {
                job.Department = _departmentService.GetById(job.DepartmentID);
            }
            var fulltimeJobsVm = Mapper.Map<IEnumerable<Job>, IEnumerable<JobViewModel>>(fulltimeJobs);

            var parttimeJobs = _jobService.GetAllPartTimeJobs();
            foreach (var job in parttimeJobs)
            {
                job.Department = _departmentService.GetById(job.DepartmentID);
            }
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