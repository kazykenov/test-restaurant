using MyAssessment.Model;
using MyAssessment.Services;

namespace MyAssessment.Test;

public class LocationAvailabilityServiceTests
{
    private readonly ILocationAvailabilityService _service = new LocationAvailabilityService();

    [SetUp]
    public void Setup()
    {
        
    }

    [Test]
    public void IsDatetimeAvailable_WhenDatetimeBetweenOpenCloseHours_ReturnsTrue()
    {
        var location = new Location
        {
            OpeningHour = 10,
            ClosingHour = 20
        };

        Assert.IsTrue(_service.IsDatetimeAvailable(location, new DateTime(2022, 02, 02, 13, 0, 0)));
    }

    [Test]
    public void IsDatetimeAvailable_WhenDatetimeNotBetweenOpenCloseHours_ReturnsFalse()
    {
        var location = new Location
        {
            OpeningHour = 10,
            ClosingHour = 20
        };

        Assert.IsFalse(_service.IsDatetimeAvailable(location, new DateTime(2022, 02, 02, 9, 0, 0)));
    }

    [Test]
    public void IsDatetimeAvailable_WhenCloseHourLessThanOpenHourAndDatetimeBetweenOpenCloseHours_ReturnsTrue()
    {
        var location = new Location
        {
            OpeningHour = 20,
            ClosingHour = 10
        };

        Assert.IsTrue(_service.IsDatetimeAvailable(location, new DateTime(2022, 02, 02, 5, 0, 0)));
    }

    [Test]
    public void IsDatetimeAvailable_WhenCloseHourLessThanOpenHourAndDatetimeNotBetweenOpenCloseHours_ReturnsFalse()
    {
        var location = new Location
        {
            OpeningHour = 20,
            ClosingHour = 10
        };

        Assert.IsFalse(_service.IsDatetimeAvailable(location, new DateTime(2022, 02, 02, 15, 0, 0)));
    }

    [Test]
    public void IsDatetimeAvailable_WhenAlwaysAvailable_ReturnsTrue()
    {
        Assert.IsTrue(_service.IsDatetimeAvailable(new Location
        {
            OpeningHour = 0,
            ClosingHour = 0
        }, new DateTime(2022, 02, 02, 15, 0, 0)));

        Assert.IsTrue(_service.IsDatetimeAvailable(new Location
        {
            OpeningHour = 12,
            ClosingHour = 12
        }, new DateTime(2022, 02, 02, 15, 0, 0)));
    }
}