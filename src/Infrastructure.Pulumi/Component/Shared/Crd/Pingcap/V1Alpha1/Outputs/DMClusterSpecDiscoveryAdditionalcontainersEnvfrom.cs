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
    public sealed class DMClusterSpecDiscoveryAdditionalcontainersEnvfrom
    {
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.DMClusterSpecDiscoveryAdditionalcontainersEnvfromConfigmapref ConfigMapRef;
        public readonly string Prefix;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.DMClusterSpecDiscoveryAdditionalcontainersEnvfromSecretref SecretRef;

        [OutputConstructor]
        private DMClusterSpecDiscoveryAdditionalcontainersEnvfrom(
            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.DMClusterSpecDiscoveryAdditionalcontainersEnvfromConfigmapref configMapRef,

            string prefix,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.DMClusterSpecDiscoveryAdditionalcontainersEnvfromSecretref secretRef)
        {
            ConfigMapRef = configMapRef;
            Prefix = prefix;
            SecretRef = secretRef;
        }
    }
}