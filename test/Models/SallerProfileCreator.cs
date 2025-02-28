using System.ComponentModel.DataAnnotations;

namespace test.Models
{
    public class SallerProfileCreator
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Phone]
        public string PhoneNumber { get; set; }

        [MaxLength(200)]
        public string Address { get; set; }

        [MaxLength(100)]
        public string Country { get; set; }

        [MaxLength(100)]
        public string City { get; set; }

        [Required]
        [MaxLength(15)]
        public string CNICNumber { get; set; }

        public string CNICFrontPic { get; set; } // File path or Base64

        public string CNICBackPic { get; set; } // File path or Base64

        [Required]
        public string Gender { get; set; } // Can be "Male", "Female", "Other"

        public bool Dealer { get; set; } // To indicate if the person is a dealer
    }
}
