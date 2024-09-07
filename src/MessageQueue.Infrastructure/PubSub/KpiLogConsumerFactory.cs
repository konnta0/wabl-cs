using DotPulsar;
using DotPulsar.Abstractions;
using DotPulsar.Extensions;
using MessageQueue.Application;
using MessageQueue.Domain;
using MessageQueue.Domain.DataTransferObject;
using Microsoft.Extensions.Logging;

namespace MessageQueue.Infrastructure.PubSub;

public class KpiLogConsumerFactory(ILogger<KpiLogConsumerFactory> logger) : IConsumerFactory<KpiLog>
{
    public async Task<IConsumer<KpiLog>> CreateAsync(
        Action<ConsumerOption>? consumerOption = null,
        CancellationToken cancellationToken = default)
    {
        var option = new ConsumerOption
        {
            SubscriptionName = "KpiLog",
            Topic = "persistent://public/default/kpilog",
            ServiceUrl = new Uri("pulsar://localhost:6650")
        };
        consumerOption?.Invoke(option);
        
        await using var client = PulsarClient.Builder()
            .ServiceUrl(option.ServiceUrl)
            .ExceptionHandler(x =>
            {
                logger.LogCritical(x.Exception, "Got Exception. {Result}", x.Result);
            })
            .Build();

        var consumer = client.NewConsumer(CustomSchema.KpiLogSchema)
            .StateChangedHandler(x =>
            {
                logger.LogInformation("Got SateChanged. {Topic}, {Result}", x.Consumer.Topic, x.ConsumerState);
            })
            .SubscriptionName(option.SubscriptionName)
            .Topic(option.Topic)
            .MessagePrefetchCount(option.MessagePrefetchCount ?? 1000)
            .Create();

        _ = consumer.DelayedStateMonitor(  // Recommended way of ignoring the short disconnects expected when working with a distributed system
            ConsumerState.Active,          // Operational state
            TimeSpan.FromSeconds(5), // The amount of time allowed in non-operational state before we act
            (x, state, ctx) =>
            {
                logger.LogInformation("Got onStateLeft. {Topic}, {Result}", x.Topic, state);
                return ValueTask.CompletedTask;
            },     // Invoked if we are NOT back in operational state after 5 seconds
            (x, state, ctx) =>
            {
                logger.LogInformation("Got onStateReached. {Topic}, {Result}", x.Topic, state);
                return ValueTask.CompletedTask;
            }, // Invoked when we are in operational state again
            cancellationToken);

        return consumer;
    }
}