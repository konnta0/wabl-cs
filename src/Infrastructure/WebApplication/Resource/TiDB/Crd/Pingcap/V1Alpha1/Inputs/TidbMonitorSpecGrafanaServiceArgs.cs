// *** WARNING: this file was generated by crd2pulumi. ***
// *** Do not edit by hand unless you're certain you know what you are doing! ***

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading.Tasks;
using Pulumi.Serialization;

namespace Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1
{

    public class TidbMonitorSpecGrafanaServiceArgs : Pulumi.ResourceArgs
    {
        [Input("annotations")]
        private InputMap<string>? _annotations;
        public InputMap<string> Annotations
        {
            get => _annotations ?? (_annotations = new InputMap<string>());
            set => _annotations = value;
        }

        [Input("clusterIP")]
        public Input<string>? ClusterIP { get; set; }

        [Input("labels")]
        private InputMap<string>? _labels;
        public InputMap<string> Labels
        {
            get => _labels ?? (_labels = new InputMap<string>());
            set => _labels = value;
        }

        [Input("loadBalancerIP")]
        public Input<string>? LoadBalancerIP { get; set; }

        [Input("loadBalancerSourceRanges")]
        private InputList<string>? _loadBalancerSourceRanges;
        public InputList<string> LoadBalancerSourceRanges
        {
            get => _loadBalancerSourceRanges ?? (_loadBalancerSourceRanges = new InputList<string>());
            set => _loadBalancerSourceRanges = value;
        }

        [Input("port")]
        public Input<int>? Port { get; set; }

        [Input("portName")]
        public Input<string>? PortName { get; set; }

        [Input("type")]
        public Input<string>? Type { get; set; }

        public TidbMonitorSpecGrafanaServiceArgs()
        {
        }
    }
}
