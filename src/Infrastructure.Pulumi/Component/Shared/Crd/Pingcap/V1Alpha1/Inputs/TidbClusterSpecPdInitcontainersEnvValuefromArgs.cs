// *** WARNING: this file was generated by crd2pulumi. ***
// *** Do not edit by hand unless you're certain you know what you are doing! ***

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading.Tasks;
using Pulumi.Serialization;

namespace Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1
{

    public class TidbClusterSpecPdInitContainersEnvValueFromArgs : global::Pulumi.ResourceArgs
    {
        [Input("configMapKeyRef")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterSpecPdInitContainersEnvValueFromConfigMapKeyRefArgs>? ConfigMapKeyRef { get; set; }

        [Input("fieldRef")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterSpecPdInitContainersEnvValueFromFieldRefArgs>? FieldRef { get; set; }

        [Input("resourceFieldRef")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterSpecPdInitContainersEnvValueFromResourceFieldRefArgs>? ResourceFieldRef { get; set; }

        [Input("secretKeyRef")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterSpecPdInitContainersEnvValueFromSecretKeyRefArgs>? SecretKeyRef { get; set; }

        public TidbClusterSpecPdInitContainersEnvValueFromArgs()
        {
        }
        public static new TidbClusterSpecPdInitContainersEnvValueFromArgs Empty => new TidbClusterSpecPdInitContainersEnvValueFromArgs();
    }
}
