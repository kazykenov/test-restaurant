using Microsoft.EntityFrameworkCore;
using MyAssessment.Model;

namespace MyAssessment.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Table> Tables { get; set; }
        public DbSet<Reservation> Reservation { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
            : base(options)
        { 

        }
    }
}
