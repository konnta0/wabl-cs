// *** WARNING: this file was generated by crd2pulumi. ***
// *** Do not edit by hand unless you're certain you know what you are doing! ***

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading.Tasks;
using Pulumi.Serialization;

namespace Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1
{

    public class TidbClusterSpecPdInitcontainersEnvValuefromArgs : Pulumi.ResourceArgs
    {
        [Input("configMapKeyRef")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterSpecPdInitcontainersEnvValuefromConfigmapkeyrefArgs>? ConfigMapKeyRef { get; set; }

        [Input("fieldRef")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterSpecPdInitcontainersEnvValuefromFieldrefArgs>? FieldRef { get; set; }

        [Input("resourceFieldRef")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterSpecPdInitcontainersEnvValuefromResourcefieldrefArgs>? ResourceFieldRef { get; set; }

        [Input("secretKeyRef")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterSpecPdInitcontainersEnvValuefromSecretkeyrefArgs>? SecretKeyRef { get; set; }

        public TidbClusterSpecPdInitcontainersEnvValuefromArgs()
        {
        }
    }
}
