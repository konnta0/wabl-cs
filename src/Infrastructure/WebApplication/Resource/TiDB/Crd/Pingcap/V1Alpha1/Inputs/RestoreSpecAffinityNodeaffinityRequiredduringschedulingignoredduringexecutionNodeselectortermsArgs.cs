// *** WARNING: this file was generated by crd2pulumi. ***
// *** Do not edit by hand unless you're certain you know what you are doing! ***

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading.Tasks;
using Pulumi.Serialization;

namespace Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1
{

    public class RestoreSpecAffinityNodeaffinityRequiredduringschedulingignoredduringexecutionNodeselectortermsArgs : Pulumi.ResourceArgs
    {
        [Input("matchExpressions")]
        private InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.RestoreSpecAffinityNodeaffinityRequiredduringschedulingignoredduringexecutionNodeselectortermsMatchexpressionsArgs>? _matchExpressions;
        public InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.RestoreSpecAffinityNodeaffinityRequiredduringschedulingignoredduringexecutionNodeselectortermsMatchexpressionsArgs> MatchExpressions
        {
            get => _matchExpressions ?? (_matchExpressions = new InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.RestoreSpecAffinityNodeaffinityRequiredduringschedulingignoredduringexecutionNodeselectortermsMatchexpressionsArgs>());
            set => _matchExpressions = value;
        }

        [Input("matchFields")]
        private InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.RestoreSpecAffinityNodeaffinityRequiredduringschedulingignoredduringexecutionNodeselectortermsMatchfieldsArgs>? _matchFields;
        public InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.RestoreSpecAffinityNodeaffinityRequiredduringschedulingignoredduringexecutionNodeselectortermsMatchfieldsArgs> MatchFields
        {
            get => _matchFields ?? (_matchFields = new InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.RestoreSpecAffinityNodeaffinityRequiredduringschedulingignoredduringexecutionNodeselectortermsMatchfieldsArgs>());
            set => _matchFields = value;
        }

        public RestoreSpecAffinityNodeaffinityRequiredduringschedulingignoredduringexecutionNodeselectortermsArgs()
        {
        }
    }
}
