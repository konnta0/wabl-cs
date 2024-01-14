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
    public sealed class TidbClusterSpecPdEnvFrom
    {
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecPdEnvFromConfigMapRef ConfigMapRef;
        public readonly string Prefix;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecPdEnvFromSecretRef SecretRef;

        [OutputConstructor]
        private TidbClusterSpecPdEnvFrom(
            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecPdEnvFromConfigMapRef configMapRef,

            string prefix,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecPdEnvFromSecretRef secretRef)
        {
            ConfigMapRef = configMapRef;
            Prefix = prefix;
            SecretRef = secretRef;
        }
    }
}
