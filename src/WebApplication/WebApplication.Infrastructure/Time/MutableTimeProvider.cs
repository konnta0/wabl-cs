namespace WebApplication.Infrastructure.Time;

public abstract class MutableTimeProvider : TimeProvider
{
    protected DateTimeOffset UtcNow = DateTimeOffset.UtcNow;
    protected long DiffTicks;
    protected long UpdatedTicks = DateTimeOffset.UtcNow.Ticks;

    public virtual void SetDiffTicks(long ticks) => DiffTicks = ticks;

    public virtual void SetUtcNow(DateTimeOffset utcNow)
    {
        SetDiffTicks(utcNow.Ticks - DateTimeOffset.UtcNow.Ticks);
        UtcNow = utcNow;
        UpdatedTicks = DateTimeOffset.UtcNow.Ticks;
    }

    public override DateTimeOffset GetUtcNow()
    {
        return UtcNow.AddTicks(DiffTicks + DateTimeOffset.UtcNow.Ticks - UpdatedTicks);
    }
}