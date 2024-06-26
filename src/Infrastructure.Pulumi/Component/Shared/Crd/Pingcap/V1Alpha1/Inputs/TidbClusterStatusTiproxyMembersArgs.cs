// *** WARNING: this file was generated by crd2pulumi. ***
// *** Do not edit by hand unless you're certain you know what you are doing! ***

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading.Tasks;
using Pulumi.Serialization;

namespace Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1
{

    public class TidbClusterStatusTiproxyMembersArgs : global::Pulumi.ResourceArgs
    {
        [Input("health", required: true)]
        public Input<bool> Health { get; set; } = null!;

        [Input("info")]
        public Input<string>? Info { get; set; }

        [Input("lastTransitionTime")]
        public Input<string>? LastTransitionTime { get; set; }

        [Input("name", required: true)]
        public Input<string> Name { get; set; } = null!;

        public TidbClusterStatusTiproxyMembersArgs()
        {
        }
        public static new TidbClusterStatusTiproxyMembersArgs Empty => new TidbClusterStatusTiproxyMembersArgs();
    }
}
