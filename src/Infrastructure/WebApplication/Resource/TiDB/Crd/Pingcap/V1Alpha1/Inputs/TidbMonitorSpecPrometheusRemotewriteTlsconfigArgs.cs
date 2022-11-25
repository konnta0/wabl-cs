// *** WARNING: this file was generated by crd2pulumi. ***
// *** Do not edit by hand unless you're certain you know what you are doing! ***

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading.Tasks;
using Pulumi.Serialization;

namespace Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1
{

    public class TidbMonitorSpecPrometheusRemotewriteTlsconfigArgs : Pulumi.ResourceArgs
    {
        [Input("ca")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbMonitorSpecPrometheusRemotewriteTlsconfigCaArgs>? Ca { get; set; }

        [Input("caFile")]
        public Input<string>? CaFile { get; set; }

        [Input("cert")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbMonitorSpecPrometheusRemotewriteTlsconfigCertArgs>? Cert { get; set; }

        [Input("certFile")]
        public Input<string>? CertFile { get; set; }

        [Input("insecureSkipVerify")]
        public Input<bool>? InsecureSkipVerify { get; set; }

        [Input("keyFile")]
        public Input<string>? KeyFile { get; set; }

        [Input("keySecret")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbMonitorSpecPrometheusRemotewriteTlsconfigKeysecretArgs>? KeySecret { get; set; }

        [Input("serverName")]
        public Input<string>? ServerName { get; set; }

        public TidbMonitorSpecPrometheusRemotewriteTlsconfigArgs()
        {
        }
    }
}
