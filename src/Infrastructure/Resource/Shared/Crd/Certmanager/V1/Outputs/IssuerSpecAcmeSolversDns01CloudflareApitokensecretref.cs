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
    /// API token used to authenticate with Cloudflare.
    /// </summary>
    [OutputType]
    public sealed class IssuerSpecAcmeSolversDns01CloudflareApitokensecretref
    {
        /// <summary>
        /// The key of the entry in the Secret resource's `data` field to be used. Some instances of this field may be defaulted, in others it may be required.
        /// </summary>
        public readonly string Key;
        /// <summary>
        /// Name of the resource being referred to. More info: https://kubernetes.io/docs/concepts/overview/working-with-objects/names/#names
        /// </summary>
        public readonly string Name;

        [OutputConstructor]
        private IssuerSpecAcmeSolversDns01CloudflareApitokensecretref(
            string key,

            string name)
        {
            Key = key;
            Name = name;
        }
    }
}
