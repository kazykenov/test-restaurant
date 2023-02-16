using MyAssessment.Model;

namespace MyAssessment.Services;

// Abstract from where to fetch open-close hours
public interface ILocationAvailabilityService
{
    bool IsDatetimeAvailable(Location location, DateTime dateTime);
}

// in our implementation it will be inside our "locations" table.
public class LocationAvailabilityService : ILocationAvailabilityService
{
    public bool IsDatetimeAvailable(Location location, DateTime dateTime)
    {
        var isClosingNextDay = location.ClosingHour <= location.OpeningHour;
        var openingDate = dateTime.Date;
        var closingDate = dateTime.Date.AddHours(location.ClosingHour).AddDays(isClosingNextDay ? 1 : 0);
        
        return dateTime >= openingDate && dateTime <= closingDate;
    }
}

// we can also add another implementation to make open-close hours different each day, add holidays, or even
// create another microservice, which will be responsible for availability, and our implementation here will just be a 
// http client