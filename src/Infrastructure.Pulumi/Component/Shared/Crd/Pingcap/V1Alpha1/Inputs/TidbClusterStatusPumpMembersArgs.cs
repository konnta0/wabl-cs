// *** WARNING: this file was generated by crd2pulumi. ***
// *** Do not edit by hand unless you're certain you know what you are doing! ***

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading.Tasks;
using Pulumi.Serialization;

namespace Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1
{

    public class TidbClusterStatusPumpMembersArgs : global::Pulumi.ResourceArgs
    {
        [Input("host", required: true)]
        public Input<string> Host { get; set; } = null!;

        [Input("nodeId", required: true)]
        public Input<string> NodeId { get; set; } = null!;

        [Input("state", required: true)]
        public Input<string> State { get; set; } = null!;

        public TidbClusterStatusPumpMembersArgs()
        {
        }
        public static new TidbClusterStatusPumpMembersArgs Empty => new TidbClusterStatusPumpMembersArgs();
    }
}
