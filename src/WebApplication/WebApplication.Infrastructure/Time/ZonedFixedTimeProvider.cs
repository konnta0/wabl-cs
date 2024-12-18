
namespace WebApplication.Infrastructure.Time;

public class ZonedFixedTimeProvider(TimeConfig config) : ZonedTimeProvider(config)
{
    public override DateTimeOffset GetUtcNow() => UtcNow.AddTicks(DiffTicks);
}