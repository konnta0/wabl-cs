// *** WARNING: this file was generated by crd2pulumi. ***
// *** Do not edit by hand unless you're certain you know what you are doing! ***

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading.Tasks;
using Pulumi.Serialization;

namespace Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1
{

    public class TidbClusterSpecTiflashAffinityNodeaffinityPreferredduringschedulingignoredduringexecutionPreferenceArgs : Pulumi.ResourceArgs
    {
        [Input("matchExpressions")]
        private InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterSpecTiflashAffinityNodeaffinityPreferredduringschedulingignoredduringexecutionPreferenceMatchexpressionsArgs>? _matchExpressions;
        public InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterSpecTiflashAffinityNodeaffinityPreferredduringschedulingignoredduringexecutionPreferenceMatchexpressionsArgs> MatchExpressions
        {
            get => _matchExpressions ?? (_matchExpressions = new InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterSpecTiflashAffinityNodeaffinityPreferredduringschedulingignoredduringexecutionPreferenceMatchexpressionsArgs>());
            set => _matchExpressions = value;
        }

        [Input("matchFields")]
        private InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterSpecTiflashAffinityNodeaffinityPreferredduringschedulingignoredduringexecutionPreferenceMatchfieldsArgs>? _matchFields;
        public InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterSpecTiflashAffinityNodeaffinityPreferredduringschedulingignoredduringexecutionPreferenceMatchfieldsArgs> MatchFields
        {
            get => _matchFields ?? (_matchFields = new InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbClusterSpecTiflashAffinityNodeaffinityPreferredduringschedulingignoredduringexecutionPreferenceMatchfieldsArgs>());
            set => _matchFields = value;
        }

        public TidbClusterSpecTiflashAffinityNodeaffinityPreferredduringschedulingignoredduringexecutionPreferenceArgs()
        {
        }
    }
}
