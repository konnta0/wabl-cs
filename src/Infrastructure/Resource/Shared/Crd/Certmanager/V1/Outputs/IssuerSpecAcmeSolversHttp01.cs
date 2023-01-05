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
    /// Configures cert-manager to attempt to complete authorizations by performing the HTTP01 challenge flow. It is not possible to obtain certificates for wildcard domain names (e.g. `*.example.com`) using the HTTP01 challenge mechanism.
    /// </summary>
    [OutputType]
    public sealed class IssuerSpecAcmeSolversHttp01
    {
        /// <summary>
        /// The Gateway API is a sig-network community API that models service networking in Kubernetes (https://gateway-api.sigs.k8s.io/). The Gateway solver will create HTTPRoutes with the specified labels in the same namespace as the challenge. This solver is experimental, and fields / behaviour may change in the future.
        /// </summary>
        public readonly Pulumi.Kubernetes.Types.Outputs.Certmanager.V1.IssuerSpecAcmeSolversHttp01Gatewayhttproute GatewayHTTPRoute;
        /// <summary>
        /// The ingress based HTTP01 challenge solver will solve challenges by creating or modifying Ingress resources in order to route requests for '/.well-known/acme-challenge/XYZ' to 'challenge solver' pods that are provisioned by cert-manager for each Challenge to be completed.
        /// </summary>
        public readonly Pulumi.Kubernetes.Types.Outputs.Certmanager.V1.IssuerSpecAcmeSolversHttp01Ingress Ingress;

        [OutputConstructor]
        private IssuerSpecAcmeSolversHttp01(
            Pulumi.Kubernetes.Types.Outputs.Certmanager.V1.IssuerSpecAcmeSolversHttp01Gatewayhttproute gatewayHTTPRoute,

            Pulumi.Kubernetes.Types.Outputs.Certmanager.V1.IssuerSpecAcmeSolversHttp01Ingress ingress)
        {
            GatewayHTTPRoute = gatewayHTTPRoute;
            Ingress = ingress;
        }
    }
}
