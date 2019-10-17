using IUR.Model.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IUR.Model.Models
{
    [Table("ApplicantDetails")]
    public class ApplicantDetail : Auditable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        [MaxLength(256)]
        public string Fullname { get; set; }

        [Required]
        [MaxLength(5)]
        public string Title { get; set; }

        [Required]
        public DateTime DOB { get; set; }

        [Required]
        [MaxLength(256)]
        public string PlaceOfBirth { get; set; }

        [Required]
        [MaxLength(256)]
        public string Nationality { get; set; }

        [Required]
        [MaxLength(256)]
        public string ContactAddress { get; set; }

        [Required]
        [MaxLength(256)]
        public string PermanentAddress { get; set; }

        [Required]
        [MaxLength(256)]
        public string Phone { get; set; }

        [Required]
        [MaxLength(256)]
        public string Email { get; set; }

        [Required]
        [MaxLength(256)]
        public string IDCard { get; set; }

        [Required]
        public DateTime IssuedDate { get; set; }

        [Required]
        [MaxLength(256)]
        public string IssuedPlace { get; set; }

        [Required]
        [MaxLength(256)]
        public string Photo { get; set; }

        public virtual IEnumerable<ApplicantJob> ApplicantJobs { set; get; }
       
        public virtual CareerObjective CareerObjective { set; get; }

        public virtual IEnumerable<ComputerSkill> ComputerSkills { set; get; }

        public virtual IEnumerable<EducationBackground> EducationBackgrounds { set; get; }

        public virtual IEnumerable<EmploymentHistory> EmploymentHistories { set; get; }

        public virtual IEnumerable<Language> Languages { set; get; }

        public int OtherQuestionId { get; set; }
        public virtual OtherQuestion OtherQuestion { set; get; }

        public virtual IEnumerable<OtherSkill> OtherSkills { set; get; }
       
        public virtual Resume Resume { set; get; }
    }
}