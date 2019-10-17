using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IUR.Web.Models
{
    public class DepartmentViewModel
    {
        public int ID { set; get; }
        
        public string Name { set; get; }

        public DateTime? CreatedDate { get; set; }
       
        public string CreatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }
       
        public string UpdatedBy { get; set; }
        
        public string MetaKeyword { get; set; }
       
        public string MetaDescription { get; set; }

        public bool Status { get; set; }
    }
}