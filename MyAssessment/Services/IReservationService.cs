using MyAssessment.Model;

namespace MyAssessment.Services;

public interface IReservationService
{
    Reservation Reserve(Table table, DateTime dateTime, int numberOfPeople);
}

public class ReservationService : IReservationService
{
    public Reservation Reserve(Table table, DateTime dateTime, int numberOfPeople)
    {
        return null;
    }
}