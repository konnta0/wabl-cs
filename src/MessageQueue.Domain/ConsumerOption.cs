namespace MessageQueue.Domain;

public sealed class ConsumerOption
{
    public required Uri ServiceUrl { get; init; }
    public required string SubscriptionName { get; init; }
    public required string Topic { get; init; }
    public uint? MessagePrefetchCount { get; init; }
}