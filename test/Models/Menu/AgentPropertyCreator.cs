using System.ComponentModel.DataAnnotations;

namespace test.Models.Menu
{
    public class AgentPropertyCreator
    {
        [Key]
        public int Id { get; set; } // Unique identifier for the property listing

        [Required(ErrorMessage = "This is Required")]
        public string Name { get; set; } // Name of the property

        [Required(ErrorMessage = "This is Required")]
        public decimal Price { get; set; } // Price of the property

        [Required(ErrorMessage = "This is Required")]
        public string Country { get; set; } // Country where the property is located

        [Required(ErrorMessage = "This is Required")]
        public string City { get; set; } // City where the property is located

        [Required(ErrorMessage = "This is Required")]
        public int Bedrooms { get; set; } // Number of bedrooms

        [Required(ErrorMessage = "This is Required")]
        public string Description { get; set; } // Description of the property

        [Required(ErrorMessage = "This is Required")]
        public double LotArea { get; set; } // Lot area in square feet or meters

        [Required(ErrorMessage = "This is Required")]
        public double FloorArea { get; set; } // Floor area in square feet or meters

        [Required(ErrorMessage = "This is Required")]
        public int Washrooms { get; set; } // Number of washrooms

        [Required(ErrorMessage = "This is Required")]
        public bool Garage { get; set; } // Indicates if there is a garage

        [Required(ErrorMessage = "This is Required")]
        public List<string> Included { get; set; } // List of items included with the property

        [Required(ErrorMessage = "This is Required")]
        public List<string> NotIncluded { get; set; } // List of items not included with the property

        [Required(ErrorMessage = "This is Required")]
        public string MapUrl { get; set; } // URL to the map location

        [Required(ErrorMessage = "This is Required")]
        public string TourVideoUrl { get; set; } // URL to the tour video

        [Required(ErrorMessage = "This is Required")]
        public string Image { get; set; } // Image file for the property
    }
}
