// *** WARNING: this file was generated by crd2pulumi. ***
// *** Do not edit by hand unless you're certain you know what you are doing! ***

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading.Tasks;
using Pulumi.Serialization;

namespace Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1
{

    public class RestoreSpecLocalVolumeArgs : global::Pulumi.ResourceArgs
    {
        [Input("awsElasticBlockStore")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.RestoreSpecLocalVolumeAwsElasticBlockStoreArgs>? AwsElasticBlockStore { get; set; }

        [Input("azureDisk")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.RestoreSpecLocalVolumeAzureDiskArgs>? AzureDisk { get; set; }

        [Input("azureFile")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.RestoreSpecLocalVolumeAzureFileArgs>? AzureFile { get; set; }

        [Input("cephfs")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.RestoreSpecLocalVolumeCephfsArgs>? Cephfs { get; set; }

        [Input("cinder")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.RestoreSpecLocalVolumeCinderArgs>? Cinder { get; set; }

        [Input("configMap")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.RestoreSpecLocalVolumeConfigMapArgs>? ConfigMap { get; set; }

        [Input("csi")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.RestoreSpecLocalVolumeCsiArgs>? Csi { get; set; }

        [Input("downwardAPI")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.RestoreSpecLocalVolumeDownwardApiArgs>? DownwardAPI { get; set; }

        [Input("emptyDir")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.RestoreSpecLocalVolumeEmptyDirArgs>? EmptyDir { get; set; }

        [Input("ephemeral")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.RestoreSpecLocalVolumeEphemeralArgs>? Ephemeral { get; set; }

        [Input("fc")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.RestoreSpecLocalVolumeFcArgs>? Fc { get; set; }

        [Input("flexVolume")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.RestoreSpecLocalVolumeFlexVolumeArgs>? FlexVolume { get; set; }

        [Input("flocker")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.RestoreSpecLocalVolumeFlockerArgs>? Flocker { get; set; }

        [Input("gcePersistentDisk")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.RestoreSpecLocalVolumeGcePersistentDiskArgs>? GcePersistentDisk { get; set; }

        [Input("gitRepo")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.RestoreSpecLocalVolumeGitRepoArgs>? GitRepo { get; set; }

        [Input("glusterfs")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.RestoreSpecLocalVolumeGlusterfsArgs>? Glusterfs { get; set; }

        [Input("hostPath")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.RestoreSpecLocalVolumeHostPathArgs>? HostPath { get; set; }

        [Input("iscsi")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.RestoreSpecLocalVolumeIscsiArgs>? Iscsi { get; set; }

        [Input("name", required: true)]
        public Input<string> Name { get; set; } = null!;

        [Input("nfs")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.RestoreSpecLocalVolumeNfsArgs>? Nfs { get; set; }

        [Input("persistentVolumeClaim")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.RestoreSpecLocalVolumePersistentVolumeClaimArgs>? PersistentVolumeClaim { get; set; }

        [Input("photonPersistentDisk")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.RestoreSpecLocalVolumePhotonPersistentDiskArgs>? PhotonPersistentDisk { get; set; }

        [Input("portworxVolume")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.RestoreSpecLocalVolumePortworxVolumeArgs>? PortworxVolume { get; set; }

        [Input("projected")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.RestoreSpecLocalVolumeProjectedArgs>? Projected { get; set; }

        [Input("quobyte")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.RestoreSpecLocalVolumeQuobyteArgs>? Quobyte { get; set; }

        [Input("rbd")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.RestoreSpecLocalVolumeRbdArgs>? Rbd { get; set; }

        [Input("scaleIO")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.RestoreSpecLocalVolumeScaleIoArgs>? ScaleIO { get; set; }

        [Input("secret")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.RestoreSpecLocalVolumeSecretArgs>? Secret { get; set; }

        [Input("storageos")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.RestoreSpecLocalVolumeStorageosArgs>? Storageos { get; set; }

        [Input("vsphereVolume")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.RestoreSpecLocalVolumeVsphereVolumeArgs>? VsphereVolume { get; set; }

        public RestoreSpecLocalVolumeArgs()
        {
        }
        public static new RestoreSpecLocalVolumeArgs Empty => new RestoreSpecLocalVolumeArgs();
    }
}
