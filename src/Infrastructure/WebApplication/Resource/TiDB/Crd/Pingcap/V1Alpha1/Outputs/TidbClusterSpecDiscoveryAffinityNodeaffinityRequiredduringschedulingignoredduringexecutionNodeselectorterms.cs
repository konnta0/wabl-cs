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
    public sealed class TidbClusterSpecDiscoveryAffinityNodeaffinityRequiredduringschedulingignoredduringexecutionNodeselectorterms
    {
        public readonly ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecDiscoveryAffinityNodeaffinityRequiredduringschedulingignoredduringexecutionNodeselectortermsMatchexpressions> MatchExpressions;
        public readonly ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecDiscoveryAffinityNodeaffinityRequiredduringschedulingignoredduringexecutionNodeselectortermsMatchfields> MatchFields;

        [OutputConstructor]
        private TidbClusterSpecDiscoveryAffinityNodeaffinityRequiredduringschedulingignoredduringexecutionNodeselectorterms(
            ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecDiscoveryAffinityNodeaffinityRequiredduringschedulingignoredduringexecutionNodeselectortermsMatchexpressions> matchExpressions,

            ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecDiscoveryAffinityNodeaffinityRequiredduringschedulingignoredduringexecutionNodeselectortermsMatchfields> matchFields)
        {
            MatchExpressions = matchExpressions;
            MatchFields = matchFields;
        }
    }
}
