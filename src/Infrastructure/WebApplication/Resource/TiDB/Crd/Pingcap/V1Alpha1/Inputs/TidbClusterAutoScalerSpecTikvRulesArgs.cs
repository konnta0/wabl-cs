// *** WARNING: this file was generated by crd2pulumi. ***
// *** Do not edit by hand unless you're certain you know what you are doing! ***

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading.Tasks;
using Pulumi.Serialization;

namespace Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1
{

    public class TidbClusterAutoScalerSpecTikvRulesArgs : Pulumi.ResourceArgs
    {
        [Input("max_threshold", required: true)]
        public Input<double> Max_threshold { get; set; } = null!;

        [Input("min_threshold")]
        public Input<double>? Min_threshold { get; set; }

        [Input("resource_types")]
        private InputList<string>? _resource_types;
        public InputList<string> Resource_types
        {
            get => _resource_types ?? (_resource_types = new InputList<string>());
            set => _resource_types = value;
        }

        public TidbClusterAutoScalerSpecTikvRulesArgs()
        {
        }
    }
}
