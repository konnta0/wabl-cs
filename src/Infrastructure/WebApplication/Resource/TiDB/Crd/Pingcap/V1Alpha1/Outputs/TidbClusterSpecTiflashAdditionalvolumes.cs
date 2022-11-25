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
    public sealed class TidbClusterSpecTiflashAdditionalvolumes
    {
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecTiflashAdditionalvolumesAwselasticblockstore AwsElasticBlockStore;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecTiflashAdditionalvolumesAzuredisk AzureDisk;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecTiflashAdditionalvolumesAzurefile AzureFile;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecTiflashAdditionalvolumesCephfs Cephfs;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecTiflashAdditionalvolumesCinder Cinder;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecTiflashAdditionalvolumesConfigmap ConfigMap;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecTiflashAdditionalvolumesCsi Csi;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecTiflashAdditionalvolumesDownwardapi DownwardAPI;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecTiflashAdditionalvolumesEmptydir EmptyDir;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecTiflashAdditionalvolumesEphemeral Ephemeral;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecTiflashAdditionalvolumesFc Fc;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecTiflashAdditionalvolumesFlexvolume FlexVolume;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecTiflashAdditionalvolumesFlocker Flocker;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecTiflashAdditionalvolumesGcepersistentdisk GcePersistentDisk;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecTiflashAdditionalvolumesGitrepo GitRepo;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecTiflashAdditionalvolumesGlusterfs Glusterfs;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecTiflashAdditionalvolumesHostpath HostPath;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecTiflashAdditionalvolumesIscsi Iscsi;
        public readonly string Name;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecTiflashAdditionalvolumesNfs Nfs;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecTiflashAdditionalvolumesPersistentvolumeclaim PersistentVolumeClaim;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecTiflashAdditionalvolumesPhotonpersistentdisk PhotonPersistentDisk;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecTiflashAdditionalvolumesPortworxvolume PortworxVolume;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecTiflashAdditionalvolumesProjected Projected;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecTiflashAdditionalvolumesQuobyte Quobyte;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecTiflashAdditionalvolumesRbd Rbd;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecTiflashAdditionalvolumesScaleio ScaleIO;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecTiflashAdditionalvolumesSecret Secret;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecTiflashAdditionalvolumesStorageos Storageos;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecTiflashAdditionalvolumesVspherevolume VsphereVolume;

        [OutputConstructor]
        private TidbClusterSpecTiflashAdditionalvolumes(
            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecTiflashAdditionalvolumesAwselasticblockstore awsElasticBlockStore,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecTiflashAdditionalvolumesAzuredisk azureDisk,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecTiflashAdditionalvolumesAzurefile azureFile,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecTiflashAdditionalvolumesCephfs cephfs,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecTiflashAdditionalvolumesCinder cinder,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecTiflashAdditionalvolumesConfigmap configMap,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecTiflashAdditionalvolumesCsi csi,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecTiflashAdditionalvolumesDownwardapi downwardAPI,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecTiflashAdditionalvolumesEmptydir emptyDir,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecTiflashAdditionalvolumesEphemeral ephemeral,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecTiflashAdditionalvolumesFc fc,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecTiflashAdditionalvolumesFlexvolume flexVolume,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecTiflashAdditionalvolumesFlocker flocker,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecTiflashAdditionalvolumesGcepersistentdisk gcePersistentDisk,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecTiflashAdditionalvolumesGitrepo gitRepo,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecTiflashAdditionalvolumesGlusterfs glusterfs,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecTiflashAdditionalvolumesHostpath hostPath,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecTiflashAdditionalvolumesIscsi iscsi,

            string name,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecTiflashAdditionalvolumesNfs nfs,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecTiflashAdditionalvolumesPersistentvolumeclaim persistentVolumeClaim,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecTiflashAdditionalvolumesPhotonpersistentdisk photonPersistentDisk,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecTiflashAdditionalvolumesPortworxvolume portworxVolume,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecTiflashAdditionalvolumesProjected projected,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecTiflashAdditionalvolumesQuobyte quobyte,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecTiflashAdditionalvolumesRbd rbd,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecTiflashAdditionalvolumesScaleio scaleIO,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecTiflashAdditionalvolumesSecret secret,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecTiflashAdditionalvolumesStorageos storageos,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecTiflashAdditionalvolumesVspherevolume vsphereVolume)
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
