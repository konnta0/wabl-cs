// *** WARNING: this file was generated by crd2pulumi. ***
// *** Do not edit by hand unless you're certain you know what you are doing! ***

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading.Tasks;
using Pulumi.Serialization;

namespace Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1
{

    public class TidbMonitorSpecPrometheusRemoteWriteQueueConfigArgs : global::Pulumi.ResourceArgs
    {
        [Input("batchSendDeadline")]
        public Input<int>? BatchSendDeadline { get; set; }

        [Input("capacity")]
        public Input<int>? Capacity { get; set; }

        [Input("maxBackoff")]
        public Input<int>? MaxBackoff { get; set; }

        [Input("maxRetries")]
        public Input<int>? MaxRetries { get; set; }

        [Input("maxSamplesPerSend")]
        public Input<int>? MaxSamplesPerSend { get; set; }

        [Input("maxShards")]
        public Input<int>? MaxShards { get; set; }

        [Input("minBackoff")]
        public Input<int>? MinBackoff { get; set; }

        [Input("minShards")]
        public Input<int>? MinShards { get; set; }

        public TidbMonitorSpecPrometheusRemoteWriteQueueConfigArgs()
        {
        }
        public static new TidbMonitorSpecPrometheusRemoteWriteQueueConfigArgs Empty => new TidbMonitorSpecPrometheusRemoteWriteQueueConfigArgs();
    }
}
