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
    /// SelfSigned configures this issuer to 'self sign' certificates using the private key used to create the CertificateRequest object.
    /// </summary>
    [OutputType]
    public sealed class IssuerSpecSelfsigned
    {
        /// <summary>
        /// The CRL distribution points is an X.509 v3 certificate extension which identifies the location of the CRL from which the revocation of this certificate can be checked. If not set certificate will be issued without CDP. Values are strings.
        /// </summary>
        public readonly ImmutableArray<string> CrlDistributionPoints;

        [OutputConstructor]
        private IssuerSpecSelfsigned(ImmutableArray<string> crlDistributionPoints)
        {
            CrlDistributionPoints = crlDistributionPoints;
        }
    }
}