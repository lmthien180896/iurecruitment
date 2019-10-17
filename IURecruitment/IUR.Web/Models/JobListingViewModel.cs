using IUR.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IUR.Web.Models
{
    public class JobListingViewModel
    {
        IEnumerable<Job> ManagementAndStaffJobs { get; set; } 
        IEnumerable<Job> FulltimeJobs { get; set; } 
        IEnumerable<Job> ParttimeJobs { get; set; } 
    }
}