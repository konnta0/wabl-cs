// *** WARNING: this file was generated by crd2pulumi. ***
// *** Do not edit by hand unless you're certain you know what you are doing! ***

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading.Tasks;
using Pulumi.Serialization;

namespace Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1
{

    public class DMClusterSpecDiscoveryEnvValueFromArgs : global::Pulumi.ResourceArgs
    {
        [Input("configMapKeyRef")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.DMClusterSpecDiscoveryEnvValueFromConfigMapKeyRefArgs>? ConfigMapKeyRef { get; set; }

        [Input("fieldRef")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.DMClusterSpecDiscoveryEnvValueFromFieldRefArgs>? FieldRef { get; set; }

        [Input("resourceFieldRef")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.DMClusterSpecDiscoveryEnvValueFromResourceFieldRefArgs>? ResourceFieldRef { get; set; }

        [Input("secretKeyRef")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.DMClusterSpecDiscoveryEnvValueFromSecretKeyRefArgs>? SecretKeyRef { get; set; }

        public DMClusterSpecDiscoveryEnvValueFromArgs()
        {
        }
        public static new DMClusterSpecDiscoveryEnvValueFromArgs Empty => new DMClusterSpecDiscoveryEnvValueFromArgs();
    }
}
