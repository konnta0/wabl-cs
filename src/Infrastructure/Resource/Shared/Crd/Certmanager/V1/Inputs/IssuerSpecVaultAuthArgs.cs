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
    /// Auth configures how cert-manager authenticates with the Vault server.
    /// </summary>
    public class IssuerSpecVaultAuthArgs : Pulumi.ResourceArgs
    {
        /// <summary>
        /// AppRole authenticates with Vault using the App Role auth mechanism, with the role and secret stored in a Kubernetes Secret resource.
        /// </summary>
        [Input("appRole")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Certmanager.V1.IssuerSpecVaultAuthApproleArgs>? AppRole { get; set; }

        /// <summary>
        /// Kubernetes authenticates with Vault by passing the ServiceAccount token stored in the named Secret resource to the Vault server.
        /// </summary>
        [Input("kubernetes")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Certmanager.V1.IssuerSpecVaultAuthKubernetesArgs>? Kubernetes { get; set; }

        /// <summary>
        /// TokenSecretRef authenticates with Vault by presenting a token.
        /// </summary>
        [Input("tokenSecretRef")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Certmanager.V1.IssuerSpecVaultAuthTokensecretrefArgs>? TokenSecretRef { get; set; }

        public IssuerSpecVaultAuthArgs()
        {
        }
    }
}
