using Microsoft.EntityFrameworkCore;
using MyAssessment.Data;
using MyAssessment.Model;

namespace MyAssessment.Services;

public interface ITableRepository
{
    Task<IEnumerable<Table>> GetTablesByLocation(Location location);
}

public class TableRepository : ITableRepository
{
    private readonly ApplicationDbContext _context;

    public TableRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<Table>> GetTablesByLocation(Location location)
    {
        return await _context.Tables.Where(table => table.LocationId == location.LocationId).ToListAsync();
    }
}