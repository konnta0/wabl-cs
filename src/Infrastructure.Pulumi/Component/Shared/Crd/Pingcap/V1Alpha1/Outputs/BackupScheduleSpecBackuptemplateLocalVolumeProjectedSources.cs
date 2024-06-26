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
    public sealed class BackupScheduleSpecBackupTemplateLocalVolumeProjectedSources
    {
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.BackupScheduleSpecBackupTemplateLocalVolumeProjectedSourcesConfigMap ConfigMap;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.BackupScheduleSpecBackupTemplateLocalVolumeProjectedSourcesDownwardApi DownwardAPI;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.BackupScheduleSpecBackupTemplateLocalVolumeProjectedSourcesSecret Secret;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.BackupScheduleSpecBackupTemplateLocalVolumeProjectedSourcesServiceAccountToken ServiceAccountToken;

        [OutputConstructor]
        private BackupScheduleSpecBackupTemplateLocalVolumeProjectedSources(
            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.BackupScheduleSpecBackupTemplateLocalVolumeProjectedSourcesConfigMap configMap,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.BackupScheduleSpecBackupTemplateLocalVolumeProjectedSourcesDownwardApi downwardAPI,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.BackupScheduleSpecBackupTemplateLocalVolumeProjectedSourcesSecret secret,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.BackupScheduleSpecBackupTemplateLocalVolumeProjectedSourcesServiceAccountToken serviceAccountToken)
        {
            ConfigMap = configMap;
            DownwardAPI = downwardAPI;
            Secret = secret;
            ServiceAccountToken = serviceAccountToken;
        }
    }
}
