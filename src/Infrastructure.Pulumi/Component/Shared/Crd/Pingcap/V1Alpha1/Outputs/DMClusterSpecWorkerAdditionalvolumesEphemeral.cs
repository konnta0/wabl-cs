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
    public sealed class DMClusterSpecWorkerAdditionalVolumesEphemeral
    {
        public readonly bool ReadOnly;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.DMClusterSpecWorkerAdditionalVolumesEphemeralVolumeClaimTemplate VolumeClaimTemplate;

        [OutputConstructor]
        private DMClusterSpecWorkerAdditionalVolumesEphemeral(
            bool readOnly,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.DMClusterSpecWorkerAdditionalVolumesEphemeralVolumeClaimTemplate volumeClaimTemplate)
        {
            ReadOnly = readOnly;
            VolumeClaimTemplate = volumeClaimTemplate;
        }
    }
}
