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
    /// TPP specifies Trust Protection Platform configuration settings. Only one of TPP or Cloud may be specified.
    /// </summary>
    [OutputType]
    public sealed class IssuerSpecVenafiTpp
    {
        /// <summary>
        /// CABundle is a PEM encoded TLS certificate to use to verify connections to the TPP instance. If specified, system roots will not be used and the issuing CA for the TPP instance must be verifiable using the provided root. If not specified, the connection will be verified using the cert-manager system root certificates.
        /// </summary>
        public readonly string CaBundle;
        /// <summary>
        /// CredentialsRef is a reference to a Secret containing the username and password for the TPP server. The secret must contain two keys, 'username' and 'password'.
        /// </summary>
        public readonly Pulumi.Kubernetes.Types.Outputs.Certmanager.V1.IssuerSpecVenafiTppCredentialsref CredentialsRef;
        /// <summary>
        /// URL is the base URL for the vedsdk endpoint of the Venafi TPP instance, for example: "https://tpp.example.com/vedsdk".
        /// </summary>
        public readonly string Url;

        [OutputConstructor]
        private IssuerSpecVenafiTpp(
            string caBundle,

            Pulumi.Kubernetes.Types.Outputs.Certmanager.V1.IssuerSpecVenafiTppCredentialsref credentialsRef,

            string url)
        {
            CaBundle = caBundle;
            CredentialsRef = credentialsRef;
            Url = url;
        }
    }
}
