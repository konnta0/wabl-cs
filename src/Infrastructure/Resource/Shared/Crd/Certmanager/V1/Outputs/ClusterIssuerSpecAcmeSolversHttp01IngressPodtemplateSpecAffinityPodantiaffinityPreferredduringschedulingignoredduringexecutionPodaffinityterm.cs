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
    /// Required. A pod affinity term, associated with the corresponding weight.
    /// </summary>
    [OutputType]
    public sealed class ClusterIssuerSpecAcmeSolversHttp01IngressPodtemplateSpecAffinityPodantiaffinityPreferredduringschedulingignoredduringexecutionPodaffinityterm
    {
        /// <summary>
        /// A label query over a set of resources, in this case pods.
        /// </summary>
        public readonly Pulumi.Kubernetes.Types.Outputs.Certmanager.V1.ClusterIssuerSpecAcmeSolversHttp01IngressPodtemplateSpecAffinityPodantiaffinityPreferredduringschedulingignoredduringexecutionPodaffinitytermLabelselector LabelSelector;
        /// <summary>
        /// A label query over the set of namespaces that the term applies to. The term is applied to the union of the namespaces selected by this field and the ones listed in the namespaces field. null selector and null or empty namespaces list means "this pod's namespace". An empty selector ({}) matches all namespaces. This field is beta-level and is only honored when PodAffinityNamespaceSelector feature is enabled.
        /// </summary>
        public readonly Pulumi.Kubernetes.Types.Outputs.Certmanager.V1.ClusterIssuerSpecAcmeSolversHttp01IngressPodtemplateSpecAffinityPodantiaffinityPreferredduringschedulingignoredduringexecutionPodaffinitytermNamespaceselector NamespaceSelector;
        /// <summary>
        /// namespaces specifies a static list of namespace names that the term applies to. The term is applied to the union of the namespaces listed in this field and the ones selected by namespaceSelector. null or empty namespaces list and null namespaceSelector means "this pod's namespace"
        /// </summary>
        public readonly ImmutableArray<string> Namespaces;
        /// <summary>
        /// This pod should be co-located (affinity) or not co-located (anti-affinity) with the pods matching the labelSelector in the specified namespaces, where co-located is defined as running on a node whose value of the label with key topologyKey matches that of any node on which any of the selected pods is running. Empty topologyKey is not allowed.
        /// </summary>
        public readonly string TopologyKey;

        [OutputConstructor]
        private ClusterIssuerSpecAcmeSolversHttp01IngressPodtemplateSpecAffinityPodantiaffinityPreferredduringschedulingignoredduringexecutionPodaffinityterm(
            Pulumi.Kubernetes.Types.Outputs.Certmanager.V1.ClusterIssuerSpecAcmeSolversHttp01IngressPodtemplateSpecAffinityPodantiaffinityPreferredduringschedulingignoredduringexecutionPodaffinitytermLabelselector labelSelector,

            Pulumi.Kubernetes.Types.Outputs.Certmanager.V1.ClusterIssuerSpecAcmeSolversHttp01IngressPodtemplateSpecAffinityPodantiaffinityPreferredduringschedulingignoredduringexecutionPodaffinitytermNamespaceselector namespaceSelector,

            ImmutableArray<string> namespaces,

            string topologyKey)
        {
            LabelSelector = labelSelector;
            NamespaceSelector = namespaceSelector;
            Namespaces = namespaces;
            TopologyKey = topologyKey;
        }
    }
}
