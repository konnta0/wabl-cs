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
    public sealed class TidbMonitorSpecAdditionalContainersEnvFrom
    {
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbMonitorSpecAdditionalContainersEnvFromConfigMapRef ConfigMapRef;
        public readonly string Prefix;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbMonitorSpecAdditionalContainersEnvFromSecretRef SecretRef;

        [OutputConstructor]
        private TidbMonitorSpecAdditionalContainersEnvFrom(
            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbMonitorSpecAdditionalContainersEnvFromConfigMapRef configMapRef,

            string prefix,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbMonitorSpecAdditionalContainersEnvFromSecretRef secretRef)
        {
            ConfigMapRef = configMapRef;
            Prefix = prefix;
            SecretRef = secretRef;
        }
    }
}
