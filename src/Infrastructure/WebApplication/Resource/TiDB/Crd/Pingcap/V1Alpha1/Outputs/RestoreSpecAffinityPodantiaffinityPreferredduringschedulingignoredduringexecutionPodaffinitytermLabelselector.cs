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
    public sealed class RestoreSpecAffinityPodantiaffinityPreferredduringschedulingignoredduringexecutionPodaffinitytermLabelselector
    {
        public readonly ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.RestoreSpecAffinityPodantiaffinityPreferredduringschedulingignoredduringexecutionPodaffinitytermLabelselectorMatchexpressions> MatchExpressions;
        public readonly ImmutableDictionary<string, string> MatchLabels;

        [OutputConstructor]
        private RestoreSpecAffinityPodantiaffinityPreferredduringschedulingignoredduringexecutionPodaffinitytermLabelselector(
            ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.RestoreSpecAffinityPodantiaffinityPreferredduringschedulingignoredduringexecutionPodaffinitytermLabelselectorMatchexpressions> matchExpressions,

            ImmutableDictionary<string, string> matchLabels)
        {
            MatchExpressions = matchExpressions;
            MatchLabels = matchLabels;
        }
    }
}
