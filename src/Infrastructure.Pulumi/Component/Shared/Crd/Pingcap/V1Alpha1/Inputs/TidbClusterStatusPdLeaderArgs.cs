// *** WARNING: this file was generated by crd2pulumi. ***
// *** Do not edit by hand unless you're certain you know what you are doing! ***

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading.Tasks;
using Pulumi.Serialization;

namespace Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1
{

    public class TidbClusterStatusPdLeaderArgs : global::Pulumi.ResourceArgs
    {
        [Input("clientURL", required: true)]
        public Input<string> ClientURL { get; set; } = null!;

        [Input("health", required: true)]
        public Input<bool> Health { get; set; } = null!;

        [Input("id", required: true)]
        public Input<string> Id { get; set; } = null!;

        [Input("lastTransitionTime")]
        public Input<string>? LastTransitionTime { get; set; }

        [Input("name", required: true)]
        public Input<string> Name { get; set; } = null!;

        public TidbClusterStatusPdLeaderArgs()
        {
        }
        public static new TidbClusterStatusPdLeaderArgs Empty => new TidbClusterStatusPdLeaderArgs();
    }
}
