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
    /// PodSpec defines overrides for the HTTP01 challenge solver pod. Only the 'priorityClassName', 'nodeSelector', 'affinity', 'serviceAccountName' and 'tolerations' fields are supported currently. All other fields will be ignored.
    /// </summary>
    [OutputType]
    public sealed class ClusterIssuerSpecAcmeSolversHttp01IngressPodtemplateSpec
    {
        /// <summary>
        /// If specified, the pod's scheduling constraints
        /// </summary>
        public readonly Pulumi.Kubernetes.Types.Outputs.Certmanager.V1.ClusterIssuerSpecAcmeSolversHttp01IngressPodtemplateSpecAffinity Affinity;
        /// <summary>
        /// NodeSelector is a selector which must be true for the pod to fit on a node. Selector which must match a node's labels for the pod to be scheduled on that node. More info: https://kubernetes.io/docs/concepts/configuration/assign-pod-node/
        /// </summary>
        public readonly ImmutableDictionary<string, string> NodeSelector;
        /// <summary>
        /// If specified, the pod's priorityClassName.
        /// </summary>
        public readonly string PriorityClassName;
        /// <summary>
        /// If specified, the pod's service account
        /// </summary>
        public readonly string ServiceAccountName;
        /// <summary>
        /// If specified, the pod's tolerations.
        /// </summary>
        public readonly ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Certmanager.V1.ClusterIssuerSpecAcmeSolversHttp01IngressPodtemplateSpecTolerations> Tolerations;

        [OutputConstructor]
        private ClusterIssuerSpecAcmeSolversHttp01IngressPodtemplateSpec(
            Pulumi.Kubernetes.Types.Outputs.Certmanager.V1.ClusterIssuerSpecAcmeSolversHttp01IngressPodtemplateSpecAffinity affinity,

            ImmutableDictionary<string, string> nodeSelector,

            string priorityClassName,

            string serviceAccountName,

            ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Certmanager.V1.ClusterIssuerSpecAcmeSolversHttp01IngressPodtemplateSpecTolerations> tolerations)
        {
            Affinity = affinity;
            NodeSelector = nodeSelector;
            PriorityClassName = priorityClassName;
            ServiceAccountName = serviceAccountName;
            Tolerations = tolerations;
        }
    }
}
