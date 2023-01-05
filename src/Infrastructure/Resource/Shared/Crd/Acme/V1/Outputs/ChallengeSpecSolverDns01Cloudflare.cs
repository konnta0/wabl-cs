// *** WARNING: this file was generated by crd2pulumi. ***
// *** Do not edit by hand unless you're certain you know what you are doing! ***

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading.Tasks;
using Pulumi.Serialization;

namespace Pulumi.Kubernetes.Types.Outputs.Acme.V1
{

    /// <summary>
    /// Use the Cloudflare API to manage DNS01 challenge records.
    /// </summary>
    [OutputType]
    public sealed class ChallengeSpecSolverDns01Cloudflare
    {
        /// <summary>
        /// API key to use to authenticate with Cloudflare. Note: using an API token to authenticate is now the recommended method as it allows greater control of permissions.
        /// </summary>
        public readonly Pulumi.Kubernetes.Types.Outputs.Acme.V1.ChallengeSpecSolverDns01CloudflareApikeysecretref ApiKeySecretRef;
        /// <summary>
        /// API token used to authenticate with Cloudflare.
        /// </summary>
        public readonly Pulumi.Kubernetes.Types.Outputs.Acme.V1.ChallengeSpecSolverDns01CloudflareApitokensecretref ApiTokenSecretRef;
        /// <summary>
        /// Email of the account, only required when using API key based authentication.
        /// </summary>
        public readonly string Email;

        [OutputConstructor]
        private ChallengeSpecSolverDns01Cloudflare(
            Pulumi.Kubernetes.Types.Outputs.Acme.V1.ChallengeSpecSolverDns01CloudflareApikeysecretref apiKeySecretRef,

            Pulumi.Kubernetes.Types.Outputs.Acme.V1.ChallengeSpecSolverDns01CloudflareApitokensecretref apiTokenSecretRef,

            string email)
        {
            ApiKeySecretRef = apiKeySecretRef;
            ApiTokenSecretRef = apiTokenSecretRef;
            Email = email;
        }
    }
}
