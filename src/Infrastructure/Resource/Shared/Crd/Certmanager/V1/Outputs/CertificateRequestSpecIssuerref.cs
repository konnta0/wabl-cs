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
    /// IssuerRef is a reference to the issuer for this CertificateRequest.  If the `kind` field is not set, or set to `Issuer`, an Issuer resource with the given name in the same namespace as the CertificateRequest will be used.  If the `kind` field is set to `ClusterIssuer`, a ClusterIssuer with the provided name will be used. The `name` field in this stanza is required at all times. The group field refers to the API group of the issuer which defaults to `cert-manager.io` if empty.
    /// </summary>
    [OutputType]
    public sealed class CertificateRequestSpecIssuerref
    {
        /// <summary>
        /// Group of the resource being referred to.
        /// </summary>
        public readonly string Group;
        /// <summary>
        /// Kind of the resource being referred to.
        /// </summary>
        public readonly string Kind;
        /// <summary>
        /// Name of the resource being referred to.
        /// </summary>
        public readonly string Name;

        [OutputConstructor]
        private CertificateRequestSpecIssuerref(
            string group,

            string kind,

            string name)
        {
            Group = group;
            Kind = kind;
            Name = name;
        }
    }
}
