// *** WARNING: this file was generated by crd2pulumi. ***
// *** Do not edit by hand unless you're certain you know what you are doing! ***

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading.Tasks;
using Pulumi.Serialization;

namespace Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1
{

    public class DMClusterSpecMasterInitContainersLifecyclePostStartArgs : global::Pulumi.ResourceArgs
    {
        [Input("exec")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.DMClusterSpecMasterInitContainersLifecyclePostStartExecArgs>? Exec { get; set; }

        [Input("httpGet")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.DMClusterSpecMasterInitContainersLifecyclePostStartHttpGetArgs>? HttpGet { get; set; }

        [Input("tcpSocket")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.DMClusterSpecMasterInitContainersLifecyclePostStartTcpSocketArgs>? TcpSocket { get; set; }

        public DMClusterSpecMasterInitContainersLifecyclePostStartArgs()
        {
        }
        public static new DMClusterSpecMasterInitContainersLifecyclePostStartArgs Empty => new DMClusterSpecMasterInitContainersLifecyclePostStartArgs();
    }
}
