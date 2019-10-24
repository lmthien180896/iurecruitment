using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IUR.Model.Models
{
    [Table("Ranks")]
    public class Rank
    {
        [ForeignKey("ApplicantDetail")]
        public int ID { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public virtual ApplicantDetail ApplicantDetail { get; set; }
    }
}