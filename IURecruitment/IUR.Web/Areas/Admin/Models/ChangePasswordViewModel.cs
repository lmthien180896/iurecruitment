namespace IUR.Web.Areas.Admin.Models
{
    public class ChangePasswordViewModel
    {
        public int ID { get; set; }

        public string CurrentPassword { get; set; }

        public string NewPassword { get; set; }

        public string ConfirmedPassword { get; set; }
    }
}