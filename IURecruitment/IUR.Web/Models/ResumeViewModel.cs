using IUR.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IUR.Web.Models
{
    public class ResumeViewModel
    {
        public int ID { get; set; }
     
        public string ResumeUrl { get; set; }

        public virtual ApplicantDetail ApplicantDetail { get; set; }
    }
}