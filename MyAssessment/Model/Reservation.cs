using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyAssessment.Model
{
    public class Reservation
    {
        [Key]
        public int ReservationId { get; set; }

        [Required]
        public int TableId { get; set; }
        public Table Table { get; set; }

        [Required]
        public string Date { get; set; }
        [Required]
        public int Hour { get; set; }
    }
}
