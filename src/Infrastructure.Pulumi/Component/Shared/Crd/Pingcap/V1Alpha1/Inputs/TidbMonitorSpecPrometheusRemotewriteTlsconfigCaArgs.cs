// *** WARNING: this file was generated by crd2pulumi. ***
// *** Do not edit by hand unless you're certain you know what you are doing! ***

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading.Tasks;
using Pulumi.Serialization;

namespace Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1
{

    public class TidbMonitorSpecPrometheusRemoteWriteTlsConfigCaArgs : global::Pulumi.ResourceArgs
    {
        [Input("configMap")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbMonitorSpecPrometheusRemoteWriteTlsConfigCaConfigMapArgs>? ConfigMap { get; set; }

        [Input("secret")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbMonitorSpecPrometheusRemoteWriteTlsConfigCaSecretArgs>? Secret { get; set; }

        public TidbMonitorSpecPrometheusRemoteWriteTlsConfigCaArgs()
        {
        }
        public static new TidbMonitorSpecPrometheusRemoteWriteTlsConfigCaArgs Empty => new TidbMonitorSpecPrometheusRemoteWriteTlsConfigCaArgs();
    }
}
