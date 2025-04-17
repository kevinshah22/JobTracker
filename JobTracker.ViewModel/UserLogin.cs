using System.ComponentModel.DataAnnotations;

namespace JobTracker.ViewModel
{
    /// <summary>
    /// Model for user login
    /// </summary>
    public class UserLogin
    {
        [Required(ErrorMessage = "Email can't be empty")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password can't be empty")]
        public string Password { get; set; }
    }
}
