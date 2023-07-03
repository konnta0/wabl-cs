namespace Infrastructure.Core.Time;

public class FixedDateTimeHandler : IDateTimeHandler
{
    private TimeSpan _offset;
    private TimeZoneInfo _timeZoneInfo;
    private readonly DateTimeOffset _dateTimeOffset;

    public FixedDateTimeHandler()
    {
        _offset = TimeSpan.Zero;
        _timeZoneInfo = TimeZoneInfo.Utc;
        _dateTimeOffset = DateTimeOffset.UtcNow;
    }

    public void SetOffset(TimeSpan offset) => _offset = offset;
    
    public void SetTimeZone(TimeZoneInfo timeZoneInfo) => _timeZoneInfo = timeZoneInfo;
    
    public DateTime Now()
    {
        var truncatedDateTimeOffset = new DateTimeOffset(
            _dateTimeOffset.Year,
            _dateTimeOffset.Month,
            _dateTimeOffset.Day,
            _dateTimeOffset.Hour,
            _dateTimeOffset.Minute,
            _dateTimeOffset.Second,
            0, 
            _dateTimeOffset.Offset + _offset);
        return TimeZoneInfo.ConvertTime(truncatedDateTimeOffset.DateTime, _timeZoneInfo);
    }
}