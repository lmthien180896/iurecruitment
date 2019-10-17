using IUR.Model.Abstract;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IUR.Model.Models
{
    [Table("Languages")]
    public class Language : Auditable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { set; get; }

        [Required]
        public int ApplicantID { get; set; }

        [MaxLength(256)]
        public string Certificate { set; get; }

        [MaxLength(256)]
        public string Level { get; set; }

        [ForeignKey("ApplicantID")]
        public virtual ApplicantDetail ApplicantDetail { set; get; }
    }
}