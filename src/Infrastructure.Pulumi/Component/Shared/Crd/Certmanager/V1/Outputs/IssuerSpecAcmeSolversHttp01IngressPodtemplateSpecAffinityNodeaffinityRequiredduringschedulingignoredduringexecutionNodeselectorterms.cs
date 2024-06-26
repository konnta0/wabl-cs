// *** WARNING: this file was generated by crd2pulumi. ***
// *** Do not edit by hand unless you're certain you know what you are doing! ***

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading.Tasks;
using Pulumi.Serialization;

namespace Pulumi.Kubernetes.Types.Outputs.Certmanager.V1
{

    /// <summary>
    /// A null or empty node selector term matches no objects. The requirements of them are ANDed. The TopologySelectorTerm type implements a subset of the NodeSelectorTerm.
    /// </summary>
    [OutputType]
    public sealed class IssuerSpecAcmeSolversHttp01IngressPodtemplateSpecAffinityNodeaffinityRequiredduringschedulingignoredduringexecutionNodeselectorterms
    {
        /// <summary>
        /// A list of node selector requirements by node's labels.
        /// </summary>
        public readonly ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Certmanager.V1.IssuerSpecAcmeSolversHttp01IngressPodtemplateSpecAffinityNodeaffinityRequiredduringschedulingignoredduringexecutionNodeselectortermsMatchexpressions> MatchExpressions;
        /// <summary>
        /// A list of node selector requirements by node's fields.
        /// </summary>
        public readonly ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Certmanager.V1.IssuerSpecAcmeSolversHttp01IngressPodtemplateSpecAffinityNodeaffinityRequiredduringschedulingignoredduringexecutionNodeselectortermsMatchfields> MatchFields;

        [OutputConstructor]
        private IssuerSpecAcmeSolversHttp01IngressPodtemplateSpecAffinityNodeaffinityRequiredduringschedulingignoredduringexecutionNodeselectorterms(
            ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Certmanager.V1.IssuerSpecAcmeSolversHttp01IngressPodtemplateSpecAffinityNodeaffinityRequiredduringschedulingignoredduringexecutionNodeselectortermsMatchexpressions> matchExpressions,

            ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Certmanager.V1.IssuerSpecAcmeSolversHttp01IngressPodtemplateSpecAffinityNodeaffinityRequiredduringschedulingignoredduringexecutionNodeselectortermsMatchfields> matchFields)
        {
            MatchExpressions = matchExpressions;
            MatchFields = matchFields;
        }
    }
}
