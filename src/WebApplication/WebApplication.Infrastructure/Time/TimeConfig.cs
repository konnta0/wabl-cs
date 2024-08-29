
namespace WebApplication.Infrastructure.Core.Time;

public sealed class TimeConfig
{
    public string TimeZoneId { get; init; } = Environment.GetEnvironmentVariable("TIME_ZONE_ID") ?? "Asia/Tokyo";
    public TimeZoneInfo TimeZoneInfo => TimeZoneConverter.TZConvert.GetTimeZoneInfo(TimeZoneId);
}