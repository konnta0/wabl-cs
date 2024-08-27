using System.Text.Json;
using DotPulsar;
using DotPulsar.Abstractions;
using DotPulsar.Extensions;
using MessageQueue.Domain;
using MessageQueue.Domain.DataTransferObject;

namespace MessageQueue.Presentation.Worker;

internal sealed class KpiLogWorker(ILogger<KpiLogWorker> logger) : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken cancellationToken)
    {
        await using var client = PulsarClient.Builder()
            .ExceptionHandler(x =>
            {
                logger.LogCritical(x.Exception, "Got Exception. {Result}", x.Result);
            }) // Optional
            .Build(); // Connecting to pulsar://localhost:6650

        await using var consumer = client.NewConsumer(CustomSchema.KpiLogSchema)
            .StateChangedHandler(x =>
            {
                logger.LogInformation("Got SateChanged. {Topic}, {Result}", x.Consumer.Topic, x.ConsumerState);
            }) // Optional
            .SubscriptionName("KpiLog")
            .Topic("persistent://public/default/kpilog")
            .MessagePrefetchCount(100)
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

        const int capacity = 5;
        List<IMessage<KpiLog>> messages = new(capacity);
        while (!cancellationToken.IsCancellationRequested)
        {
            var message = await consumer.Receive(cancellationToken);
            
            messages.Add(message);

            if (messages.Count is not capacity) continue;

            foreach (var msg in messages)
            {
                var publishedOn = msg.PublishTimeAsDateTime;
                var payload = msg.Value();
                logger.LogInformation("{PublishedOn}: {LogType}, {}", publishedOn, payload.LogType, JsonSerializer.Serialize(payload.Message));
            }
            await consumer.AcknowledgeCumulative(messages.Last(), cancellationToken);
            messages.Clear();
        }
    }
}