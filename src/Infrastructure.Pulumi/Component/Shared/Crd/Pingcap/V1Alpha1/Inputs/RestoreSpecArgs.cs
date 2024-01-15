// *** WARNING: this file was generated by crd2pulumi. ***
// *** Do not edit by hand unless you're certain you know what you are doing! ***

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading.Tasks;
using Pulumi.Serialization;

namespace Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1
{

    public class RestoreSpecArgs : global::Pulumi.ResourceArgs
    {
        [Input("affinity")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.RestoreSpecAffinityArgs>? Affinity { get; set; }

        [Input("azblob")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.RestoreSpecAzblobArgs>? Azblob { get; set; }

        [Input("backupType")]
        public Input<string>? BackupType { get; set; }

        [Input("br")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.RestoreSpecBrArgs>? Br { get; set; }

        [Input("env")]
        private InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.RestoreSpecEnvArgs>? _env;
        public InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.RestoreSpecEnvArgs> Env
        {
            get => _env ?? (_env = new InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.RestoreSpecEnvArgs>());
            set => _env = value;
        }

        [Input("federalVolumeRestorePhase")]
        public Input<string>? FederalVolumeRestorePhase { get; set; }

        [Input("gcs")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.RestoreSpecGcsArgs>? Gcs { get; set; }

        [Input("imagePullSecrets")]
        private InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.RestoreSpecImagePullSecretsArgs>? _imagePullSecrets;
        public InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.RestoreSpecImagePullSecretsArgs> ImagePullSecrets
        {
            get => _imagePullSecrets ?? (_imagePullSecrets = new InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.RestoreSpecImagePullSecretsArgs>());
            set => _imagePullSecrets = value;
        }

        [Input("local")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.RestoreSpecLocalArgs>? Local { get; set; }

        [Input("logRestoreStartTs")]
        public Input<string>? LogRestoreStartTs { get; set; }

        [Input("pitrFullBackupStorageProvider")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.RestoreSpecPitrFullBackupStorageProviderArgs>? PitrFullBackupStorageProvider { get; set; }

        [Input("pitrRestoredTs")]
        public Input<string>? PitrRestoredTs { get; set; }

        [Input("podSecurityContext")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.RestoreSpecPodSecurityContextArgs>? PodSecurityContext { get; set; }

        [Input("priorityClassName")]
        public Input<string>? PriorityClassName { get; set; }

        [Input("resources")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.RestoreSpecResourcesArgs>? Resources { get; set; }

        [Input("restoreMode")]
        public Input<string>? RestoreMode { get; set; }

        [Input("s3")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.RestoreSpecS3Args>? S3 { get; set; }

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

        [Input("to")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.RestoreSpecToArgs>? To { get; set; }

        [Input("tolerations")]
        private InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.RestoreSpecTolerationsArgs>? _tolerations;
        public InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.RestoreSpecTolerationsArgs> Tolerations
        {
            get => _tolerations ?? (_tolerations = new InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.RestoreSpecTolerationsArgs>());
            set => _tolerations = value;
        }

        [Input("toolImage")]
        public Input<string>? ToolImage { get; set; }

        [Input("useKMS")]
        public Input<bool>? UseKMS { get; set; }

        [Input("volumeAZ")]
        public Input<string>? VolumeAZ { get; set; }

        [Input("warmup")]
        public Input<string>? Warmup { get; set; }

        [Input("warmupImage")]
        public Input<string>? WarmupImage { get; set; }

        [Input("warmupStrategy")]
        public Input<string>? WarmupStrategy { get; set; }

        public RestoreSpecArgs()
        {
            RestoreMode = "snapshot";
            WarmupStrategy = "hybrid";
        }
        public static new RestoreSpecArgs Empty => new RestoreSpecArgs();
    }
}
