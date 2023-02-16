using MyAssessment.Services;

namespace MyAssessment.Test;

public class TimestampServiceTests
{
    private TimestampService _service;

    [SetUp]
    public void Setup()
    {
        _service = new TimestampService();
    }

    [Test]
    public void ConvertToTimestamp_WhenLingeringMinutesAndSeconds_ReturnsFlooredToHours()
    {
        var dateTime = new DateTime(2023, 03, 03, 12, 42, 42);

        var timestamp = _service.ConvertToTimestamp(dateTime);
        
        Assert.That(timestamp, Is.EqualTo(1677844800));
    }
    
    [Test]
    public void ConvertToTimestamp_WhenFloored_ReturnsSameValueInTimestamp()
    {
        var dateTime = new DateTime(2001, 01, 01, 02, 00, 00);

        var timestamp = _service.ConvertToTimestamp(dateTime);
        
        Assert.That(timestamp, Is.EqualTo(978314400));
    }
}