using System.ComponentModel.DataAnnotations;

namespace MyAssessment.Model
{
    public class Restaurant
    {
        [Key]
        public int RestaurantId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Slug { get; set; }

        public ICollection<Location> Locations { get; set; }
    }
}
