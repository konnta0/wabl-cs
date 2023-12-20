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
    public sealed class DMClusterSpecDiscoveryAdditionalvolumesProjectedSources
    {
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.DMClusterSpecDiscoveryAdditionalvolumesProjectedSourcesConfigmap ConfigMap;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.DMClusterSpecDiscoveryAdditionalvolumesProjectedSourcesDownwardapi DownwardAPI;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.DMClusterSpecDiscoveryAdditionalvolumesProjectedSourcesSecret Secret;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.DMClusterSpecDiscoveryAdditionalvolumesProjectedSourcesServiceaccounttoken ServiceAccountToken;

        [OutputConstructor]
        private DMClusterSpecDiscoveryAdditionalvolumesProjectedSources(
            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.DMClusterSpecDiscoveryAdditionalvolumesProjectedSourcesConfigmap configMap,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.DMClusterSpecDiscoveryAdditionalvolumesProjectedSourcesDownwardapi downwardAPI,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.DMClusterSpecDiscoveryAdditionalvolumesProjectedSourcesSecret secret,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.DMClusterSpecDiscoveryAdditionalvolumesProjectedSourcesServiceaccounttoken serviceAccountToken)
        {
            ConfigMap = configMap;
            DownwardAPI = downwardAPI;
            Secret = secret;
            ServiceAccountToken = serviceAccountToken;
        }
    }
}