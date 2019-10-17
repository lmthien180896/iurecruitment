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
        public JobController(IJobService jobService) {
            this._jobService = jobService;
        }

        public ActionResult Index()
        {
            JobListingViewModel jobListingVm = new JobListingViewModel();            
            return View();           
        }
    }
}