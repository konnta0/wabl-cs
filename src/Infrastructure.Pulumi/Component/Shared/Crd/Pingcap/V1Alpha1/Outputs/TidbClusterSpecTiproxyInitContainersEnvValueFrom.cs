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
    public sealed class TidbClusterSpecTiproxyInitContainersEnvValueFrom
    {
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecTiproxyInitContainersEnvValueFromConfigMapKeyRef ConfigMapKeyRef;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecTiproxyInitContainersEnvValueFromFieldRef FieldRef;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecTiproxyInitContainersEnvValueFromResourceFieldRef ResourceFieldRef;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecTiproxyInitContainersEnvValueFromSecretKeyRef SecretKeyRef;

        [OutputConstructor]
        private TidbClusterSpecTiproxyInitContainersEnvValueFrom(
            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecTiproxyInitContainersEnvValueFromConfigMapKeyRef configMapKeyRef,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecTiproxyInitContainersEnvValueFromFieldRef fieldRef,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecTiproxyInitContainersEnvValueFromResourceFieldRef resourceFieldRef,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecTiproxyInitContainersEnvValueFromSecretKeyRef secretKeyRef)
        {
            ConfigMapKeyRef = configMapKeyRef;
            FieldRef = fieldRef;
            ResourceFieldRef = resourceFieldRef;
            SecretKeyRef = secretKeyRef;
        }
    }
}
