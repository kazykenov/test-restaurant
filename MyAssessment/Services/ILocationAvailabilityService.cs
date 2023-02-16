using MyAssessment.Model;

namespace MyAssessment.Services;

// Abstract from where to fetch open-close hours
public interface ILocationAvailabilityService
{
    Task<bool> IsDatetimeAvailable(Location location, DateTime dateTime);
}

// in our implementation it will be inside our "locations" table.
public class LocationAvailabilityService : ILocationAvailabilityService
{
    public Task<bool> IsDatetimeAvailable(Location location, DateTime dateTime)
    {
        var isClosingNextDay = location.ClosingHour <= location.OpeningHour;
        var hour = dateTime.Hour;

        if (!isClosingNextDay)
        {
            return Task.FromResult(location.OpeningHour <= hour && hour <= location.ClosingHour);
        }

        return Task.FromResult(
            (location.OpeningHour <= hour && hour <= 23) ||
            (0 <= hour && hour <= location.ClosingHour));
    }
}

// we can also add another implementation to make open-close hours different each day, add holidays, or even
// create another microservice, which will be responsible for availability, and our implementation here will just be a 
// http client