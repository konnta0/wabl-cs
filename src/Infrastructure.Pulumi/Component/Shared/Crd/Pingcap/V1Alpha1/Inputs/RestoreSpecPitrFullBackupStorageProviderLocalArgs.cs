// *** WARNING: this file was generated by crd2pulumi. ***
// *** Do not edit by hand unless you're certain you know what you are doing! ***

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading.Tasks;
using Pulumi.Serialization;

namespace Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1
{

    public class RestoreSpecPitrFullBackupStorageProviderLocalArgs : global::Pulumi.ResourceArgs
    {
        [Input("prefix")]
        public Input<string>? Prefix { get; set; }

        [Input("volume", required: true)]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.RestoreSpecPitrFullBackupStorageProviderLocalVolumeArgs> Volume { get; set; } = null!;

        [Input("volumeMount", required: true)]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.RestoreSpecPitrFullBackupStorageProviderLocalVolumeMountArgs> VolumeMount { get; set; } = null!;

        public RestoreSpecPitrFullBackupStorageProviderLocalArgs()
        {
        }
        public static new RestoreSpecPitrFullBackupStorageProviderLocalArgs Empty => new RestoreSpecPitrFullBackupStorageProviderLocalArgs();
    }
}