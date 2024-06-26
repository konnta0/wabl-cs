// *** WARNING: this file was generated by crd2pulumi. ***
// *** Do not edit by hand unless you're certain you know what you are doing! ***

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading.Tasks;
using Pulumi.Serialization;

namespace Pulumi.Kubernetes.Types.Inputs.Certmanager.V1
{

    /// <summary>
    /// Desired state of the Issuer resource.
    /// </summary>
    public class IssuerSpecArgs : Pulumi.ResourceArgs
    {
        /// <summary>
        /// ACME configures this issuer to communicate with a RFC8555 (ACME) server to obtain signed x509 certificates.
        /// </summary>
        [Input("acme")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Certmanager.V1.IssuerSpecAcmeArgs>? Acme { get; set; }

        /// <summary>
        /// CA configures this issuer to sign certificates using a signing CA keypair stored in a Secret resource. This is used to build internal PKIs that are managed by cert-manager.
        /// </summary>
        [Input("ca")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Certmanager.V1.IssuerSpecCaArgs>? Ca { get; set; }

        /// <summary>
        /// SelfSigned configures this issuer to 'self sign' certificates using the private key used to create the CertificateRequest object.
        /// </summary>
        [Input("selfSigned")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Certmanager.V1.IssuerSpecSelfsignedArgs>? SelfSigned { get; set; }

        /// <summary>
        /// Vault configures this issuer to sign certificates using a HashiCorp Vault PKI backend.
        /// </summary>
        [Input("vault")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Certmanager.V1.IssuerSpecVaultArgs>? Vault { get; set; }

        /// <summary>
        /// Venafi configures this issuer to sign certificates using a Venafi TPP or Venafi Cloud policy zone.
        /// </summary>
        [Input("venafi")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Certmanager.V1.IssuerSpecVenafiArgs>? Venafi { get; set; }

        public IssuerSpecArgs()
        {
        }
    }
}
