using DotPulsar.Abstractions;
using MessageQueue.Domain;

namespace MessageQueue.Application;

public interface IConsumerFactory<T>
{
    Task<IConsumer<T>> CreateAsync(
        Action<ConsumerOption>? consumerOption = null, 
        CancellationToken cancellationToken = default);
}