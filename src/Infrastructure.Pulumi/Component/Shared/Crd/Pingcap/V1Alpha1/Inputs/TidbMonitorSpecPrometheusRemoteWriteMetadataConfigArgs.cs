// *** WARNING: this file was generated by crd2pulumi. ***
// *** Do not edit by hand unless you're certain you know what you are doing! ***

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading.Tasks;
using Pulumi.Serialization;

namespace Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1
{

    public class TidbMonitorSpecPrometheusRemoteWriteMetadataConfigArgs : global::Pulumi.ResourceArgs
    {
        [Input("send")]
        public Input<bool>? Send { get; set; }

        [Input("sendInterval")]
        public Input<string>? SendInterval { get; set; }

        public TidbMonitorSpecPrometheusRemoteWriteMetadataConfigArgs()
        {
        }
        public static new TidbMonitorSpecPrometheusRemoteWriteMetadataConfigArgs Empty => new TidbMonitorSpecPrometheusRemoteWriteMetadataConfigArgs();
    }
}
