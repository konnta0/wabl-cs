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
    /// The Gateway API is a sig-network community API that models service networking in Kubernetes (https://gateway-api.sigs.k8s.io/). The Gateway solver will create HTTPRoutes with the specified labels in the same namespace as the challenge. This solver is experimental, and fields / behaviour may change in the future.
    /// </summary>
    [OutputType]
    public sealed class IssuerSpecAcmeSolversHttp01Gatewayhttproute
    {
        /// <summary>
        /// Custom labels that will be applied to HTTPRoutes created by cert-manager while solving HTTP-01 challenges.
        /// </summary>
        public readonly ImmutableDictionary<string, string> Labels;
        /// <summary>
        /// When solving an HTTP-01 challenge, cert-manager creates an HTTPRoute. cert-manager needs to know which parentRefs should be used when creating the HTTPRoute. Usually, the parentRef references a Gateway. See: https://gateway-api.sigs.k8s.io/v1alpha2/api-types/httproute/#attaching-to-gateways
        /// </summary>
        public readonly ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Certmanager.V1.IssuerSpecAcmeSolversHttp01GatewayhttprouteParentrefs> ParentRefs;
        /// <summary>
        /// Optional service type for Kubernetes solver service. Supported values are NodePort or ClusterIP. If unset, defaults to NodePort.
        /// </summary>
        public readonly string ServiceType;

        [OutputConstructor]
        private IssuerSpecAcmeSolversHttp01Gatewayhttproute(
            ImmutableDictionary<string, string> labels,

            ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Certmanager.V1.IssuerSpecAcmeSolversHttp01GatewayhttprouteParentrefs> parentRefs,

            string serviceType)
        {
            Labels = labels;
            ParentRefs = parentRefs;
            ServiceType = serviceType;
        }
    }
}
