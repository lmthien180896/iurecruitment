using IUR.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IUR.Web.Models
{
    public class OtherSkillViewModel
    {
        public int ID { set; get; }
     
        public int ApplicantID { set; get; }
       
        public string Skill { set; get; }
    
        public string Reference { set; get; }
       
        public virtual ApplicantDetail ApplicantDetail { set; get; }
    }
}