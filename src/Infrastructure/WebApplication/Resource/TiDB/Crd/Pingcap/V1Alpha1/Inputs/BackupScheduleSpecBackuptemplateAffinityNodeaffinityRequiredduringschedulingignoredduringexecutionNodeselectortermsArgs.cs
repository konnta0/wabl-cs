// *** WARNING: this file was generated by crd2pulumi. ***
// *** Do not edit by hand unless you're certain you know what you are doing! ***

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading.Tasks;
using Pulumi.Serialization;

namespace Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1
{

    public class BackupScheduleSpecBackuptemplateAffinityNodeaffinityRequiredduringschedulingignoredduringexecutionNodeselectortermsArgs : Pulumi.ResourceArgs
    {
        [Input("matchExpressions")]
        private InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.BackupScheduleSpecBackuptemplateAffinityNodeaffinityRequiredduringschedulingignoredduringexecutionNodeselectortermsMatchexpressionsArgs>? _matchExpressions;
        public InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.BackupScheduleSpecBackuptemplateAffinityNodeaffinityRequiredduringschedulingignoredduringexecutionNodeselectortermsMatchexpressionsArgs> MatchExpressions
        {
            get => _matchExpressions ?? (_matchExpressions = new InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.BackupScheduleSpecBackuptemplateAffinityNodeaffinityRequiredduringschedulingignoredduringexecutionNodeselectortermsMatchexpressionsArgs>());
            set => _matchExpressions = value;
        }

        [Input("matchFields")]
        private InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.BackupScheduleSpecBackuptemplateAffinityNodeaffinityRequiredduringschedulingignoredduringexecutionNodeselectortermsMatchfieldsArgs>? _matchFields;
        public InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.BackupScheduleSpecBackuptemplateAffinityNodeaffinityRequiredduringschedulingignoredduringexecutionNodeselectortermsMatchfieldsArgs> MatchFields
        {
            get => _matchFields ?? (_matchFields = new InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.BackupScheduleSpecBackuptemplateAffinityNodeaffinityRequiredduringschedulingignoredduringexecutionNodeselectortermsMatchfieldsArgs>());
            set => _matchFields = value;
        }

        public BackupScheduleSpecBackuptemplateAffinityNodeaffinityRequiredduringschedulingignoredduringexecutionNodeselectortermsArgs()
        {
        }
    }
}