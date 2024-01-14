// *** WARNING: this file was generated by crd2pulumi. ***
// *** Do not edit by hand unless you're certain you know what you are doing! ***

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading.Tasks;
using Pulumi.Serialization;

namespace Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1
{

    public class RestoreSpecPitrFullBackupStorageProviderLocalVolumeEphemeralVolumeClaimTemplateSpecArgs : global::Pulumi.ResourceArgs
    {
        [Input("accessModes")]
        private InputList<string>? _accessModes;
        public InputList<string> AccessModes
        {
            get => _accessModes ?? (_accessModes = new InputList<string>());
            set => _accessModes = value;
        }

        [Input("dataSource")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.RestoreSpecPitrFullBackupStorageProviderLocalVolumeEphemeralVolumeClaimTemplateSpecDataSourceArgs>? DataSource { get; set; }

        [Input("resources")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.RestoreSpecPitrFullBackupStorageProviderLocalVolumeEphemeralVolumeClaimTemplateSpecResourcesArgs>? Resources { get; set; }

        [Input("selector")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.RestoreSpecPitrFullBackupStorageProviderLocalVolumeEphemeralVolumeClaimTemplateSpecSelectorArgs>? Selector { get; set; }

        [Input("storageClassName")]
        public Input<string>? StorageClassName { get; set; }

        [Input("volumeMode")]
        public Input<string>? VolumeMode { get; set; }

        [Input("volumeName")]
        public Input<string>? VolumeName { get; set; }

        public RestoreSpecPitrFullBackupStorageProviderLocalVolumeEphemeralVolumeClaimTemplateSpecArgs()
        {
        }
        public static new RestoreSpecPitrFullBackupStorageProviderLocalVolumeEphemeralVolumeClaimTemplateSpecArgs Empty => new RestoreSpecPitrFullBackupStorageProviderLocalVolumeEphemeralVolumeClaimTemplateSpecArgs();
    }
}
