using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyAssessment.Model
{
    public class Location
    {
        [Key]
        public int LocationId { get; set; }

        //[ForeignKey(nameof(Location.Restaurant))]
        [Required]
        public int RestaurantId { get; set; }
        public Restaurant Restaurant { get; set; }

        [Required]
        public string Slug { get; set; }

        public string Address { get; set; }

        [Required]
        public short OpeningHour { get; set; }

        [Required]
        public short ClosingHour { get; set; }

        public ICollection<Table> Tables { get; set; }
    }
}
