using IUR.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IUR.Web.Models
{
    public class JobViewModel
    {
        public int ID { get; set; }
        
        public string Name { get; set; }
       
        public string TimeType { get; set; }
        
        public string EmployeeType { get; set; }
      
        public int DepartmentID { get; set; }
       
        public string Description { get; set; }
        
        public string Requirement { get; set; }
       
        public DateTime Deadline { get; set; }

        public DateTime? CreatedDate { get; set; }

        public string CreatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public string UpdatedBy { get; set; }

        public string MetaKeyword { get; set; }

        public string MetaDescription { get; set; }

        public bool Status { get; set; }

        public Department Department { get; set; }

        public string PostedDate { get; set; }
        public string DeadlineDate { get; set; }
    }
}