// *** WARNING: this file was generated by crd2pulumi. ***
// *** Do not edit by hand unless you're certain you know what you are doing! ***

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading.Tasks;
using Pulumi.Serialization;

namespace Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1
{

    [OutputType]
    public sealed class TidbMonitorSpecThanosGrpcServerTlsConfigCa
    {
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbMonitorSpecThanosGrpcServerTlsConfigCaConfigMap ConfigMap;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbMonitorSpecThanosGrpcServerTlsConfigCaSecret Secret;

        [OutputConstructor]
        private TidbMonitorSpecThanosGrpcServerTlsConfigCa(
            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbMonitorSpecThanosGrpcServerTlsConfigCaConfigMap configMap,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbMonitorSpecThanosGrpcServerTlsConfigCaSecret secret)
        {
            ConfigMap = configMap;
            Secret = secret;
        }
    }
}
