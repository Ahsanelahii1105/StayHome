using System.ComponentModel.DataAnnotations;

namespace test.Models.Menu
{
    public class listningPropertyCreator
    {
        [Key]
        public int Id { get; set; } // Unique identifier for the property listing

        public string Name { get; set; } // Name of the property

        public decimal Price { get; set; } // Price of the property

        public string Country { get; set; } // Country where the property is located

        public string City { get; set; } // City where the property is located

        public int Bedrooms { get; set; } // Number of bedrooms

        public string Description { get; set; } // Description of the property

        public double LotArea { get; set; } // Lot area in square feet or meters

        public double FloorArea { get; set; } // Floor area in square feet or meters

        public int Washrooms { get; set; } // Number of washrooms

        public bool Garage { get; set; } // Indicates if there is a garage

        public List<string> Included { get; set; } // List of items included with the property

        public List<string> NotIncluded { get; set; } // List of items not included with the property

        public string MapUrl { get; set; } // URL to the map location

        public string TourVideoUrl { get; set; } // URL to the tour video

        public string Image { get; set; } // Image file for the property
    }
}
