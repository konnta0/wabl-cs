// *** WARNING: this file was generated by crd2pulumi. ***
// *** Do not edit by hand unless you're certain you know what you are doing! ***

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading.Tasks;
using Pulumi.Serialization;

namespace Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1
{

    public class TidbMonitorSpecThanosGrpcServerTlsConfigCaArgs : global::Pulumi.ResourceArgs
    {
        [Input("configMap")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbMonitorSpecThanosGrpcServerTlsConfigCaConfigMapArgs>? ConfigMap { get; set; }

        [Input("secret")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbMonitorSpecThanosGrpcServerTlsConfigCaSecretArgs>? Secret { get; set; }

        public TidbMonitorSpecThanosGrpcServerTlsConfigCaArgs()
        {
        }
        public static new TidbMonitorSpecThanosGrpcServerTlsConfigCaArgs Empty => new TidbMonitorSpecThanosGrpcServerTlsConfigCaArgs();
    }
}
