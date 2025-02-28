using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace test.Models
{
    public class Register
    {
        [Required(ErrorMessage = "This is Required")]
        [EmailAddress]
        public string Name { get; set; }

        [Required(ErrorMessage = "This is Required")]
        [EmailAddress]
        public string Email { get; set; }


        [Required(ErrorMessage = "This is Required")]

        public string Password { get; set; }

        [Required(ErrorMessage = "This is Required")]
        [Compare("Password", ErrorMessage = "Password Does Not Matched!")]
        [DisplayName("Confirm Password")]

        public string ConfirmPassword { get; set; }

        [DisplayName("Remember Me")]
        public string RememberMe { get; set; }
    }
}


