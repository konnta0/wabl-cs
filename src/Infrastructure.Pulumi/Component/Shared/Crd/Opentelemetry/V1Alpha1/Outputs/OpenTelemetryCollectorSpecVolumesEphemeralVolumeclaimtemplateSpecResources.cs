// *** WARNING: this file was generated by crd2pulumi. ***
// *** Do not edit by hand unless you're certain you know what you are doing! ***

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading.Tasks;
using Pulumi.Serialization;

namespace Pulumi.Kubernetes.Types.Outputs.Opentelemetry.V1Alpha1
{

    /// <summary>
    /// resources represents the minimum resources the volume should have. If RecoverVolumeExpansionFailure feature is enabled users are allowed to specify resource requirements that are lower than previous value but must still be higher than capacity recorded in the status field of the claim. More info: https://kubernetes.io/docs/concepts/storage/persistent-volumes#resources
    /// </summary>
    [OutputType]
    public sealed class OpenTelemetryCollectorSpecVolumesEphemeralVolumeclaimtemplateSpecResources
    {
        /// <summary>
        /// Limits describes the maximum amount of compute resources allowed. More info: https://kubernetes.io/docs/concepts/configuration/manage-resources-containers/
        /// </summary>
        public readonly ImmutableDictionary<string, Union<int, string>> Limits;
        /// <summary>
        /// Requests describes the minimum amount of compute resources required. If Requests is omitted for a container, it defaults to Limits if that is explicitly specified, otherwise to an implementation-defined value. More info: https://kubernetes.io/docs/concepts/configuration/manage-resources-containers/
        /// </summary>
        public readonly ImmutableDictionary<string, Union<int, string>> Requests;

        [OutputConstructor]
        private OpenTelemetryCollectorSpecVolumesEphemeralVolumeclaimtemplateSpecResources(
            ImmutableDictionary<string, Union<int, string>> limits,

            ImmutableDictionary<string, Union<int, string>> requests)
        {
            Limits = limits;
            Requests = requests;
        }
    }
}
