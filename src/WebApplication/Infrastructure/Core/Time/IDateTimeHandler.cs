namespace Infrastructure.Core.Time;

public interface IDateTimeHandler
{
    void SetOffset(TimeSpan offset);
    void SetTimeZone(TimeZoneInfo timeZoneInfo);
    DateTime Now();
}