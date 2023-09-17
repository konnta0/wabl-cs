namespace Infrastructure.Core.Time;

public interface IDateTimeHandler
{
    void SetOffset(TimeSpan offset);
    DateTime Now();
}