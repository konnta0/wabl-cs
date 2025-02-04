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
    /// Use the Google Cloud DNS API to manage DNS01 challenge records.
    /// </summary>
    [OutputType]
    public sealed class IssuerSpecAcmeSolversDns01Clouddns
    {
        /// <summary>
        /// HostedZoneName is an optional field that tells cert-manager in which Cloud DNS zone the challenge record has to be created. If left empty cert-manager will automatically choose a zone.
        /// </summary>
        public readonly string HostedZoneName;
        public readonly string Project;
        /// <summary>
        /// A reference to a specific 'key' within a Secret resource. In some instances, `key` is a required field.
        /// </summary>
        public readonly Pulumi.Kubernetes.Types.Outputs.Certmanager.V1.IssuerSpecAcmeSolversDns01ClouddnsServiceaccountsecretref ServiceAccountSecretRef;

        [OutputConstructor]
        private IssuerSpecAcmeSolversDns01Clouddns(
            string hostedZoneName,

            string project,

            Pulumi.Kubernetes.Types.Outputs.Certmanager.V1.IssuerSpecAcmeSolversDns01ClouddnsServiceaccountsecretref serviceAccountSecretRef)
        {
            HostedZoneName = hostedZoneName;
            Project = project;
            ServiceAccountSecretRef = serviceAccountSecretRef;
        }
    }
}
