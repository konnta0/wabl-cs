// *** WARNING: this file was generated by crd2pulumi. ***
// *** Do not edit by hand unless you're certain you know what you are doing! ***

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading.Tasks;
using Pulumi.Serialization;

namespace Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1
{

    public class BackupScheduleSpecBackuptemplateLocalVolumeEphemeralVolumeclaimtemplateArgs : Pulumi.ResourceArgs
    {
        [Input("metadata")]
        private InputMap<object>? _metadata;
        public InputMap<object> Metadata
        {
            get => _metadata ?? (_metadata = new InputMap<object>());
            set => _metadata = value;
        }

        [Input("spec", required: true)]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.BackupScheduleSpecBackuptemplateLocalVolumeEphemeralVolumeclaimtemplateSpecArgs> Spec { get; set; } = null!;

        public BackupScheduleSpecBackuptemplateLocalVolumeEphemeralVolumeclaimtemplateArgs()
        {
        }
    }
}
