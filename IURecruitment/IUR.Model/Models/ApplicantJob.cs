using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IUR.Model.Models
{
    [Table("ApplicantJobs")]
    public class ApplicantJob
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        [Column(Order = 1)]
        public int ApplicantID { get; set; }

        [Required]
        [Column(Order = 2)]
        public int JobID { get; set; }

        [ForeignKey("ApplicantID")]
        public virtual ApplicantDetail ApplicantDetail { get; set; }

        [ForeignKey("JobID")]
        public virtual Job Job { get; set; }
    }
}