// *** WARNING: this file was generated by crd2pulumi. ***
// *** Do not edit by hand unless you're certain you know what you are doing! ***

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading.Tasks;
using Pulumi.Serialization;

namespace Pulumi.Kubernetes.Types.Outputs.Acme.V1
{

    [OutputType]
    public sealed class OrderSpec
    {
        /// <summary>
        /// CommonName is the common name as specified on the DER encoded CSR. If specified, this value must also be present in `dnsNames` or `ipAddresses`. This field must match the corresponding field on the DER encoded CSR.
        /// </summary>
        public readonly string CommonName;
        /// <summary>
        /// DNSNames is a list of DNS names that should be included as part of the Order validation process. This field must match the corresponding field on the DER encoded CSR.
        /// </summary>
        public readonly ImmutableArray<string> DnsNames;
        /// <summary>
        /// Duration is the duration for the not after date for the requested certificate. this is set on order creation as pe the ACME spec.
        /// </summary>
        public readonly string Duration;
        /// <summary>
        /// IPAddresses is a list of IP addresses that should be included as part of the Order validation process. This field must match the corresponding field on the DER encoded CSR.
        /// </summary>
        public readonly ImmutableArray<string> IpAddresses;
        /// <summary>
        /// IssuerRef references a properly configured ACME-type Issuer which should be used to create this Order. If the Issuer does not exist, processing will be retried. If the Issuer is not an 'ACME' Issuer, an error will be returned and the Order will be marked as failed.
        /// </summary>
        public readonly Pulumi.Kubernetes.Types.Outputs.Acme.V1.OrderSpecIssuerref IssuerRef;
        /// <summary>
        /// Certificate signing request bytes in DER encoding. This will be used when finalizing the order. This field must be set on the order.
        /// </summary>
        public readonly string Request;

        [OutputConstructor]
        private OrderSpec(
            string commonName,

            ImmutableArray<string> dnsNames,

            string duration,

            ImmutableArray<string> ipAddresses,

            Pulumi.Kubernetes.Types.Outputs.Acme.V1.OrderSpecIssuerref issuerRef,

            string request)
        {
            CommonName = commonName;
            DnsNames = dnsNames;
            Duration = duration;
            IpAddresses = ipAddresses;
            IssuerRef = issuerRef;
            Request = request;
        }
    }
}
