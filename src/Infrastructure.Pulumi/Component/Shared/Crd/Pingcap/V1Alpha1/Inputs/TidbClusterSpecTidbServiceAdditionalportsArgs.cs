// *** WARNING: this file was generated by crd2pulumi. ***
// *** Do not edit by hand unless you're certain you know what you are doing! ***

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading.Tasks;
using Pulumi.Serialization;

namespace Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1
{

    public class TidbClusterSpecTidbServiceAdditionalportsArgs : Pulumi.ResourceArgs
    {
        [Input("appProtocol")]
        public Input<string>? AppProtocol { get; set; }

        [Input("name")]
        public Input<string>? Name { get; set; }

        [Input("nodePort")]
        public Input<int>? NodePort { get; set; }

        [Input("port", required: true)]
        public Input<int> Port { get; set; } = null!;

        [Input("protocol")]
        public Input<string>? Protocol { get; set; }

        [Input("targetPort")]
        public InputUnion<int, string>? TargetPort { get; set; }

        public TidbClusterSpecTidbServiceAdditionalportsArgs()
        {
            Protocol = "TCP";
        }
    }
}