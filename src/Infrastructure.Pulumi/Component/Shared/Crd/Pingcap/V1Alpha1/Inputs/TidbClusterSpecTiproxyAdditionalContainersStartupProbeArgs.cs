// *** WARNING: this file was generated by crd2pulumi. ***
// *** Do not edit by hand unless you're certain you know what you are doing! ***

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading.Tasks;
using Pulumi.Serialization;

namespace Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1
{

    public class TidbClusterSpecTiproxyAdditionalContainersStartupProbeArgs : global::Pulumi.ResourceArgs
    {
        [Input("exec")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterSpecTiproxyAdditionalContainersStartupProbeExecArgs>? Exec { get; set; }

        [Input("failureThreshold")]
        public Input<int>? FailureThreshold { get; set; }

        [Input("httpGet")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterSpecTiproxyAdditionalContainersStartupProbeHttpGetArgs>? HttpGet { get; set; }

        [Input("initialDelaySeconds")]
        public Input<int>? InitialDelaySeconds { get; set; }

        [Input("periodSeconds")]
        public Input<int>? PeriodSeconds { get; set; }

        [Input("successThreshold")]
        public Input<int>? SuccessThreshold { get; set; }

        [Input("tcpSocket")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterSpecTiproxyAdditionalContainersStartupProbeTcpSocketArgs>? TcpSocket { get; set; }

        [Input("timeoutSeconds")]
        public Input<int>? TimeoutSeconds { get; set; }

        public TidbClusterSpecTiproxyAdditionalContainersStartupProbeArgs()
        {
        }
        public static new TidbClusterSpecTiproxyAdditionalContainersStartupProbeArgs Empty => new TidbClusterSpecTiproxyAdditionalContainersStartupProbeArgs();
    }
}
