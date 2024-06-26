// *** WARNING: this file was generated by crd2pulumi. ***
// *** Do not edit by hand unless you're certain you know what you are doing! ***

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading.Tasks;
using Pulumi.Serialization;

namespace Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1
{

    [OutputType]
    public sealed class BackupScheduleSpecLogBackupTemplateLocalVolumeProjectedSources
    {
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.BackupScheduleSpecLogBackupTemplateLocalVolumeProjectedSourcesConfigMap ConfigMap;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.BackupScheduleSpecLogBackupTemplateLocalVolumeProjectedSourcesDownwardApi DownwardAPI;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.BackupScheduleSpecLogBackupTemplateLocalVolumeProjectedSourcesSecret Secret;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.BackupScheduleSpecLogBackupTemplateLocalVolumeProjectedSourcesServiceAccountToken ServiceAccountToken;

        [OutputConstructor]
        private BackupScheduleSpecLogBackupTemplateLocalVolumeProjectedSources(
            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.BackupScheduleSpecLogBackupTemplateLocalVolumeProjectedSourcesConfigMap configMap,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.BackupScheduleSpecLogBackupTemplateLocalVolumeProjectedSourcesDownwardApi downwardAPI,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.BackupScheduleSpecLogBackupTemplateLocalVolumeProjectedSourcesSecret secret,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.BackupScheduleSpecLogBackupTemplateLocalVolumeProjectedSourcesServiceAccountToken serviceAccountToken)
        {
            ConfigMap = configMap;
            DownwardAPI = downwardAPI;
            Secret = secret;
            ServiceAccountToken = serviceAccountToken;
        }
    }
}
