using MyAssessment.Model;
using MyAssessment.Services;
using NSubstitute;

namespace MyAssessment.Test;

public class TableServiceTests
{
    private readonly ITableRepository _repository = Substitute.For<ITableRepository>();
    private TableService _service;

    [SetUp]
    public void Setup()
    {
        _service = new TableService(_repository);
    }

    [Test]
    public async Task GetTableForPeople_WhenNumberOfPeopleFitInTables_ReturnsAppropriateTables()
    {
        var location = new Location();
        var smallTable = new Table() { AllowNumFrom = 1, AllowNumTo = 2 };
        var mediumTable = new Table() { AllowNumFrom = 3, AllowNumTo = 4 };
        var largeTable = new Table() { AllowNumFrom = 5, AllowNumTo = 8 };

        _repository.GetTablesByLocation(location).Returns(new[]
        {
            smallTable,
            mediumTable,
            largeTable
        });

        var table = await _service.GetTableForPeople(location, 2);
        Assert.That(smallTable, Is.EqualTo(table));
        
        table = await _service.GetTableForPeople(location, 3);
        Assert.That(mediumTable, Is.EqualTo(table));
        
        table = await _service.GetTableForPeople(location, 8);
        Assert.That(largeTable, Is.EqualTo(table));
    }
    
    [Test]
    public void GetTableForPeople_WhenNumberOfPeopleDoesNotFitInTables_ThrowException()
    {
        var location = new Location();
        var smallTable = new Table() { AllowNumFrom = 1, AllowNumTo = 2 };
        var mediumTable = new Table() { AllowNumFrom = 3, AllowNumTo = 4 };
        var largeTable = new Table() { AllowNumFrom = 5, AllowNumTo = 8 };

        _repository.GetTablesByLocation(location).Returns(new[]
        {
            smallTable,
            mediumTable,
            largeTable
        });

        Assert.ThrowsAsync<Exception>( async () =>
        {
            await _service.GetTableForPeople(location, 9);
        });
    }
    
    [Test]
    public void GetTableForPeople_WhenNoTables_ThrowException()
    {
        var location = new Location();

        _repository.GetTablesByLocation(location).Returns(Array.Empty<Table>());

        Assert.ThrowsAsync<Exception>(async () =>
        {
            await _service.GetTableForPeople(location, 9);
        });
    }
    
    [Test]
    public async Task GetTableForPeople_WhenFitToMultipleTables_ReturnsFirstTableInTheList()
    {
        var location = new Location();
        var table1 = new Table() { AllowNumFrom = 1, AllowNumTo = 5};
        var table2 = new Table() { AllowNumFrom = 0, AllowNumTo = 4 };

        _repository.GetTablesByLocation(location).Returns(new[] { table1, table2 });
        
        var table = await _service.GetTableForPeople(location, 3);
        
        Assert.AreEqual(table, table1);
    }
}