
namespace WebApplication.Infrastructure.Time;

public class ZonedTimeProvider(TimeConfig config) : MutableTimeProvider
{
    public override TimeZoneInfo LocalTimeZone { get; } = config.TimeZoneInfo;
}