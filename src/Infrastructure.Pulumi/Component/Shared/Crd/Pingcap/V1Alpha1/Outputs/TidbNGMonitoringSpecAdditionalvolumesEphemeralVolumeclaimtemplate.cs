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
    public sealed class TidbNGMonitoringSpecAdditionalVolumesEphemeralVolumeClaimTemplate
    {
        public readonly ImmutableDictionary<string, object> Metadata;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbNGMonitoringSpecAdditionalVolumesEphemeralVolumeClaimTemplateSpec Spec;

        [OutputConstructor]
        private TidbNGMonitoringSpecAdditionalVolumesEphemeralVolumeClaimTemplate(
            ImmutableDictionary<string, object> metadata,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbNGMonitoringSpecAdditionalVolumesEphemeralVolumeClaimTemplateSpec spec)
        {
            Metadata = metadata;
            Spec = spec;
        }
    }
}
