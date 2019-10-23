using IUR.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IUR.Web.Models
{
    public class EducationBackgroundViewModel
    {
        public int ID { set; get; }
      
        public int ApplicantID { set; get; }
      
        public string Level { set; get; }
      
        public string School { set; get; }

        public string Country { set; get; }

        public string Major { set; get; }

        public DateTime GraduatedDate { set; get; }

        public virtual ApplicantDetail ApplicantDetail { set; get; }
    }
}