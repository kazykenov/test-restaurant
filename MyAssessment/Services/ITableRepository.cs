using MyAssessment.Model;

namespace MyAssessment.Services;

public interface ITableRepository
{
    IEnumerable<Table> GetTablesByLocation(Location location);
}