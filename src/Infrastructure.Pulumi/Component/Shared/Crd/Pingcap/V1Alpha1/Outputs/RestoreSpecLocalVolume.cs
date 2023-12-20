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
    public sealed class RestoreSpecLocalVolume
    {
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.RestoreSpecLocalVolumeAwselasticblockstore AwsElasticBlockStore;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.RestoreSpecLocalVolumeAzuredisk AzureDisk;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.RestoreSpecLocalVolumeAzurefile AzureFile;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.RestoreSpecLocalVolumeCephfs Cephfs;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.RestoreSpecLocalVolumeCinder Cinder;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.RestoreSpecLocalVolumeConfigmap ConfigMap;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.RestoreSpecLocalVolumeCsi Csi;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.RestoreSpecLocalVolumeDownwardapi DownwardAPI;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.RestoreSpecLocalVolumeEmptydir EmptyDir;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.RestoreSpecLocalVolumeEphemeral Ephemeral;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.RestoreSpecLocalVolumeFc Fc;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.RestoreSpecLocalVolumeFlexvolume FlexVolume;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.RestoreSpecLocalVolumeFlocker Flocker;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.RestoreSpecLocalVolumeGcepersistentdisk GcePersistentDisk;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.RestoreSpecLocalVolumeGitrepo GitRepo;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.RestoreSpecLocalVolumeGlusterfs Glusterfs;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.RestoreSpecLocalVolumeHostpath HostPath;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.RestoreSpecLocalVolumeIscsi Iscsi;
        public readonly string Name;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.RestoreSpecLocalVolumeNfs Nfs;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.RestoreSpecLocalVolumePersistentvolumeclaim PersistentVolumeClaim;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.RestoreSpecLocalVolumePhotonpersistentdisk PhotonPersistentDisk;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.RestoreSpecLocalVolumePortworxvolume PortworxVolume;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.RestoreSpecLocalVolumeProjected Projected;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.RestoreSpecLocalVolumeQuobyte Quobyte;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.RestoreSpecLocalVolumeRbd Rbd;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.RestoreSpecLocalVolumeScaleio ScaleIO;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.RestoreSpecLocalVolumeSecret Secret;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.RestoreSpecLocalVolumeStorageos Storageos;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.RestoreSpecLocalVolumeVspherevolume VsphereVolume;

        [OutputConstructor]
        private RestoreSpecLocalVolume(
            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.RestoreSpecLocalVolumeAwselasticblockstore awsElasticBlockStore,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.RestoreSpecLocalVolumeAzuredisk azureDisk,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.RestoreSpecLocalVolumeAzurefile azureFile,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.RestoreSpecLocalVolumeCephfs cephfs,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.RestoreSpecLocalVolumeCinder cinder,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.RestoreSpecLocalVolumeConfigmap configMap,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.RestoreSpecLocalVolumeCsi csi,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.RestoreSpecLocalVolumeDownwardapi downwardAPI,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.RestoreSpecLocalVolumeEmptydir emptyDir,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.RestoreSpecLocalVolumeEphemeral ephemeral,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.RestoreSpecLocalVolumeFc fc,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.RestoreSpecLocalVolumeFlexvolume flexVolume,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.RestoreSpecLocalVolumeFlocker flocker,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.RestoreSpecLocalVolumeGcepersistentdisk gcePersistentDisk,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.RestoreSpecLocalVolumeGitrepo gitRepo,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.RestoreSpecLocalVolumeGlusterfs glusterfs,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.RestoreSpecLocalVolumeHostpath hostPath,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.RestoreSpecLocalVolumeIscsi iscsi,

            string name,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.RestoreSpecLocalVolumeNfs nfs,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.RestoreSpecLocalVolumePersistentvolumeclaim persistentVolumeClaim,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.RestoreSpecLocalVolumePhotonpersistentdisk photonPersistentDisk,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.RestoreSpecLocalVolumePortworxvolume portworxVolume,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.RestoreSpecLocalVolumeProjected projected,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.RestoreSpecLocalVolumeQuobyte quobyte,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.RestoreSpecLocalVolumeRbd rbd,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.RestoreSpecLocalVolumeScaleio scaleIO,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.RestoreSpecLocalVolumeSecret secret,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.RestoreSpecLocalVolumeStorageos storageos,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.RestoreSpecLocalVolumeVspherevolume vsphereVolume)
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