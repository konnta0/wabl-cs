// *** WARNING: this file was generated by crd2pulumi. ***
// *** Do not edit by hand unless you're certain you know what you are doing! ***

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading.Tasks;
using Pulumi.Serialization;

namespace Pulumi.Kubernetes.Types.Outputs.Acme.V1
{

    /// <summary>
    /// A node selector term, associated with the corresponding weight.
    /// </summary>
    [OutputType]
    public sealed class ChallengeSpecSolverHttp01IngressPodtemplateSpecAffinityNodeaffinityPreferredduringschedulingignoredduringexecutionPreference
    {
        /// <summary>
        /// A list of node selector requirements by node's labels.
        /// </summary>
        public readonly ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Acme.V1.ChallengeSpecSolverHttp01IngressPodtemplateSpecAffinityNodeaffinityPreferredduringschedulingignoredduringexecutionPreferenceMatchexpressions> MatchExpressions;
        /// <summary>
        /// A list of node selector requirements by node's fields.
        /// </summary>
        public readonly ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Acme.V1.ChallengeSpecSolverHttp01IngressPodtemplateSpecAffinityNodeaffinityPreferredduringschedulingignoredduringexecutionPreferenceMatchfields> MatchFields;

        [OutputConstructor]
        private ChallengeSpecSolverHttp01IngressPodtemplateSpecAffinityNodeaffinityPreferredduringschedulingignoredduringexecutionPreference(
            ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Acme.V1.ChallengeSpecSolverHttp01IngressPodtemplateSpecAffinityNodeaffinityPreferredduringschedulingignoredduringexecutionPreferenceMatchexpressions> matchExpressions,

            ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Acme.V1.ChallengeSpecSolverHttp01IngressPodtemplateSpecAffinityNodeaffinityPreferredduringschedulingignoredduringexecutionPreferenceMatchfields> matchFields)
        {
            MatchExpressions = matchExpressions;
            MatchFields = matchFields;
        }
    }
}