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
    /// status represents the current information/status of a persistent volume claim. Read-only. More info: https://kubernetes.io/docs/concepts/storage/persistent-volumes#persistentvolumeclaims
    /// </summary>
    [OutputType]
    public sealed class OpenTelemetryCollectorSpecVolumeclaimtemplatesStatus
    {
        /// <summary>
        /// accessModes contains the actual access modes the volume backing the PVC has. More info: https://kubernetes.io/docs/concepts/storage/persistent-volumes#access-modes-1
        /// </summary>
        public readonly ImmutableArray<string> AccessModes;
        /// <summary>
        /// allocatedResources is the storage resource within AllocatedResources tracks the capacity allocated to a PVC. It may be larger than the actual capacity when a volume expansion operation is requested. For storage quota, the larger value from allocatedResources and PVC.spec.resources is used. If allocatedResources is not set, PVC.spec.resources alone is used for quota calculation. If a volume expansion capacity request is lowered, allocatedResources is only lowered if there are no expansion operations in progress and if the actual volume capacity is equal or lower than the requested capacity. This is an alpha field and requires enabling RecoverVolumeExpansionFailure feature.
        /// </summary>
        public readonly ImmutableDictionary<string, Union<int, string>> AllocatedResources;
        /// <summary>
        /// capacity represents the actual resources of the underlying volume.
        /// </summary>
        public readonly ImmutableDictionary<string, Union<int, string>> Capacity;
        /// <summary>
        /// conditions is the current Condition of persistent volume claim. If underlying persistent volume is being resized then the Condition will be set to 'ResizeStarted'.
        /// </summary>
        public readonly ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Opentelemetry.V1Alpha1.OpenTelemetryCollectorSpecVolumeclaimtemplatesStatusConditions> Conditions;
        /// <summary>
        /// phase represents the current phase of PersistentVolumeClaim.
        /// </summary>
        public readonly string Phase;
        /// <summary>
        /// resizeStatus stores status of resize operation. ResizeStatus is not set by default but when expansion is complete resizeStatus is set to empty string by resize controller or kubelet. This is an alpha field and requires enabling RecoverVolumeExpansionFailure feature.
        /// </summary>
        public readonly string ResizeStatus;

        [OutputConstructor]
        private OpenTelemetryCollectorSpecVolumeclaimtemplatesStatus(
            ImmutableArray<string> accessModes,

            ImmutableDictionary<string, Union<int, string>> allocatedResources,

            ImmutableDictionary<string, Union<int, string>> capacity,

            ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Opentelemetry.V1Alpha1.OpenTelemetryCollectorSpecVolumeclaimtemplatesStatusConditions> conditions,

            string phase,

            string resizeStatus)
        {
            AccessModes = accessModes;
            AllocatedResources = allocatedResources;
            Capacity = capacity;
            Conditions = conditions;
            Phase = phase;
            ResizeStatus = resizeStatus;
        }
    }
}
