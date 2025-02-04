// *** WARNING: this file was generated by crd2pulumi. ***
// *** Do not edit by hand unless you're certain you know what you are doing! ***

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading.Tasks;
using Pulumi.Serialization;

namespace Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1
{

    public class TidbNGMonitoringSpecNgMonitoringInitContainersPortsArgs : global::Pulumi.ResourceArgs
    {
        [Input("containerPort", required: true)]
        public Input<int> ContainerPort { get; set; } = null!;

        [Input("hostIP")]
        public Input<string>? HostIP { get; set; }

        [Input("hostPort")]
        public Input<int>? HostPort { get; set; }

        [Input("name")]
        public Input<string>? Name { get; set; }

        [Input("protocol")]
        public Input<string>? Protocol { get; set; }

        public TidbNGMonitoringSpecNgMonitoringInitContainersPortsArgs()
        {
            Protocol = "TCP";
        }
        public static new TidbNGMonitoringSpecNgMonitoringInitContainersPortsArgs Empty => new TidbNGMonitoringSpecNgMonitoringInitContainersPortsArgs();
    }
}
