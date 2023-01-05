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
    /// A label query over the set of namespaces that the term applies to. The term is applied to the union of the namespaces selected by this field and the ones listed in the namespaces field. null selector and null or empty namespaces list means "this pod's namespace". An empty selector ({}) matches all namespaces. This field is beta-level and is only honored when PodAffinityNamespaceSelector feature is enabled.
    /// </summary>
    [OutputType]
    public sealed class IssuerSpecAcmeSolversHttp01IngressPodtemplateSpecAffinityPodaffinityRequiredduringschedulingignoredduringexecutionNamespaceselector
    {
        /// <summary>
        /// matchExpressions is a list of label selector requirements. The requirements are ANDed.
        /// </summary>
        public readonly ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Certmanager.V1.IssuerSpecAcmeSolversHttp01IngressPodtemplateSpecAffinityPodaffinityRequiredduringschedulingignoredduringexecutionNamespaceselectorMatchexpressions> MatchExpressions;
        /// <summary>
        /// matchLabels is a map of {key,value} pairs. A single {key,value} in the matchLabels map is equivalent to an element of matchExpressions, whose key field is "key", the operator is "In", and the values array contains only "value". The requirements are ANDed.
        /// </summary>
        public readonly ImmutableDictionary<string, string> MatchLabels;

        [OutputConstructor]
        private IssuerSpecAcmeSolversHttp01IngressPodtemplateSpecAffinityPodaffinityRequiredduringschedulingignoredduringexecutionNamespaceselector(
            ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Certmanager.V1.IssuerSpecAcmeSolversHttp01IngressPodtemplateSpecAffinityPodaffinityRequiredduringschedulingignoredduringexecutionNamespaceselectorMatchexpressions> matchExpressions,

            ImmutableDictionary<string, string> matchLabels)
        {
            MatchExpressions = matchExpressions;
            MatchLabels = matchLabels;
        }
    }
}
