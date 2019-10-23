using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IUR.Model.Models
{
    [Table("EmploymentHistories")]
    public class EmploymentHistory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { set; get; }

        [Required]
        public int ApplicantID { set; get; }

        public DateTime FromDate { get; set; }

        public DateTime ToDate { get; set; }

        [MaxLength(256)]
        public string Company { get; set; }

        [MaxLength(256)]
        public string Position { get; set; }

        [MaxLength(256)]
        public string Description { get; set; }

        [MaxLength(256)]
        public string LeavingReason { get; set; }

        [ForeignKey("ApplicantID")]
        public virtual ApplicantDetail ApplicantDetail { set; get; }
    }
}