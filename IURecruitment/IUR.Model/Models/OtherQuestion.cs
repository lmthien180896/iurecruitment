using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IUR.Model.Models
{
    [Table("OtherQuestions")]
    public class OtherQuestion
    {
        [ForeignKey("ApplicantDetail")]
        public int ID { get; set; }        

        [MaxLength(256)]
        public string Available { get; set; }

        public bool IsApplied { get; set; }

        public bool IsInformed { get; set; }

        public virtual ApplicantDetail ApplicantDetail { set; get; }
    }
}