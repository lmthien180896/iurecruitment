using IUR.Model.Abstract;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IUR.Model.Models
{
    [Table("Jobs")]
    public class Job : Auditable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        [MaxLength(256)]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        public string TimeType { get; set; }

        [Required]
        [MaxLength(50)]
        public string EmployeeType { get; set; }

        [Required]
        public int DepartmentID { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Requirement { get; set; }

        [Required]
        public DateTime Deadline { get; set; }

        [ForeignKey("DepartmentID")]
        public virtual Department Department { get; set; }
    }
}