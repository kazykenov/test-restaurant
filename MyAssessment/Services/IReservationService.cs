using MyAssessment.Model;

namespace MyAssessment.Services;

public interface IReservationService
{
    Reservation Reserve(Table table, DateTime dateTime, int numberOfPeople);
}

public class ReservationService : IReservationService
{
    private readonly IReservationRepository _reservationRepository;

    public ReservationService(IReservationRepository reservationRepository)
    {
        _reservationRepository = reservationRepository;
    }
    
    public Reservation Reserve(Table table, DateTime dateTime, int numberOfPeople)
    {
        var reservedTablesQuantity = _reservationRepository.GetReservationsCountByTableAndDateTime(table, dateTime);

        if (reservedTablesQuantity >= table.Quantity)
        {
            throw new Exception("All the tables are reserved");
        }

        var reservation = _reservationRepository.CreateReservation(table, dateTime, numberOfPeople);

        return reservation;
    }
}