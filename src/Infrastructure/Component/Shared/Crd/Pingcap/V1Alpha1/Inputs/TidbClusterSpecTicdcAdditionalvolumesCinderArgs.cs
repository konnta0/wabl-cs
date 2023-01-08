// *** WARNING: this file was generated by crd2pulumi. ***
// *** Do not edit by hand unless you're certain you know what you are doing! ***

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading.Tasks;
using Pulumi.Serialization;

namespace Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1
{

    public class TidbClusterSpecTicdcAdditionalvolumesCinderArgs : Pulumi.ResourceArgs
    {
        [Input("fsType")]
        public Input<string>? FsType { get; set; }

        [Input("readOnly")]
        public Input<bool>? ReadOnly { get; set; }

        [Input("secretRef")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterSpecTicdcAdditionalvolumesCinderSecretrefArgs>? SecretRef { get; set; }

        [Input("volumeID", required: true)]
        public Input<string> VolumeID { get; set; } = null!;

        public TidbClusterSpecTicdcAdditionalvolumesCinderArgs()
        {
        }
    }
}