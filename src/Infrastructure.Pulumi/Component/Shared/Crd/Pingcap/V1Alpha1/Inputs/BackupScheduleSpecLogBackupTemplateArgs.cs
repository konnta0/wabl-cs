// *** WARNING: this file was generated by crd2pulumi. ***
// *** Do not edit by hand unless you're certain you know what you are doing! ***

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading.Tasks;
using Pulumi.Serialization;

namespace Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1
{

    public class BackupScheduleSpecLogBackupTemplateArgs : global::Pulumi.ResourceArgs
    {
        [Input("affinity")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.BackupScheduleSpecLogBackupTemplateAffinityArgs>? Affinity { get; set; }

        [Input("azblob")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.BackupScheduleSpecLogBackupTemplateAzblobArgs>? Azblob { get; set; }

        [Input("backoffRetryPolicy")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.BackupScheduleSpecLogBackupTemplateBackoffRetryPolicyArgs>? BackoffRetryPolicy { get; set; }

        [Input("backupMode")]
        public Input<string>? BackupMode { get; set; }

        [Input("backupType")]
        public Input<string>? BackupType { get; set; }

        [Input("br")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.BackupScheduleSpecLogBackupTemplateBrArgs>? Br { get; set; }

        [Input("cleanOption")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.BackupScheduleSpecLogBackupTemplateCleanOptionArgs>? CleanOption { get; set; }

        [Input("cleanPolicy")]
        public Input<string>? CleanPolicy { get; set; }

        [Input("commitTs")]
        public Input<string>? CommitTs { get; set; }

        [Input("dumpling")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.BackupScheduleSpecLogBackupTemplateDumplingArgs>? Dumpling { get; set; }

        [Input("env")]
        private InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.BackupScheduleSpecLogBackupTemplateEnvArgs>? _env;
        public InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.BackupScheduleSpecLogBackupTemplateEnvArgs> Env
        {
            get => _env ?? (_env = new InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.BackupScheduleSpecLogBackupTemplateEnvArgs>());
            set => _env = value;
        }

        [Input("from")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.BackupScheduleSpecLogBackupTemplateFromArgs>? From { get; set; }

        [Input("gcs")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.BackupScheduleSpecLogBackupTemplateGcsArgs>? Gcs { get; set; }

        [Input("imagePullSecrets")]
        private InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.BackupScheduleSpecLogBackupTemplateImagePullSecretsArgs>? _imagePullSecrets;
        public InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.BackupScheduleSpecLogBackupTemplateImagePullSecretsArgs> ImagePullSecrets
        {
            get => _imagePullSecrets ?? (_imagePullSecrets = new InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.BackupScheduleSpecLogBackupTemplateImagePullSecretsArgs>());
            set => _imagePullSecrets = value;
        }

        [Input("local")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.BackupScheduleSpecLogBackupTemplateLocalArgs>? Local { get; set; }

        [Input("logStop")]
        public Input<bool>? LogStop { get; set; }

        [Input("logTruncateUntil")]
        public Input<string>? LogTruncateUntil { get; set; }

        [Input("podSecurityContext")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.BackupScheduleSpecLogBackupTemplatePodSecurityContextArgs>? PodSecurityContext { get; set; }

        [Input("priorityClassName")]
        public Input<string>? PriorityClassName { get; set; }

        [Input("resources")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.BackupScheduleSpecLogBackupTemplateResourcesArgs>? Resources { get; set; }

        [Input("s3")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.BackupScheduleSpecLogBackupTemplateS3Args>? S3 { get; set; }

        [Input("serviceAccount")]
        public Input<string>? ServiceAccount { get; set; }

        [Input("storageClassName")]
        public Input<string>? StorageClassName { get; set; }

        [Input("storageSize")]
        public Input<string>? StorageSize { get; set; }

        [Input("tableFilter")]
        private InputList<string>? _tableFilter;
        public InputList<string> TableFilter
        {
            get => _tableFilter ?? (_tableFilter = new InputList<string>());
            set => _tableFilter = value;
        }

        [Input("tikvGCLifeTime")]
        public Input<string>? TikvGCLifeTime { get; set; }

        [Input("tolerations")]
        private InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.BackupScheduleSpecLogBackupTemplateTolerationsArgs>? _tolerations;
        public InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.BackupScheduleSpecLogBackupTemplateTolerationsArgs> Tolerations
        {
            get => _tolerations ?? (_tolerations = new InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.BackupScheduleSpecLogBackupTemplateTolerationsArgs>());
            set => _tolerations = value;
        }

        [Input("toolImage")]
        public Input<string>? ToolImage { get; set; }

        [Input("useKMS")]
        public Input<bool>? UseKMS { get; set; }

        public BackupScheduleSpecLogBackupTemplateArgs()
        {
            BackupMode = "snapshot";
        }
        public static new BackupScheduleSpecLogBackupTemplateArgs Empty => new BackupScheduleSpecLogBackupTemplateArgs();
    }
}
