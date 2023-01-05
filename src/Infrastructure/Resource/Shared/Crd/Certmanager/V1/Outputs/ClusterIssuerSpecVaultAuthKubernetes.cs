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
    /// Kubernetes authenticates with Vault by passing the ServiceAccount token stored in the named Secret resource to the Vault server.
    /// </summary>
    [OutputType]
    public sealed class ClusterIssuerSpecVaultAuthKubernetes
    {
        /// <summary>
        /// The Vault mountPath here is the mount path to use when authenticating with Vault. For example, setting a value to `/v1/auth/foo`, will use the path `/v1/auth/foo/login` to authenticate with Vault. If unspecified, the default value "/v1/auth/kubernetes" will be used.
        /// </summary>
        public readonly string MountPath;
        /// <summary>
        /// A required field containing the Vault Role to assume. A Role binds a Kubernetes ServiceAccount with a set of Vault policies.
        /// </summary>
        public readonly string Role;
        /// <summary>
        /// The required Secret field containing a Kubernetes ServiceAccount JWT used for authenticating with Vault. Use of 'ambient credentials' is not supported.
        /// </summary>
        public readonly Pulumi.Kubernetes.Types.Outputs.Certmanager.V1.ClusterIssuerSpecVaultAuthKubernetesSecretref SecretRef;

        [OutputConstructor]
        private ClusterIssuerSpecVaultAuthKubernetes(
            string mountPath,

            string role,

            Pulumi.Kubernetes.Types.Outputs.Certmanager.V1.ClusterIssuerSpecVaultAuthKubernetesSecretref secretRef)
        {
            MountPath = mountPath;
            Role = role;
            SecretRef = secretRef;
        }
    }
}
