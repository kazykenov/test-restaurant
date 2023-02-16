using Microsoft.EntityFrameworkCore;
using MyAssessment.Data;
using MyAssessment.Model;

namespace MyAssessment.Services;

public interface IReservationRepository
{
    IEnumerable<Table> GetReservationsByTableAndDateTime(Table table, DateTime dateTime);

    Task<int> GetReservationsCountByTableAndDateTime(Table table, DateTime dateTime);

    Task<Reservation> CreateReservation(Table table, DateTime dateTime, int numberOfPeople);
}

public class ReservationRepository : IReservationRepository
{
    private readonly ApplicationDbContext _context;
    private readonly ITimestampService _timestampService;

    public ReservationRepository(ApplicationDbContext context, ITimestampService timestampService)
    {
        _context = context;
        _timestampService = timestampService;
    }

    public IEnumerable<Table> GetReservationsByTableAndDateTime(Table table, DateTime dateTime)
    {
        throw new NotImplementedException();
    }

    public async Task<int> GetReservationsCountByTableAndDateTime(Table table, DateTime dateTime)
    {
        var timestamp = _timestampService.ConvertToTimestamp(dateTime);
        return await _context.Reservation.CountAsync(reservation =>
            reservation.TableId == table.TableId && reservation.Timestamp == timestamp);
    }

    public async Task<Reservation> CreateReservation(Table table, DateTime dateTime, int numberOfPeople)
    {
        var timestamp = _timestampService.ConvertToTimestamp(dateTime);
        var reservation = new Reservation()
        {
            TableId = table.TableId,
            Timestamp = timestamp,
            NumberOfPeople = numberOfPeople,
        };
        
        await _context.Reservation.AddAsync(reservation); 
        await _context.SaveChangesAsync();

        return reservation;
    }
}