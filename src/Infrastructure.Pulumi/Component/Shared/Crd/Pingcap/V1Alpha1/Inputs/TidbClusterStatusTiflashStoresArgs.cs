// *** WARNING: this file was generated by crd2pulumi. ***
// *** Do not edit by hand unless you're certain you know what you are doing! ***

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading.Tasks;
using Pulumi.Serialization;

namespace Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1
{

    public class TidbClusterStatusTiflashStoresArgs : global::Pulumi.ResourceArgs
    {
        [Input("id", required: true)]
        public Input<string> Id { get; set; } = null!;

        [Input("ip", required: true)]
        public Input<string> Ip { get; set; } = null!;

        [Input("lastTransitionTime")]
        public Input<string>? LastTransitionTime { get; set; }

        [Input("leaderCount", required: true)]
        public Input<int> LeaderCount { get; set; } = null!;

        [Input("leaderCountBeforeUpgrade")]
        public Input<int>? LeaderCountBeforeUpgrade { get; set; }

        [Input("podName", required: true)]
        public Input<string> PodName { get; set; } = null!;

        [Input("state", required: true)]
        public Input<string> State { get; set; } = null!;

        public TidbClusterStatusTiflashStoresArgs()
        {
        }
        public static new TidbClusterStatusTiflashStoresArgs Empty => new TidbClusterStatusTiflashStoresArgs();
    }
}
