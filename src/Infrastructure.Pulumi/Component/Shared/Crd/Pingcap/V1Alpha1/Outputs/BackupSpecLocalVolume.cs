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
    public sealed class BackupSpecLocalVolume
    {
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.BackupSpecLocalVolumeAwsElasticBlockStore AwsElasticBlockStore;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.BackupSpecLocalVolumeAzureDisk AzureDisk;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.BackupSpecLocalVolumeAzureFile AzureFile;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.BackupSpecLocalVolumeCephfs Cephfs;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.BackupSpecLocalVolumeCinder Cinder;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.BackupSpecLocalVolumeConfigMap ConfigMap;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.BackupSpecLocalVolumeCsi Csi;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.BackupSpecLocalVolumeDownwardApi DownwardAPI;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.BackupSpecLocalVolumeEmptyDir EmptyDir;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.BackupSpecLocalVolumeEphemeral Ephemeral;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.BackupSpecLocalVolumeFc Fc;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.BackupSpecLocalVolumeFlexVolume FlexVolume;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.BackupSpecLocalVolumeFlocker Flocker;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.BackupSpecLocalVolumeGcePersistentDisk GcePersistentDisk;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.BackupSpecLocalVolumeGitRepo GitRepo;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.BackupSpecLocalVolumeGlusterfs Glusterfs;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.BackupSpecLocalVolumeHostPath HostPath;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.BackupSpecLocalVolumeIscsi Iscsi;
        public readonly string Name;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.BackupSpecLocalVolumeNfs Nfs;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.BackupSpecLocalVolumePersistentVolumeClaim PersistentVolumeClaim;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.BackupSpecLocalVolumePhotonPersistentDisk PhotonPersistentDisk;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.BackupSpecLocalVolumePortworxVolume PortworxVolume;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.BackupSpecLocalVolumeProjected Projected;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.BackupSpecLocalVolumeQuobyte Quobyte;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.BackupSpecLocalVolumeRbd Rbd;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.BackupSpecLocalVolumeScaleIo ScaleIO;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.BackupSpecLocalVolumeSecret Secret;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.BackupSpecLocalVolumeStorageos Storageos;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.BackupSpecLocalVolumeVsphereVolume VsphereVolume;

        [OutputConstructor]
        private BackupSpecLocalVolume(
            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.BackupSpecLocalVolumeAwsElasticBlockStore awsElasticBlockStore,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.BackupSpecLocalVolumeAzureDisk azureDisk,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.BackupSpecLocalVolumeAzureFile azureFile,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.BackupSpecLocalVolumeCephfs cephfs,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.BackupSpecLocalVolumeCinder cinder,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.BackupSpecLocalVolumeConfigMap configMap,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.BackupSpecLocalVolumeCsi csi,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.BackupSpecLocalVolumeDownwardApi downwardAPI,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.BackupSpecLocalVolumeEmptyDir emptyDir,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.BackupSpecLocalVolumeEphemeral ephemeral,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.BackupSpecLocalVolumeFc fc,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.BackupSpecLocalVolumeFlexVolume flexVolume,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.BackupSpecLocalVolumeFlocker flocker,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.BackupSpecLocalVolumeGcePersistentDisk gcePersistentDisk,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.BackupSpecLocalVolumeGitRepo gitRepo,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.BackupSpecLocalVolumeGlusterfs glusterfs,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.BackupSpecLocalVolumeHostPath hostPath,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.BackupSpecLocalVolumeIscsi iscsi,

            string name,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.BackupSpecLocalVolumeNfs nfs,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.BackupSpecLocalVolumePersistentVolumeClaim persistentVolumeClaim,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.BackupSpecLocalVolumePhotonPersistentDisk photonPersistentDisk,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.BackupSpecLocalVolumePortworxVolume portworxVolume,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.BackupSpecLocalVolumeProjected projected,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.BackupSpecLocalVolumeQuobyte quobyte,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.BackupSpecLocalVolumeRbd rbd,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.BackupSpecLocalVolumeScaleIo scaleIO,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.BackupSpecLocalVolumeSecret secret,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.BackupSpecLocalVolumeStorageos storageos,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.BackupSpecLocalVolumeVsphereVolume vsphereVolume)
        {
            AwsElasticBlockStore = awsElasticBlockStore;
            AzureDisk = azureDisk;
            AzureFile = azureFile;
            Cephfs = cephfs;
            Cinder = cinder;
            ConfigMap = configMap;
            Csi = csi;
            DownwardAPI = downwardAPI;
            EmptyDir = emptyDir;
            Ephemeral = ephemeral;
            Fc = fc;
            FlexVolume = flexVolume;
            Flocker = flocker;
            GcePersistentDisk = gcePersistentDisk;
            GitRepo = gitRepo;
            Glusterfs = glusterfs;
            HostPath = hostPath;
            Iscsi = iscsi;
            Name = name;
            Nfs = nfs;
            PersistentVolumeClaim = persistentVolumeClaim;
            PhotonPersistentDisk = photonPersistentDisk;
            PortworxVolume = portworxVolume;
            Projected = projected;
            Quobyte = quobyte;
            Rbd = rbd;
            ScaleIO = scaleIO;
            Secret = secret;
            Storageos = storageos;
            VsphereVolume = vsphereVolume;
        }
    }
}
