using MyAssessment.Model;
using MyAssessment.Services;
using NSubstitute;

namespace MyAssessment.Test;

public class ReservationServiceTests
{
    private readonly IReservationRepository _repository = Substitute.For<IReservationRepository>();
    private ReservationService _service;

    [SetUp]
    public void Setup()
    {
        _service = new ReservationService(_repository);
    }

    [Test]
    public void Reserve_WhenTablesAvailable_CreatesNewReservation()
    {
        var table = new Table
        {
            Quantity = 2
        };
        var dateTime = new DateTime(2022, 02, 02, 1, 1, 1);
        _repository.GetReservationsCountByTableAndDateTime(table, dateTime).Returns(1);

        var reservation = _service.Reserve(table, dateTime, 5);
        
        _repository.Received(1).CreateReservation(table, dateTime, 5);
        
        // todo: those are unit tests for IReservationRepository
        Assert.AreEqual(table, reservation.Table);
        // Assert.AreEqual("2022-02-02", reservation.Date);
        // Assert.AreEqual(1, reservation.Hour);
    }

    [Test]
    public void Reserve_WhenAllTablesAreReserved_ThrowException()
    {
        var table = new Table
        {
            Quantity = 3
        };
        var dateTime = new DateTime(2022, 02, 02, 1, 1, 1);
        _repository.GetReservationsCountByTableAndDateTime(table, dateTime).Returns(3);

        Assert.Catch<Exception>(() =>
        {
            _service.Reserve(table, dateTime, 5);
        });

        _repository.DidNotReceiveWithAnyArgs().CreateReservation(Arg.Any<Table>(), Arg.Any<DateTime>(), Arg.Any<int>());
    }
    
    [Test]
    public void Reserve_WhenTableQuantityZero_ThrowException()
    {
        var table = new Table
        {
            Quantity = 0
        };
        var dateTime = new DateTime(2022, 02, 02, 1, 1, 1);
        _repository.GetReservationsCountByTableAndDateTime(table, dateTime).Returns(0);

        Assert.Catch<Exception>(() =>
        {
            _service.Reserve(table, dateTime, 5);
        });

        _repository.DidNotReceiveWithAnyArgs().CreateReservation(Arg.Any<Table>(), Arg.Any<DateTime>(), Arg.Any<int>());
    }
}