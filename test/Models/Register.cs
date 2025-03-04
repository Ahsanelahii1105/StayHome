using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace test.Models
{
    public class Register
    {
        [Key]
        [Required(ErrorMessage = "This is Required")]   
        public string Name { get; set; }

        [Required(ErrorMessage = "This is Required")]
        [EmailAddress]
        public string Email { get; set; }


        [Required(ErrorMessage = "This is Required")]
        //[RegularExpression("/(?=.*?[0 - 9])(?=.*?[A-Za-z]).{8,32}$/)"]
        public string Password { get; set; }

        [Required(ErrorMessage = "This is Required")]
        [Compare("Password", ErrorMessage = "Password Does Not Matched!")]
        [DisplayName("Confirm Password")]

        public string ConfirmPassword { get; set; }
    }
}


