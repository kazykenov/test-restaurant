using MyAssessment.Data;
using MyAssessment.Model;

namespace MyAssessment.Services;

public interface IReservationService
{
    Task<Reservation> Reserve(Table table, DateTime dateTime, int numberOfPeople);
}

public class ReservationService : IReservationService
{
    private readonly IReservationRepository _reservationRepository;
    private readonly ApplicationDbContext _context;

    public ReservationService(IReservationRepository reservationRepository, ApplicationDbContext context)
    {
        _reservationRepository = reservationRepository;
        _context = context; // todo: need to move to repository somehow
    }
    
    public async Task<Reservation> Reserve(Table table, DateTime dateTime, int numberOfPeople)
    {
        await using var transaction = await _context.Database.BeginTransactionAsync();
        
        var reservedTablesQuantity = await _reservationRepository.GetReservationsCountByTableAndDateTime(table, dateTime);
        if (reservedTablesQuantity >= table.Quantity)
        {
            throw new InvalidDataException("All the tables are reserved");
        }

        var reservation = await _reservationRepository.CreateReservation(table, dateTime, numberOfPeople);
        await transaction.CommitAsync();
            
        return reservation;
    }
}