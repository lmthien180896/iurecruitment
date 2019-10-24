using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IUR.Model.Models
{
    [Table("CareerObjectives")]
    public class CareerObjective
    {
        [ForeignKey("ApplicantDetail")]
        public int ID { set; get; }

        [Required]
        public string Objective { set; get; }

        public virtual ApplicantDetail ApplicantDetail { set; get; }
    }
}