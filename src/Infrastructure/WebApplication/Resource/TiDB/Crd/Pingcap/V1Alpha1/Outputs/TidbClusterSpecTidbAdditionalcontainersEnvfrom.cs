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
    public sealed class TidbClusterSpecTidbAdditionalcontainersEnvfrom
    {
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecTidbAdditionalcontainersEnvfromConfigmapref ConfigMapRef;
        public readonly string Prefix;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecTidbAdditionalcontainersEnvfromSecretref SecretRef;

        [OutputConstructor]
        private TidbClusterSpecTidbAdditionalcontainersEnvfrom(
            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecTidbAdditionalcontainersEnvfromConfigmapref configMapRef,

            string prefix,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecTidbAdditionalcontainersEnvfromSecretref secretRef)
        {
            ConfigMapRef = configMapRef;
            Prefix = prefix;
            SecretRef = secretRef;
        }
    }
}
