using IUR.Model.Abstract;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IUR.Model.Models
{
    [Table("Users")]
    public class User : Auditable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        [MaxLength(50)]
        public string Username { get; set; }

        [Required]
        [MaxLength(256)]
        public string HashedPassword { get; set; }

        [Required]
        [MaxLength(256)]
        public string Fullname { get; set; }

        [MaxLength(256)]
        public string Phone { get; set; }
    }
}