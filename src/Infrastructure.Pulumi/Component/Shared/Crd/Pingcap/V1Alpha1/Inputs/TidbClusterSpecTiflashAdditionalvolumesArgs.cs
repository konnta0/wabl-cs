// *** WARNING: this file was generated by crd2pulumi. ***
// *** Do not edit by hand unless you're certain you know what you are doing! ***

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading.Tasks;
using Pulumi.Serialization;

namespace Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1
{

    public class TidbClusterSpecTiflashAdditionalVolumesArgs : global::Pulumi.ResourceArgs
    {
        [Input("awsElasticBlockStore")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterSpecTiflashAdditionalVolumesAwsElasticBlockStoreArgs>? AwsElasticBlockStore { get; set; }

        [Input("azureDisk")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterSpecTiflashAdditionalVolumesAzureDiskArgs>? AzureDisk { get; set; }

        [Input("azureFile")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterSpecTiflashAdditionalVolumesAzureFileArgs>? AzureFile { get; set; }

        [Input("cephfs")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterSpecTiflashAdditionalVolumesCephfsArgs>? Cephfs { get; set; }

        [Input("cinder")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterSpecTiflashAdditionalVolumesCinderArgs>? Cinder { get; set; }

        [Input("configMap")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterSpecTiflashAdditionalVolumesConfigMapArgs>? ConfigMap { get; set; }

        [Input("csi")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterSpecTiflashAdditionalVolumesCsiArgs>? Csi { get; set; }

        [Input("downwardAPI")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterSpecTiflashAdditionalVolumesDownwardApiArgs>? DownwardAPI { get; set; }

        [Input("emptyDir")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterSpecTiflashAdditionalVolumesEmptyDirArgs>? EmptyDir { get; set; }

        [Input("ephemeral")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterSpecTiflashAdditionalVolumesEphemeralArgs>? Ephemeral { get; set; }

        [Input("fc")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterSpecTiflashAdditionalVolumesFcArgs>? Fc { get; set; }

        [Input("flexVolume")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterSpecTiflashAdditionalVolumesFlexVolumeArgs>? FlexVolume { get; set; }

        [Input("flocker")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterSpecTiflashAdditionalVolumesFlockerArgs>? Flocker { get; set; }

        [Input("gcePersistentDisk")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterSpecTiflashAdditionalVolumesGcePersistentDiskArgs>? GcePersistentDisk { get; set; }

        [Input("gitRepo")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterSpecTiflashAdditionalVolumesGitRepoArgs>? GitRepo { get; set; }

        [Input("glusterfs")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterSpecTiflashAdditionalVolumesGlusterfsArgs>? Glusterfs { get; set; }

        [Input("hostPath")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterSpecTiflashAdditionalVolumesHostPathArgs>? HostPath { get; set; }

        [Input("iscsi")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterSpecTiflashAdditionalVolumesIscsiArgs>? Iscsi { get; set; }

        [Input("name", required: true)]
        public Input<string> Name { get; set; } = null!;

        [Input("nfs")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterSpecTiflashAdditionalVolumesNfsArgs>? Nfs { get; set; }

        [Input("persistentVolumeClaim")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterSpecTiflashAdditionalVolumesPersistentVolumeClaimArgs>? PersistentVolumeClaim { get; set; }

        [Input("photonPersistentDisk")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterSpecTiflashAdditionalVolumesPhotonPersistentDiskArgs>? PhotonPersistentDisk { get; set; }

        [Input("portworxVolume")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterSpecTiflashAdditionalVolumesPortworxVolumeArgs>? PortworxVolume { get; set; }

        [Input("projected")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterSpecTiflashAdditionalVolumesProjectedArgs>? Projected { get; set; }

        [Input("quobyte")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterSpecTiflashAdditionalVolumesQuobyteArgs>? Quobyte { get; set; }

        [Input("rbd")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterSpecTiflashAdditionalVolumesRbdArgs>? Rbd { get; set; }

        [Input("scaleIO")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterSpecTiflashAdditionalVolumesScaleIoArgs>? ScaleIO { get; set; }

        [Input("secret")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterSpecTiflashAdditionalVolumesSecretArgs>? Secret { get; set; }

        [Input("storageos")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterSpecTiflashAdditionalVolumesStorageosArgs>? Storageos { get; set; }

        [Input("vsphereVolume")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterSpecTiflashAdditionalVolumesVsphereVolumeArgs>? VsphereVolume { get; set; }

        public TidbClusterSpecTiflashAdditionalVolumesArgs()
        {
        }
        public static new TidbClusterSpecTiflashAdditionalVolumesArgs Empty => new TidbClusterSpecTiflashAdditionalVolumesArgs();
    }
}
