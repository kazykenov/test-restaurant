using MyAssessment.Data;
using MyAssessment.Model;

namespace MyAssessment.Services;

public interface ILocationRepository
{
    Location GetLocationById(int locationId);
}

public class LocationRepository : ILocationRepository
{
    private readonly ApplicationDbContext _context;

    public LocationRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public Location GetLocationById(int locationId)
    {
        // todo: make async
        return _context.Locations.Find(locationId) ?? throw new InvalidOperationException();
    }
}