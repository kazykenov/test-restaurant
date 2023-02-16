using MyAssessment.Model;

namespace MyAssessment.Services;

public interface ITimestampService
{
    long ConvertToTimestamp(DateTime dateTime);
}

public class TimestampService : ITimestampService
{
    private static readonly DateTime Epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

    public long ConvertToTimestamp(DateTime dateTime)
    {
        return (long) (dateTime.Date.AddHours(dateTime.Hour) - Epoch).TotalSeconds;
    }
}