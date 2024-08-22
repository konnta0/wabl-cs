using DotPulsar;
using DotPulsar.Abstractions;
using DotPulsar.Extensions;

namespace MessageQueue.Presentation.Worker;

internal sealed class Worker(ILogger<Worker> logger) : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken cancellationToken)
    {
        await using var client = PulsarClient.Builder()
            .ExceptionHandler(x =>
            {
                logger.LogCritical(x.Exception, "Got Exception. {Result}", x.Result);
            }) // Optional
            .Build(); // Connecting to pulsar://localhost:6650

        await using var consumer = client.NewConsumer(Schema.String)
            .StateChangedHandler(x =>
            {
                logger.LogInformation("Got SateChanged. {Topic}, {Result}", x.Consumer.Topic, x.ConsumerState);
            }) // Optional
            .SubscriptionName("MySubscription")
            .Topic("persistent://public/default/mytopic")
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

        List<IMessage<string>> messages = new(100);
        while (!cancellationToken.IsCancellationRequested)
        {
            var message = await consumer.Receive(cancellationToken);
            
            messages.Add(message);

            if (messages.Count is not 100) continue;

            foreach (var msg in messages)
            {
                var publishedOn = msg.PublishTimeAsDateTime;
                var payload = msg.Value();
                logger.LogInformation("{PublishedOn}: {Payload}", publishedOn, payload);
            }
            await consumer.AcknowledgeCumulative(messages.Last(), cancellationToken);
            messages.Clear();
        }
    }

    private ValueTask ProcessMessage(IMessage<string> message, CancellationToken cancellationToken)
    {
        var publishedOn = message.PublishTimeAsDateTime;
        var payload = message.Value();
        logger.LogInformation("{PublishedOn}: {Payload}", publishedOn, payload);
        return ValueTask.CompletedTask;
    }
}