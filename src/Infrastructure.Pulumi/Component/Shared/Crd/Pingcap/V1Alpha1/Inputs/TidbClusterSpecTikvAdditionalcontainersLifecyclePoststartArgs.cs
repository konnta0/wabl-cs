// *** WARNING: this file was generated by crd2pulumi. ***
// *** Do not edit by hand unless you're certain you know what you are doing! ***

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading.Tasks;
using Pulumi.Serialization;

namespace Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1
{

    public class TidbClusterSpecTikvAdditionalContainersLifecyclePostStartArgs : global::Pulumi.ResourceArgs
    {
        [Input("exec")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterSpecTikvAdditionalContainersLifecyclePostStartExecArgs>? Exec { get; set; }

        [Input("httpGet")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterSpecTikvAdditionalContainersLifecyclePostStartHttpGetArgs>? HttpGet { get; set; }

        [Input("tcpSocket")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterSpecTikvAdditionalContainersLifecyclePostStartTcpSocketArgs>? TcpSocket { get; set; }

        public TidbClusterSpecTikvAdditionalContainersLifecyclePostStartArgs()
        {
        }
        public static new TidbClusterSpecTikvAdditionalContainersLifecyclePostStartArgs Empty => new TidbClusterSpecTikvAdditionalContainersLifecyclePostStartArgs();
    }
}
