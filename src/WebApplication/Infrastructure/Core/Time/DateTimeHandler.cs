namespace Infrastructure.Core.Time;

public class DateTimeHandler : IDateTimeHandler
{
    private TimeSpan _offset;
    private TimeZoneInfo _timeZoneInfo;

    public DateTimeHandler()
    {
        _offset = TimeSpan.Zero;
        _timeZoneInfo = TimeZoneInfo.Utc;
    }

    public void SetOffset(TimeSpan offset) => _offset = offset;
    
    public void SetTimeZone(TimeZoneInfo timeZoneInfo) => _timeZoneInfo = timeZoneInfo;
    
    public DateTime Now() => TimeZoneInfo.ConvertTime(DateTimeOffset.UtcNow.Add(_offset).DateTime, _timeZoneInfo);
}