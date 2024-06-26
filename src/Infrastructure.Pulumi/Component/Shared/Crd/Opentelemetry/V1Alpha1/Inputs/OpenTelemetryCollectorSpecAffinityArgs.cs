// *** WARNING: this file was generated by crd2pulumi. ***
// *** Do not edit by hand unless you're certain you know what you are doing! ***

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading.Tasks;
using Pulumi.Serialization;

namespace Pulumi.Kubernetes.Types.Inputs.Opentelemetry.V1Alpha1
{

    /// <summary>
    /// If specified, indicates the pod's scheduling constraints
    /// </summary>
    public class OpenTelemetryCollectorSpecAffinityArgs : Pulumi.ResourceArgs
    {
        /// <summary>
        /// Describes node affinity scheduling rules for the pod.
        /// </summary>
        [Input("nodeAffinity")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Opentelemetry.V1Alpha1.OpenTelemetryCollectorSpecAffinityNodeaffinityArgs>? NodeAffinity { get; set; }

        /// <summary>
        /// Describes pod affinity scheduling rules (e.g. co-locate this pod in the same node, zone, etc. as some other pod(s)).
        /// </summary>
        [Input("podAffinity")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Opentelemetry.V1Alpha1.OpenTelemetryCollectorSpecAffinityPodaffinityArgs>? PodAffinity { get; set; }

        /// <summary>
        /// Describes pod anti-affinity scheduling rules (e.g. avoid putting this pod in the same node, zone, etc. as some other pod(s)).
        /// </summary>
        [Input("podAntiAffinity")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Opentelemetry.V1Alpha1.OpenTelemetryCollectorSpecAffinityPodantiaffinityArgs>? PodAntiAffinity { get; set; }

        public OpenTelemetryCollectorSpecAffinityArgs()
        {
        }
    }
}
