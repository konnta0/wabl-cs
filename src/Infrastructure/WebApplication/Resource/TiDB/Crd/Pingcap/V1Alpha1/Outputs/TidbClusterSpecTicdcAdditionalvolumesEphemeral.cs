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
    public sealed class TidbClusterSpecTicdcAdditionalvolumesEphemeral
    {
        public readonly bool ReadOnly;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecTicdcAdditionalvolumesEphemeralVolumeclaimtemplate VolumeClaimTemplate;

        [OutputConstructor]
        private TidbClusterSpecTicdcAdditionalvolumesEphemeral(
            bool readOnly,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecTicdcAdditionalvolumesEphemeralVolumeclaimtemplate volumeClaimTemplate)
        {
            ReadOnly = readOnly;
            VolumeClaimTemplate = volumeClaimTemplate;
        }
    }
}
