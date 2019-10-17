using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IUR.Model.Models
{
    [Table("EducationBackground")]
    public class EducationBackground
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { set; get; }

        [Required]
        public int ApplicantID { set; get; }

        [MaxLength(256)]
        public string Level { set; get; }

        [MaxLength(256)]
        public string School { set; get; }

        [MaxLength(256)]
        public string Country { set; get; }

        public DateTime GraduatedDate { set; get; }

        [ForeignKey("ApplicantID")]
        public virtual ApplicantDetail ApplicantDetail { set; get; }
    }
}