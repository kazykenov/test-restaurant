using MyAssessment.Model;

namespace MyAssessment.Services;

public interface ITableService
{
    Task<Table> GetTableForPeople(Location location, int numberOfPeople);
}

public class TableService : ITableService
{
    private readonly ITableRepository _tableRepository;

    public TableService(ITableRepository tableRepository)
    {
        _tableRepository = tableRepository;
    }
    
    public async Task<Table> GetTableForPeople(Location location, int numberOfPeople)
    {
        var tables = await _tableRepository.GetTablesByLocation(location);

        foreach (var table in tables)
        {
            if (table.AllowNumFrom <= numberOfPeople && numberOfPeople <= table.AllowNumTo)
            {
                return table;
            }
        }

        throw new Exception("no table available"); // TODO: change to specific Exception
    }
}