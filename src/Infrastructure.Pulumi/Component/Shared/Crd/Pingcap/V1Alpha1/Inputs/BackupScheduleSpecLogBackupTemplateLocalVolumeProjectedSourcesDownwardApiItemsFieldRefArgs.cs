// *** WARNING: this file was generated by crd2pulumi. ***
// *** Do not edit by hand unless you're certain you know what you are doing! ***

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading.Tasks;
using Pulumi.Serialization;

namespace Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1
{

    public class BackupScheduleSpecLogBackupTemplateLocalVolumeProjectedSourcesDownwardApiItemsFieldRefArgs : global::Pulumi.ResourceArgs
    {
        [Input("apiVersion")]
        public Input<string>? ApiVersion { get; set; }

        [Input("fieldPath", required: true)]
        public Input<string> FieldPath { get; set; } = null!;

        public BackupScheduleSpecLogBackupTemplateLocalVolumeProjectedSourcesDownwardApiItemsFieldRefArgs()
        {
        }
        public static new BackupScheduleSpecLogBackupTemplateLocalVolumeProjectedSourcesDownwardApiItemsFieldRefArgs Empty => new BackupScheduleSpecLogBackupTemplateLocalVolumeProjectedSourcesDownwardApiItemsFieldRefArgs();
    }
}
