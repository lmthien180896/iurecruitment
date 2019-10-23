using IUR.Model.Models;
using System;
using System.Collections.Generic;

namespace IUR.Web.Models
{
    public class ApplicantDetailViewModel
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

        public string Photo { get; set; }

        public virtual ApplicantJob ApplicantJob { set; get; }

        public virtual CareerObjective CareerObjective { set; get; }

        public virtual IEnumerable<ComputerSkill> ComputerSkills { set; get; }

        public virtual IEnumerable<EducationBackground> EducationBackgrounds { set; get; }

        public virtual IEnumerable<EmploymentHistory> EmploymentHistories { set; get; }

        public virtual IEnumerable<Language> Languages { set; get; }

        public virtual OtherQuestion OtherQuestion { set; get; }

        public virtual IEnumerable<OtherSkill> OtherSkills { set; get; }

        public virtual Rank Rank { set; get; }

        public virtual Resume Resume { set; get; }
    }
}