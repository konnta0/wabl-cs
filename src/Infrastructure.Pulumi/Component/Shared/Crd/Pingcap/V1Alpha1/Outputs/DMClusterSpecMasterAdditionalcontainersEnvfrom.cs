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
    public sealed class DMClusterSpecMasterAdditionalContainersEnvFrom
    {
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.DMClusterSpecMasterAdditionalContainersEnvFromConfigMapRef ConfigMapRef;
        public readonly string Prefix;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.DMClusterSpecMasterAdditionalContainersEnvFromSecretRef SecretRef;

        [OutputConstructor]
        private DMClusterSpecMasterAdditionalContainersEnvFrom(
            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.DMClusterSpecMasterAdditionalContainersEnvFromConfigMapRef configMapRef,

            string prefix,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.DMClusterSpecMasterAdditionalContainersEnvFromSecretRef secretRef)
        {
            ConfigMapRef = configMapRef;
            Prefix = prefix;
            SecretRef = secretRef;
        }
    }
}
