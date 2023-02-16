using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyAssessment.Model
{
    public class Table
    {
        [Key]
        public int TableId { get; set; }

        [Required]
        public int LocationId { get; set; }
        public Location Location { get; set; }

        [Required]
        public int AllowNumFrom { get; set; }

        [Required]
        public int AllowNumTo { get; set; }

        public ICollection<Reservation> reservations { get; set; }
    }
}
