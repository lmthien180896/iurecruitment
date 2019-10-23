using IUR.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IUR.Web.Models
{
    public class ComputerSkillViewModel
    {
        public int ID { set; get; }
      
        public int ApplicantID { set; get; }
        
        public string Software { set; get; }
     
        public string Level { set; get; }
      
        public virtual ApplicantDetail ApplicantDetail { set; get; }
    }
}