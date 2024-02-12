// *** WARNING: this file was generated by crd2pulumi. ***
// *** Do not edit by hand unless you're certain you know what you are doing! ***

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading.Tasks;
using Pulumi.Serialization;

namespace Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1
{

    public class TidbClusterStatusTiproxyConditionsArgs : global::Pulumi.ResourceArgs
    {
        [Input("lastTransitionTime", required: true)]
        public Input<string> LastTransitionTime { get; set; } = null!;

        [Input("message", required: true)]
        public Input<string> Message { get; set; } = null!;

        [Input("observedGeneration")]
        public Input<int>? ObservedGeneration { get; set; }

        [Input("reason", required: true)]
        public Input<string> Reason { get; set; } = null!;

        [Input("status", required: true)]
        public Input<string> Status { get; set; } = null!;

        [Input("type", required: true)]
        public Input<string> Type { get; set; } = null!;

        public TidbClusterStatusTiproxyConditionsArgs()
        {
        }
        public static new TidbClusterStatusTiproxyConditionsArgs Empty => new TidbClusterStatusTiproxyConditionsArgs();
    }
}