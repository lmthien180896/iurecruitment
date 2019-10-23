using IUR.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IUR.Web.Models
{
    public class ApplicantJobViewModel
    {
        public int ID { get; set; }
  
        public int ApplicantID { get; set; }
 
        public int JobID { get; set; }
        
        public virtual ApplicantDetail ApplicantDetail { get; set; }
     
        public virtual Job Job { get; set; }
    }
}