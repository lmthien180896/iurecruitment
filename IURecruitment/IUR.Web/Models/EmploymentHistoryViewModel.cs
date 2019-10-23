using IUR.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IUR.Web.Models
{
    public class EmploymentHistoryViewModel
    {
        public int ID { set; get; }
        
        public int ApplicantID { set; get; }

        public DateTime FromDate { get; set; }

        public DateTime ToDate { get; set; }
      
        public string Company { get; set; }
      
        public string Position { get; set; }
      
        public string Description { get; set; }
        
        public string LeavingReason { get; set; }

        public virtual ApplicantDetail ApplicantDetail { set; get; }
    }
}