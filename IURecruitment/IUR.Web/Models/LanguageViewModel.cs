using IUR.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IUR.Web.Models
{
    public class LanguageViewModel
    {
        public int ID { set; get; }
       
        public int ApplicantID { get; set; }
        
        public string Certificate { set; get; }
 
        public string Level { get; set; }
     
        public virtual ApplicantDetail ApplicantDetail { set; get; }
    }
}