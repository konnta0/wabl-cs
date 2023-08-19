using Microsoft.Extensions.Options;

namespace Infrastructure.Core.Time;

public class FixedDateTimeHandler : IDateTimeHandler
{
    private TimeSpan _offset = TimeSpan.Zero;
    private TimeZoneInfo _timeZoneInfo;
    private readonly DateTimeOffset _dateTimeOffset = DateTimeOffset.UtcNow;

    public FixedDateTimeHandler(IOptions<TimeConfig> config)
    {
        _timeZoneInfo = config.Value.TimeZoneInfo;
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