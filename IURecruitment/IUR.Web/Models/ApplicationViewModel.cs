using IUR.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IUR.Web.Models
{
    public class ApplicationViewModel
    {
        public int ID { get; set; }
        
        public string Fullname { get; set; }
       
        public string Title { get; set; }
       
        public DateTime DOB { get; set; }
       
        public string PlaceOfBirth { get; set; }
      
        public string Nationality { get; set; }
       
        public string ContactAddress { get; set; }
       
        public string PermanentAddress { get; set; }
        
        public string Phone { get; set; }
       
        public string Email { get; set; }
       
        public string IDCard { get; set; }
      
        public DateTime IssuedDate { get; set; }
        
        public string IssuedPlace { get; set; }

        public string Resume { get; set; }

        public CareerObjective CareerObjective { get; set; }

        public IEnumerable<EducationBackground> EducationBackground { get; set; }
        
    }
}