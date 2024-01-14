// *** WARNING: this file was generated by crd2pulumi. ***
// *** Do not edit by hand unless you're certain you know what you are doing! ***

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading.Tasks;
using Pulumi.Serialization;

namespace Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1
{

    public class RestoreSpecPitrFullBackupStorageProviderLocalVolumeCsiArgs : global::Pulumi.ResourceArgs
    {
        [Input("driver", required: true)]
        public Input<string> Driver { get; set; } = null!;

        [Input("fsType")]
        public Input<string>? FsType { get; set; }

        [Input("nodePublishSecretRef")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.RestoreSpecPitrFullBackupStorageProviderLocalVolumeCsiNodePublishSecretRefArgs>? NodePublishSecretRef { get; set; }

        [Input("readOnly")]
        public Input<bool>? ReadOnly { get; set; }

        [Input("volumeAttributes")]
        private InputMap<string>? _volumeAttributes;
        public InputMap<string> VolumeAttributes
        {
            get => _volumeAttributes ?? (_volumeAttributes = new InputMap<string>());
            set => _volumeAttributes = value;
        }

        public RestoreSpecPitrFullBackupStorageProviderLocalVolumeCsiArgs()
        {
        }
        public static new RestoreSpecPitrFullBackupStorageProviderLocalVolumeCsiArgs Empty => new RestoreSpecPitrFullBackupStorageProviderLocalVolumeCsiArgs();
    }
}
