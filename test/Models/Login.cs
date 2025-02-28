using System.ComponentModel.DataAnnotations;

namespace test.Models
{
    public class Login
    {

        [Required(ErrorMessage = "This is Required")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "This is Required")]

        public string Password { get; set; }

    }
}