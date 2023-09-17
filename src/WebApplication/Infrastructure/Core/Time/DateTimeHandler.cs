using Microsoft.Extensions.Options;

namespace Infrastructure.Core.Time;

public class DateTimeHandler : IDateTimeHandler
{
    private TimeSpan _offset = TimeSpan.Zero;
    private readonly TimeZoneInfo _timeZoneInfo;

    public DateTimeHandler(IOptions<TimeConfig> config)
    {
        _timeZoneInfo = config.Value.TimeZoneInfo;
    }

    public void SetOffset(TimeSpan offset) => _offset = offset;

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