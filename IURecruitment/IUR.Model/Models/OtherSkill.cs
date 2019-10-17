using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IUR.Model.Models
{
    [Table("OtherSkills")]
    public class OtherSkill
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { set; get; }

        [Required]
        public int ApplicantID { set; get; }

        [MaxLength(256)]
        public string Skill { set; get; }

        [MaxLength(256)]
        public string Reference { set; get; }

        [ForeignKey("ApplicantID")]
        public virtual ApplicantDetail ApplicantDetail { set; get; }
    }
}