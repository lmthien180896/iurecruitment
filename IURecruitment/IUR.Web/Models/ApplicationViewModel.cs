using IUR.Model.Models;
using System;

namespace IUR.Web.Models
{
    public class ApplicationViewModel
    {
        public int ApplicantID { get; set; }

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

        public string Photo { get; set; }

        public CareerObjective CareerObjective { get; set; }

        public OtherQuestion OtherQuestion { get; set; }

        public Rank Rank { get; set; }   
        
        public string Resume { get; set; }
       

    }
}