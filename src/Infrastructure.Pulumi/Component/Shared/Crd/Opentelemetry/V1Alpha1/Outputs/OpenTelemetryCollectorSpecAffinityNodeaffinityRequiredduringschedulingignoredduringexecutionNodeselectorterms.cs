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
    /// A null or empty node selector term matches no objects. The requirements of them are ANDed. The TopologySelectorTerm type implements a subset of the NodeSelectorTerm.
    /// </summary>
    [OutputType]
    public sealed class OpenTelemetryCollectorSpecAffinityNodeaffinityRequiredduringschedulingignoredduringexecutionNodeselectorterms
    {
        /// <summary>
        /// A list of node selector requirements by node's labels.
        /// </summary>
        public readonly ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Opentelemetry.V1Alpha1.OpenTelemetryCollectorSpecAffinityNodeaffinityRequiredduringschedulingignoredduringexecutionNodeselectortermsMatchexpressions> MatchExpressions;
        /// <summary>
        /// A list of node selector requirements by node's fields.
        /// </summary>
        public readonly ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Opentelemetry.V1Alpha1.OpenTelemetryCollectorSpecAffinityNodeaffinityRequiredduringschedulingignoredduringexecutionNodeselectortermsMatchfields> MatchFields;

        [OutputConstructor]
        private OpenTelemetryCollectorSpecAffinityNodeaffinityRequiredduringschedulingignoredduringexecutionNodeselectorterms(
            ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Opentelemetry.V1Alpha1.OpenTelemetryCollectorSpecAffinityNodeaffinityRequiredduringschedulingignoredduringexecutionNodeselectortermsMatchexpressions> matchExpressions,

            ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Opentelemetry.V1Alpha1.OpenTelemetryCollectorSpecAffinityNodeaffinityRequiredduringschedulingignoredduringexecutionNodeselectortermsMatchfields> matchFields)
        {
            MatchExpressions = matchExpressions;
            MatchFields = matchFields;
        }
    }
}
