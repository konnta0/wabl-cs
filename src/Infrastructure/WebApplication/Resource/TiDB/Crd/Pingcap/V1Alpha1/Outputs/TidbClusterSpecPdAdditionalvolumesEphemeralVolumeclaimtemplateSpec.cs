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
    public sealed class TidbClusterSpecPdAdditionalvolumesEphemeralVolumeclaimtemplateSpec
    {
        public readonly ImmutableArray<string> AccessModes;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecPdAdditionalvolumesEphemeralVolumeclaimtemplateSpecDatasource DataSource;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecPdAdditionalvolumesEphemeralVolumeclaimtemplateSpecResources Resources;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecPdAdditionalvolumesEphemeralVolumeclaimtemplateSpecSelector Selector;
        public readonly string StorageClassName;
        public readonly string VolumeMode;
        public readonly string VolumeName;

        [OutputConstructor]
        private TidbClusterSpecPdAdditionalvolumesEphemeralVolumeclaimtemplateSpec(
            ImmutableArray<string> accessModes,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecPdAdditionalvolumesEphemeralVolumeclaimtemplateSpecDatasource dataSource,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecPdAdditionalvolumesEphemeralVolumeclaimtemplateSpecResources resources,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecPdAdditionalvolumesEphemeralVolumeclaimtemplateSpecSelector selector,

            string storageClassName,

            string volumeMode,

            string volumeName)
        {
            AccessModes = accessModes;
            DataSource = dataSource;
            Resources = resources;
            Selector = selector;
            StorageClassName = storageClassName;
            VolumeMode = volumeMode;
            VolumeName = volumeName;
        }
    }
}
