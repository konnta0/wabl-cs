// *** WARNING: this file was generated by crd2pulumi. ***
// *** Do not edit by hand unless you're certain you know what you are doing! ***

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading.Tasks;
using Pulumi.Serialization;

namespace Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1
{

    public class TidbClusterSpecDiscoveryAdditionalVolumesEphemeralVolumeClaimTemplateArgs : global::Pulumi.ResourceArgs
    {
        [Input("metadata")]
        private InputMap<object>? _metadata;
        public InputMap<object> Metadata
        {
            get => _metadata ?? (_metadata = new InputMap<object>());
            set => _metadata = value;
        }

        [Input("spec", required: true)]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterSpecDiscoveryAdditionalVolumesEphemeralVolumeClaimTemplateSpecArgs> Spec { get; set; } = null!;

        public TidbClusterSpecDiscoveryAdditionalVolumesEphemeralVolumeClaimTemplateArgs()
        {
        }
        public static new TidbClusterSpecDiscoveryAdditionalVolumesEphemeralVolumeClaimTemplateArgs Empty => new TidbClusterSpecDiscoveryAdditionalVolumesEphemeralVolumeClaimTemplateArgs();
    }
}
