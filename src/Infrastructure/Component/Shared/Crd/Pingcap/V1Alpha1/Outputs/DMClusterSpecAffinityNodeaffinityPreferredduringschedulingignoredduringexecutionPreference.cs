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
    public sealed class DMClusterSpecAffinityNodeaffinityPreferredduringschedulingignoredduringexecutionPreference
    {
        public readonly ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.DMClusterSpecAffinityNodeaffinityPreferredduringschedulingignoredduringexecutionPreferenceMatchexpressions> MatchExpressions;
        public readonly ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.DMClusterSpecAffinityNodeaffinityPreferredduringschedulingignoredduringexecutionPreferenceMatchfields> MatchFields;

        [OutputConstructor]
        private DMClusterSpecAffinityNodeaffinityPreferredduringschedulingignoredduringexecutionPreference(
            ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.DMClusterSpecAffinityNodeaffinityPreferredduringschedulingignoredduringexecutionPreferenceMatchexpressions> matchExpressions,

            ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.DMClusterSpecAffinityNodeaffinityPreferredduringschedulingignoredduringexecutionPreferenceMatchfields> matchFields)
        {
            MatchExpressions = matchExpressions;
            MatchFields = matchFields;
        }
    }
}