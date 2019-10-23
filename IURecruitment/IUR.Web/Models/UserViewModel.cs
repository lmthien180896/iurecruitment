using System;

namespace IUR.Web.Models
{
    public class UserViewModel
    {
        public int ID { get; set; }

        public string Username { get; set; }

        public string HashedPassword { get; set; }

        public string Fullname { get; set; }

        public string Phone { get; set; }

        public DateTime? CreatedDate { get; set; }

        public string CreatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public string UpdatedBy { get; set; }

        public bool Status { get; set; }

        public string CreatedDateToString { get; set; }
    }
}