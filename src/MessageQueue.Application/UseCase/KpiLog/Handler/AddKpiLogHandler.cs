using System.Text.Json;
using DotPulsar.Abstractions;
using DotPulsar.Extensions;
using MessageQueue.Application.RequestHandler;
using MessageQueue.Application.UseCase.KpiLog.DataTransferObject;
using MessageQueue.Application.UseCase.KpiLog.ExecutionResult;
using Microsoft.Extensions.Logging;

namespace MessageQueue.Application.UseCase.KpiLog.Handler;

internal sealed class AddKpiLogHandler (
    IUseCaseActivityStarter activityStarter,
    ILogger<AddKpiLogHandler> logger,
    IConsumerFactory<Domain.DataTransferObject.KpiLog> factory)
    : AsyncUseCaseRequestHandlerBase<AddKpiLogUseCaseInput, AddKpiLogExecutionResult>(activityStarter)
{
    protected override ValueTask ValidateAsync(AddKpiLogUseCaseInput input, CancellationToken cancellationToken = new ())
    {
        return ValueTask.CompletedTask;
    }

    protected override async ValueTask<AddKpiLogExecutionResult> ExecuteAsync(AddKpiLogUseCaseInput input, CancellationToken cancellationToken = new ())
    {
        var consumer = await factory.CreateAsync(cancellationToken:cancellationToken);
        const int capacity = 5;
        List<IMessage<Domain.DataTransferObject.KpiLog>> messages = new(capacity);
        while (!cancellationToken.IsCancellationRequested)
        {
            var message = await consumer.Receive(cancellationToken);
            messages.Add(message);

            if (messages.Count is not capacity) continue;

            using var activity = ActivityStarter.Start();
            foreach (var msg in messages)
            {
                var publishedOn = msg.PublishTimeAsDateTime;
                var payload = msg.Value();
                logger.LogInformation("{PublishedOn}: {LogType}, {}", publishedOn, payload.LogType, JsonSerializer.Serialize(payload.Message));
            }
            await consumer.AcknowledgeCumulative(messages.Last(), cancellationToken);
            messages.Clear();
        }
        return new AddKpiLogExecutionResult();
    }

    protected override ValueTask<IUseCaseOutput> CollectResponseAsync(AddKpiLogUseCaseInput input, AddKpiLogExecutionResult executionResult,
        CancellationToken cancellationToken = new ())
    {
        return new ValueTask<IUseCaseOutput>(new AddKpiLogUseCaseOutput());
    }
}