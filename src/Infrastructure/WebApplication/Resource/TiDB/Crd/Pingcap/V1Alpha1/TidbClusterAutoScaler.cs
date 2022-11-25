// *** WARNING: this file was generated by crd2pulumi. ***
// *** Do not edit by hand unless you're certain you know what you are doing! ***

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading.Tasks;
using Pulumi.Serialization;

namespace Pulumi.Crds.Pingcap.V1Alpha1
{
    [CrdsResourceType("kubernetes:pingcap.com/v1alpha1:TidbClusterAutoScaler")]
    public partial class TidbClusterAutoScaler : KubernetesResource
    {
        [Output("apiVersion")]
        public Output<string> ApiVersion { get; private set; } = null!;

        [Output("kind")]
        public Output<string> Kind { get; private set; } = null!;

        [Output("metadata")]
        public Output<Pulumi.Kubernetes.Types.Outputs.Meta.V1.ObjectMeta> Metadata { get; private set; } = null!;

        [Output("spec")]
        public Output<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterAutoScalerSpec> Spec { get; private set; } = null!;

        [Output("status")]
        public Output<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterAutoScalerStatus> Status { get; private set; } = null!;


        /// <summary>
        /// Create a TidbClusterAutoScaler resource with the given unique name, arguments, and options.
        /// </summary>
        ///
        /// <param name="name">The unique name of the resource</param>
        /// <param name="args">The arguments used to populate this resource's properties</param>
        /// <param name="options">A bag of options that control this resource's behavior</param>
        public TidbClusterAutoScaler(string name, Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterAutoScalerArgs? args = null, CustomResourceOptions? options = null)
            : base("kubernetes:pingcap.com/v1alpha1:TidbClusterAutoScaler", name, MakeArgs(args), MakeResourceOptions(options, ""))
        {
        }
        internal TidbClusterAutoScaler(string name, ImmutableDictionary<string, object?> dictionary, CustomResourceOptions? options = null)
            : base("kubernetes:pingcap.com/v1alpha1:TidbClusterAutoScaler", name, new DictionaryResourceArgs(dictionary), MakeResourceOptions(options, ""))
        {
        }

        private TidbClusterAutoScaler(string name, Input<string> id, CustomResourceOptions? options = null)
            : base("kubernetes:pingcap.com/v1alpha1:TidbClusterAutoScaler", name, null, MakeResourceOptions(options, id))
        {
        }

        private static Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterAutoScalerArgs? MakeArgs(Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterAutoScalerArgs? args)
        {
            args ??= new Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterAutoScalerArgs();
            args.ApiVersion = "pingcap.com/v1alpha1";
            args.Kind = "TidbClusterAutoScaler";
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
        /// Get an existing TidbClusterAutoScaler resource's state with the given name, ID, and optional extra
        /// properties used to qualify the lookup.
        /// </summary>
        ///
        /// <param name="name">The unique name of the resulting resource.</param>
        /// <param name="id">The unique provider ID of the resource to lookup.</param>
        /// <param name="options">A bag of options that control this resource's behavior</param>
        public static TidbClusterAutoScaler Get(string name, Input<string> id, CustomResourceOptions? options = null)
        {
            return new TidbClusterAutoScaler(name, id, options);
        }
    }
}
namespace Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1
{

    public class TidbClusterAutoScalerArgs : Pulumi.ResourceArgs
    {
        [Input("apiVersion")]
        public Input<string>? ApiVersion { get; set; }

        [Input("kind")]
        public Input<string>? Kind { get; set; }

        [Input("metadata")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Meta.V1.ObjectMetaArgs>? Metadata { get; set; }

        [Input("spec")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterAutoScalerSpecArgs>? Spec { get; set; }

        [Input("status")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterAutoScalerStatusArgs>? Status { get; set; }

        public TidbClusterAutoScalerArgs()
        {
        }
    }
}
