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
    public sealed class TidbClusterSpecTicdcAffinityNodeaffinityRequiredduringschedulingignoredduringexecutionNodeselectorterms
    {
        public readonly ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecTicdcAffinityNodeaffinityRequiredduringschedulingignoredduringexecutionNodeselectortermsMatchexpressions> MatchExpressions;
        public readonly ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecTicdcAffinityNodeaffinityRequiredduringschedulingignoredduringexecutionNodeselectortermsMatchfields> MatchFields;

        [OutputConstructor]
        private TidbClusterSpecTicdcAffinityNodeaffinityRequiredduringschedulingignoredduringexecutionNodeselectorterms(
            ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecTicdcAffinityNodeaffinityRequiredduringschedulingignoredduringexecutionNodeselectortermsMatchexpressions> matchExpressions,

            ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecTicdcAffinityNodeaffinityRequiredduringschedulingignoredduringexecutionNodeselectortermsMatchfields> matchFields)
        {
            MatchExpressions = matchExpressions;
            MatchFields = matchFields;
        }
    }
}