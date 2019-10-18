using System.Collections.Generic;

namespace IUR.Web.Models
{
    public class JobListingViewModel
    {
        public IEnumerable<JobViewModel> ManagementAndStaffJobs { get; set; }
        public IEnumerable<JobViewModel> FulltimeJobs { get; set; }
        public IEnumerable<JobViewModel> ParttimeJobs { get; set; }
    }
}