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
    public sealed class TidbClusterSpecPumpAdditionalContainersEnvValueFrom
    {
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecPumpAdditionalContainersEnvValueFromConfigMapKeyRef ConfigMapKeyRef;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecPumpAdditionalContainersEnvValueFromFieldRef FieldRef;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecPumpAdditionalContainersEnvValueFromResourceFieldRef ResourceFieldRef;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecPumpAdditionalContainersEnvValueFromSecretKeyRef SecretKeyRef;

        [OutputConstructor]
        private TidbClusterSpecPumpAdditionalContainersEnvValueFrom(
            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecPumpAdditionalContainersEnvValueFromConfigMapKeyRef configMapKeyRef,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecPumpAdditionalContainersEnvValueFromFieldRef fieldRef,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecPumpAdditionalContainersEnvValueFromResourceFieldRef resourceFieldRef,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecPumpAdditionalContainersEnvValueFromSecretKeyRef secretKeyRef)
        {
            ConfigMapKeyRef = configMapKeyRef;
            FieldRef = fieldRef;
            ResourceFieldRef = resourceFieldRef;
            SecretKeyRef = secretKeyRef;
        }
    }
}
