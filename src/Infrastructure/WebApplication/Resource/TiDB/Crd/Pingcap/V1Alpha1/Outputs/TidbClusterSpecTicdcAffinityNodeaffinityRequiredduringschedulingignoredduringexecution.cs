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
    public sealed class TidbClusterSpecTicdcAffinityNodeaffinityRequiredduringschedulingignoredduringexecution
    {
        public readonly ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecTicdcAffinityNodeaffinityRequiredduringschedulingignoredduringexecutionNodeselectorterms> NodeSelectorTerms;

        [OutputConstructor]
        private TidbClusterSpecTicdcAffinityNodeaffinityRequiredduringschedulingignoredduringexecution(ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecTicdcAffinityNodeaffinityRequiredduringschedulingignoredduringexecutionNodeselectorterms> nodeSelectorTerms)
        {
            NodeSelectorTerms = nodeSelectorTerms;
        }
    }
}
