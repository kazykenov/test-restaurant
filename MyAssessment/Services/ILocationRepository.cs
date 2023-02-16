using MyAssessment.Data;
using MyAssessment.Model;

namespace MyAssessment.Services;

public interface ILocationRepository
{
    Task<Location> GetLocationById(int locationId);
}

public class LocationRepository : ILocationRepository
{
    private readonly ApplicationDbContext _context;

    public LocationRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task<Location> GetLocationById(int locationId)
    {
        return await _context.Locations.FindAsync(locationId) ?? throw new InvalidOperationException();
    }
}