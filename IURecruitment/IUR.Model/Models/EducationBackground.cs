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
        [Required]
        public string Level { set; get; }

        [MaxLength(256)]
        [Required]
        public string School { set; get; }

        [Required]
        [MaxLength(256)]
        public string Country { set; get; }

        [Required]
        [MaxLength(256)]
        public string Major { get; set; }

        public DateTime GraduatedDate { set; get; }

        [ForeignKey("ApplicantID")]
        public virtual ApplicantDetail ApplicantDetail { set; get; }
    }
}