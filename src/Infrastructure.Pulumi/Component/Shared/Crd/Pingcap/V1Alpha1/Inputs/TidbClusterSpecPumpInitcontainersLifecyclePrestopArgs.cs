// *** WARNING: this file was generated by crd2pulumi. ***
// *** Do not edit by hand unless you're certain you know what you are doing! ***

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading.Tasks;
using Pulumi.Serialization;

namespace Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1
{

    public class TidbClusterSpecPumpInitContainersLifecyclePreStopArgs : global::Pulumi.ResourceArgs
    {
        [Input("exec")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterSpecPumpInitContainersLifecyclePreStopExecArgs>? Exec { get; set; }

        [Input("httpGet")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterSpecPumpInitContainersLifecyclePreStopHttpGetArgs>? HttpGet { get; set; }

        [Input("tcpSocket")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterSpecPumpInitContainersLifecyclePreStopTcpSocketArgs>? TcpSocket { get; set; }

        public TidbClusterSpecPumpInitContainersLifecyclePreStopArgs()
        {
        }
        public static new TidbClusterSpecPumpInitContainersLifecyclePreStopArgs Empty => new TidbClusterSpecPumpInitContainersLifecyclePreStopArgs();
    }
}
