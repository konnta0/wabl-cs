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
    public sealed class TidbClusterSpecTiflashEnvfrom
    {
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecTiflashEnvfromConfigmapref ConfigMapRef;
        public readonly string Prefix;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecTiflashEnvfromSecretref SecretRef;

        [OutputConstructor]
        private TidbClusterSpecTiflashEnvfrom(
            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecTiflashEnvfromConfigmapref configMapRef,

            string prefix,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecTiflashEnvfromSecretref secretRef)
        {
            ConfigMapRef = configMapRef;
            Prefix = prefix;
            SecretRef = secretRef;
        }
    }
}
