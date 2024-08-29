
namespace WebApplication.Infrastructure.Core.Time;

public class ZonedTimeProvider(TimeConfig config) : MutableTimeProvider
{
    public override TimeZoneInfo LocalTimeZone { get; } = config.TimeZoneInfo;
}