using System.ComponentModel.DataAnnotations;

namespace JobTracker.ViewModel
{
    public class UserRegistrationModel
    {
        [Required(ErrorMessage = "First name is required.")]
        public string FName { get; set; }
        [Required(ErrorMessage = "Last name is required.")]
        public string LName { get; set; }
        [Required(ErrorMessage = "Email is required.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; }
    }
}
