// *** WARNING: this file was generated by crd2pulumi. ***
// *** Do not edit by hand unless you're certain you know what you are doing! ***

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading.Tasks;
using Pulumi.Serialization;

namespace Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1
{

    public class TidbClusterStatusPdFailureMembersArgs : global::Pulumi.ResourceArgs
    {
        [Input("createdAt")]
        public Input<string>? CreatedAt { get; set; }

        [Input("hostDown")]
        public Input<bool>? HostDown { get; set; }

        [Input("memberDeleted")]
        public Input<bool>? MemberDeleted { get; set; }

        [Input("memberID")]
        public Input<string>? MemberID { get; set; }

        [Input("podName")]
        public Input<string>? PodName { get; set; }

        [Input("pvcUID")]
        public Input<string>? PvcUID { get; set; }

        [Input("pvcUIDSet")]
        private InputMap<ImmutableDictionary<string, object>>? _pvcUIDSet;
        public InputMap<ImmutableDictionary<string, object>> PvcUIDSet
        {
            get => _pvcUIDSet ?? (_pvcUIDSet = new InputMap<ImmutableDictionary<string, object>>());
            set => _pvcUIDSet = value;
        }

        public TidbClusterStatusPdFailureMembersArgs()
        {
        }
        public static new TidbClusterStatusPdFailureMembersArgs Empty => new TidbClusterStatusPdFailureMembersArgs();
    }
}
