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
    
    public DateTime Now()
    {
        var now = DateTimeOffset.UtcNow;
        var truncatedDateTimeOffset = new DateTimeOffset(
            now.Year,
            now.Month,
            now.Day,
            now.Hour,
            now.Minute,
            now.Second,
            0, 
            _offset);
        return TimeZoneInfo.ConvertTime(truncatedDateTimeOffset.DateTime, _timeZoneInfo);
    }
}