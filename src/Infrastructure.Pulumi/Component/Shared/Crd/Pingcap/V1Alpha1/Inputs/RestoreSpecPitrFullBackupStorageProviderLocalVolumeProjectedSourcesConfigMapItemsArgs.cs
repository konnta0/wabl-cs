// *** WARNING: this file was generated by crd2pulumi. ***
// *** Do not edit by hand unless you're certain you know what you are doing! ***

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading.Tasks;
using Pulumi.Serialization;

namespace Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1
{

    public class RestoreSpecPitrFullBackupStorageProviderLocalVolumeProjectedSourcesConfigMapItemsArgs : global::Pulumi.ResourceArgs
    {
        [Input("key", required: true)]
        public Input<string> Key { get; set; } = null!;

        [Input("mode")]
        public Input<int>? Mode { get; set; }

        [Input("path", required: true)]
        public Input<string> Path { get; set; } = null!;

        public RestoreSpecPitrFullBackupStorageProviderLocalVolumeProjectedSourcesConfigMapItemsArgs()
        {
        }
        public static new RestoreSpecPitrFullBackupStorageProviderLocalVolumeProjectedSourcesConfigMapItemsArgs Empty => new RestoreSpecPitrFullBackupStorageProviderLocalVolumeProjectedSourcesConfigMapItemsArgs();
    }
}