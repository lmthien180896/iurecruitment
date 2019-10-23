using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IUR.Web.Areas.Admin.Models
{
    public class ApplicationTableViewModel
    {
        public int ApplicantID { get; set; }

        public string Fullname { get; set; }

        public string Department { get; set; }

        public string Position { get; set; }

        public string AppliedDate { get; set; }

        public string ResumeURL { get; set; }
    }
}