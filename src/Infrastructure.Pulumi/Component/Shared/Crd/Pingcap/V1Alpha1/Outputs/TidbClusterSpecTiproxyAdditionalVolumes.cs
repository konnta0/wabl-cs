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
    public sealed class TidbClusterSpecTiproxyAdditionalVolumes
    {
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecTiproxyAdditionalVolumesAwsElasticBlockStore AwsElasticBlockStore;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecTiproxyAdditionalVolumesAzureDisk AzureDisk;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecTiproxyAdditionalVolumesAzureFile AzureFile;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecTiproxyAdditionalVolumesCephfs Cephfs;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecTiproxyAdditionalVolumesCinder Cinder;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecTiproxyAdditionalVolumesConfigMap ConfigMap;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecTiproxyAdditionalVolumesCsi Csi;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecTiproxyAdditionalVolumesDownwardApi DownwardAPI;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecTiproxyAdditionalVolumesEmptyDir EmptyDir;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecTiproxyAdditionalVolumesEphemeral Ephemeral;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecTiproxyAdditionalVolumesFc Fc;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecTiproxyAdditionalVolumesFlexVolume FlexVolume;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecTiproxyAdditionalVolumesFlocker Flocker;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecTiproxyAdditionalVolumesGcePersistentDisk GcePersistentDisk;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecTiproxyAdditionalVolumesGitRepo GitRepo;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecTiproxyAdditionalVolumesGlusterfs Glusterfs;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecTiproxyAdditionalVolumesHostPath HostPath;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecTiproxyAdditionalVolumesIscsi Iscsi;
        public readonly string Name;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecTiproxyAdditionalVolumesNfs Nfs;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecTiproxyAdditionalVolumesPersistentVolumeClaim PersistentVolumeClaim;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecTiproxyAdditionalVolumesPhotonPersistentDisk PhotonPersistentDisk;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecTiproxyAdditionalVolumesPortworxVolume PortworxVolume;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecTiproxyAdditionalVolumesProjected Projected;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecTiproxyAdditionalVolumesQuobyte Quobyte;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecTiproxyAdditionalVolumesRbd Rbd;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecTiproxyAdditionalVolumesScaleIo ScaleIO;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecTiproxyAdditionalVolumesSecret Secret;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecTiproxyAdditionalVolumesStorageos Storageos;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecTiproxyAdditionalVolumesVsphereVolume VsphereVolume;

        [OutputConstructor]
        private TidbClusterSpecTiproxyAdditionalVolumes(
            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecTiproxyAdditionalVolumesAwsElasticBlockStore awsElasticBlockStore,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecTiproxyAdditionalVolumesAzureDisk azureDisk,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecTiproxyAdditionalVolumesAzureFile azureFile,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecTiproxyAdditionalVolumesCephfs cephfs,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecTiproxyAdditionalVolumesCinder cinder,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecTiproxyAdditionalVolumesConfigMap configMap,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecTiproxyAdditionalVolumesCsi csi,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecTiproxyAdditionalVolumesDownwardApi downwardAPI,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecTiproxyAdditionalVolumesEmptyDir emptyDir,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecTiproxyAdditionalVolumesEphemeral ephemeral,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecTiproxyAdditionalVolumesFc fc,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecTiproxyAdditionalVolumesFlexVolume flexVolume,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecTiproxyAdditionalVolumesFlocker flocker,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecTiproxyAdditionalVolumesGcePersistentDisk gcePersistentDisk,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecTiproxyAdditionalVolumesGitRepo gitRepo,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecTiproxyAdditionalVolumesGlusterfs glusterfs,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecTiproxyAdditionalVolumesHostPath hostPath,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecTiproxyAdditionalVolumesIscsi iscsi,

            string name,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecTiproxyAdditionalVolumesNfs nfs,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecTiproxyAdditionalVolumesPersistentVolumeClaim persistentVolumeClaim,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecTiproxyAdditionalVolumesPhotonPersistentDisk photonPersistentDisk,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecTiproxyAdditionalVolumesPortworxVolume portworxVolume,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecTiproxyAdditionalVolumesProjected projected,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecTiproxyAdditionalVolumesQuobyte quobyte,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecTiproxyAdditionalVolumesRbd rbd,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecTiproxyAdditionalVolumesScaleIo scaleIO,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecTiproxyAdditionalVolumesSecret secret,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecTiproxyAdditionalVolumesStorageos storageos,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecTiproxyAdditionalVolumesVsphereVolume vsphereVolume)
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
