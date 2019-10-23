using IUR.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IUR.Web.Models
{
    public class OtherQuestionViewModel
    {
        public int ID { get; set; }
       
        public string Available { get; set; }

        public string IsApplied { get; set; }

        public string IsInformed { get; set; }

        public virtual ApplicantDetail ApplicantDetail { set; get; }
    }
}