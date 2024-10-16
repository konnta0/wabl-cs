// *** WARNING: this file was generated by crd2pulumi. ***
// *** Do not edit by hand unless you're certain you know what you are doing! ***

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading.Tasks;
using Pulumi.Serialization;

namespace Pulumi.Crds.Certmanager.V1
{
    /// <summary>
    /// An Issuer represents a certificate issuing authority which can be referenced as part of `issuerRef` fields. It is scoped to a single namespace and can therefore only be referenced by resources within the same namespace.
    /// </summary>
    [CrdsResourceType("kubernetes:cert-manager.io/v1:Issuer")]
    public partial class Issuer : KubernetesResource
    {
        [Output("apiVersion")]
        public Output<string> ApiVersion { get; private set; } = null!;

        [Output("kind")]
        public Output<string> Kind { get; private set; } = null!;

        [Output("metadata")]
        public Output<Pulumi.Kubernetes.Types.Outputs.Meta.V1.ObjectMeta> Metadata { get; private set; } = null!;

        /// <summary>
        /// Desired state of the Issuer resource.
        /// </summary>
        [Output("spec")]
        public Output<Pulumi.Kubernetes.Types.Outputs.Certmanager.V1.IssuerSpec> Spec { get; private set; } = null!;

        /// <summary>
        /// Status of the Issuer. This is set and managed automatically.
        /// </summary>
        [Output("status")]
        public Output<Pulumi.Kubernetes.Types.Outputs.Certmanager.V1.IssuerStatus> Status { get; private set; } = null!;


        /// <summary>
        /// Create a Issuer resource with the given unique name, arguments, and options.
        /// </summary>
        ///
        /// <param name="name">The unique name of the resource</param>
        /// <param name="args">The arguments used to populate this resource's properties</param>
        /// <param name="options">A bag of options that control this resource's behavior</param>
        public Issuer(string name, Pulumi.Kubernetes.Types.Inputs.Certmanager.V1.IssuerArgs? args = null, CustomResourceOptions? options = null)
            : base("kubernetes:cert-manager.io/v1:Issuer", name, MakeArgs(args), MakeResourceOptions(options, ""))
        {
        }
        internal Issuer(string name, ImmutableDictionary<string, object?> dictionary, CustomResourceOptions? options = null)
            : base("kubernetes:cert-manager.io/v1:Issuer", name, new DictionaryResourceArgs(dictionary), MakeResourceOptions(options, ""))
        {
        }

        private Issuer(string name, Input<string> id, CustomResourceOptions? options = null)
            : base("kubernetes:cert-manager.io/v1:Issuer", name, null, MakeResourceOptions(options, id))
        {
        }

        private static Pulumi.Kubernetes.Types.Inputs.Certmanager.V1.IssuerArgs? MakeArgs(Pulumi.Kubernetes.Types.Inputs.Certmanager.V1.IssuerArgs? args)
        {
            args ??= new Pulumi.Kubernetes.Types.Inputs.Certmanager.V1.IssuerArgs();
            args.ApiVersion = "cert-manager.io/v1";
            args.Kind = "Issuer";
            return args;
        }

        private static CustomResourceOptions MakeResourceOptions(CustomResourceOptions? options, Input<string>? id)
        {
            var defaultOptions = new CustomResourceOptions
            {
                Version = Utilities.Version,
            };
            var merged = CustomResourceOptions.Merge(defaultOptions, options);
            // Override the ID if one was specified for consistency with other language SDKs.
            merged.Id = id ?? merged.Id;
            return merged;
        }
        /// <summary>
        /// Get an existing Issuer resource's state with the given name, ID, and optional extra
        /// properties used to qualify the lookup.
        /// </summary>
        ///
        /// <param name="name">The unique name of the resulting resource.</param>
        /// <param name="id">The unique provider ID of the resource to lookup.</param>
        /// <param name="options">A bag of options that control this resource's behavior</param>
        public static Issuer Get(string name, Input<string> id, CustomResourceOptions? options = null)
        {
            return new Issuer(name, id, options);
        }
    }
}
namespace Pulumi.Kubernetes.Types.Inputs.Certmanager.V1
{

    public class IssuerArgs : Pulumi.ResourceArgs
    {
        [Input("apiVersion")]
        public Input<string>? ApiVersion { get; set; }

        [Input("kind")]
        public Input<string>? Kind { get; set; }

        [Input("metadata")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Meta.V1.ObjectMetaArgs>? Metadata { get; set; }

        /// <summary>
        /// Desired state of the Issuer resource.
        /// </summary>
        [Input("spec")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Certmanager.V1.IssuerSpecArgs>? Spec { get; set; }

        /// <summary>
        /// Status of the Issuer. This is set and managed automatically.
        /// </summary>
        [Input("status")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Certmanager.V1.IssuerStatusArgs>? Status { get; set; }

        public IssuerArgs()
        {
        }
    }
}
