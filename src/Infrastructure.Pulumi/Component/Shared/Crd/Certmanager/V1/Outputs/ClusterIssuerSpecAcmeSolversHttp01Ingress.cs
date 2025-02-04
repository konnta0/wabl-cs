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
    /// The ingress based HTTP01 challenge solver will solve challenges by creating or modifying Ingress resources in order to route requests for '/.well-known/acme-challenge/XYZ' to 'challenge solver' pods that are provisioned by cert-manager for each Challenge to be completed.
    /// </summary>
    [OutputType]
    public sealed class ClusterIssuerSpecAcmeSolversHttp01Ingress
    {
        /// <summary>
        /// The ingress class to use when creating Ingress resources to solve ACME challenges that use this challenge solver. Only one of 'class' or 'name' may be specified.
        /// </summary>
        public readonly string Class;
        /// <summary>
        /// Optional ingress template used to configure the ACME challenge solver ingress used for HTTP01 challenges.
        /// </summary>
        public readonly Pulumi.Kubernetes.Types.Outputs.Certmanager.V1.ClusterIssuerSpecAcmeSolversHttp01IngressIngresstemplate IngressTemplate;
        /// <summary>
        /// The name of the ingress resource that should have ACME challenge solving routes inserted into it in order to solve HTTP01 challenges. This is typically used in conjunction with ingress controllers like ingress-gce, which maintains a 1:1 mapping between external IPs and ingress resources.
        /// </summary>
        public readonly string Name;
        /// <summary>
        /// Optional pod template used to configure the ACME challenge solver pods used for HTTP01 challenges.
        /// </summary>
        public readonly Pulumi.Kubernetes.Types.Outputs.Certmanager.V1.ClusterIssuerSpecAcmeSolversHttp01IngressPodtemplate PodTemplate;
        /// <summary>
        /// Optional service type for Kubernetes solver service. Supported values are NodePort or ClusterIP. If unset, defaults to NodePort.
        /// </summary>
        public readonly string ServiceType;

        [OutputConstructor]
        private ClusterIssuerSpecAcmeSolversHttp01Ingress(
            string @class,

            Pulumi.Kubernetes.Types.Outputs.Certmanager.V1.ClusterIssuerSpecAcmeSolversHttp01IngressIngresstemplate ingressTemplate,

            string name,

            Pulumi.Kubernetes.Types.Outputs.Certmanager.V1.ClusterIssuerSpecAcmeSolversHttp01IngressPodtemplate podTemplate,

            string serviceType)
        {
            Class = @class;
            IngressTemplate = ingressTemplate;
            Name = name;
            PodTemplate = podTemplate;
            ServiceType = serviceType;
        }
    }
}
