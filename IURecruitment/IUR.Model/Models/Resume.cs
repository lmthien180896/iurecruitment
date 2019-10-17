using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IUR.Model.Models
{
    [Table("Resumes")]
    public class Resume
    {
        [ForeignKey("ApplicantDetail")]
        public int ID { get; set; }      

        [MaxLength(256)]
        public string ResumeUrl { get; set; }

        public virtual ApplicantDetail ApplicantDetail { get; set; }
    }
}