using DotPulsar;
using DotPulsar.Abstractions;
using DotPulsar.Extensions;
using MessageQueue.Domain;
using MessageQueue.Domain.DataTransferObject;
using Xunit.Abstractions;

namespace MessageQueue.Test;

public class UnitTest1(ITestOutputHelper testOutputHelper)
{

    [Fact]
    public async Task Test1()
    {
        var cts = new CancellationTokenSource();

        // await using var client = PulsarClient.Builder().Build(); // Connecting to pulsar://localhost:6650
        // await using var producer = client.NewProducer(CustomSchema.KpiLogSchema)
        //     .StateChangedHandler(Monitor)
        //     .Topic("persistent://public/default/kpilog")
        //     .Create();
        //
        // await ProduceMessages(producer, cts.Token);
        // Assert.True(true);
        // return;
        //
        // async Task ProduceMessages(IProducer<KpiLog> producer, CancellationToken cancellationToken)
        // {
        //     var delay = TimeSpan.FromSeconds(1);
        //
        //     try
        //     {
        //         for (var i = 0; i < 30; i++)
        //         {
        //             var data = new KpiLog("dummy", new { Value = i });
        //             _ = await producer.Send(data, cancellationToken);
        //             testOutputHelper.WriteLine($"Sent: {data}");
        //             await Task.Delay(delay, cancellationToken);
        //         }
        //     }
        //     catch
        //         (OperationCanceledException) // If not using the cancellationToken, then just dispose the producer and catch ObjectDisposedException instead
        //     {
        //     }
        //}

        void Monitor(ProducerStateChanged stateChanged)
        {
            var topic = stateChanged.Producer.Topic;
            var state = stateChanged.ProducerState;
            testOutputHelper.WriteLine($"The producer for topic '{topic}' changed state to '{state}'");
        }
    }
}