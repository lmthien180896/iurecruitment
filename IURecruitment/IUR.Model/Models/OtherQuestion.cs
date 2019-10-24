using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IUR.Model.Models
{
    [Table("OtherQuestions")]
    public class OtherQuestion
    {
        [ForeignKey("ApplicantDetail")]
        public int ID { get; set; }

        [Required]
        [MaxLength(256)]
        public string Available { get; set; }

        [Required]
        [MaxLength(256)]
        public string IsApplied { get; set; }

        [MaxLength(256)]
        [Required]
        public string IsInformed { get; set; }

        public virtual ApplicantDetail ApplicantDetail { set; get; }
    }
}