using MyAssessment.Data;
using MyAssessment.Model;

namespace MyAssessment.Services;

public interface ITableRepository
{
    IEnumerable<Table> GetTablesByLocation(Location location);
}

public class TableRepository : ITableRepository
{
    private readonly ApplicationDbContext _context;

    public TableRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public IEnumerable<Table> GetTablesByLocation(Location location)
    {
        return _context.Tables.Where(table => table.LocationId == location.LocationId).ToList();
    }
}