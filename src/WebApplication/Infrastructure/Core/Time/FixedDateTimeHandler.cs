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
    
    public DateTime Now() => TimeZoneInfo.ConvertTime(_dateTimeOffset.Add(_offset).DateTime, _timeZoneInfo);
}