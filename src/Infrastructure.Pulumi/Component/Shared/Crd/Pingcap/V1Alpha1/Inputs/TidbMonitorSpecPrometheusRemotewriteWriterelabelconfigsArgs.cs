// *** WARNING: this file was generated by crd2pulumi. ***
// *** Do not edit by hand unless you're certain you know what you are doing! ***

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading.Tasks;
using Pulumi.Serialization;

namespace Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1
{

    public class TidbMonitorSpecPrometheusRemoteWriteWriteRelabelConfigsArgs : global::Pulumi.ResourceArgs
    {
        [Input("action")]
        public Input<string>? Action { get; set; }

        [Input("modulus")]
        public Input<int>? Modulus { get; set; }

        [Input("regex")]
        public Input<string>? Regex { get; set; }

        [Input("replacement")]
        public Input<string>? Replacement { get; set; }

        [Input("separator")]
        public Input<string>? Separator { get; set; }

        [Input("sourceLabels")]
        private InputList<string>? _sourceLabels;
        public InputList<string> SourceLabels
        {
            get => _sourceLabels ?? (_sourceLabels = new InputList<string>());
            set => _sourceLabels = value;
        }

        [Input("targetLabel")]
        public Input<string>? TargetLabel { get; set; }

        public TidbMonitorSpecPrometheusRemoteWriteWriteRelabelConfigsArgs()
        {
        }
        public static new TidbMonitorSpecPrometheusRemoteWriteWriteRelabelConfigsArgs Empty => new TidbMonitorSpecPrometheusRemoteWriteWriteRelabelConfigsArgs();
    }
}
