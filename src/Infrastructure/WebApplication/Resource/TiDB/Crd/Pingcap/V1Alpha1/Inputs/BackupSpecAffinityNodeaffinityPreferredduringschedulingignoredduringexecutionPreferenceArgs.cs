// *** WARNING: this file was generated by crd2pulumi. ***
// *** Do not edit by hand unless you're certain you know what you are doing! ***

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading.Tasks;
using Pulumi.Serialization;

namespace Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1
{

    public class BackupSpecAffinityNodeaffinityPreferredduringschedulingignoredduringexecutionPreferenceArgs : Pulumi.ResourceArgs
    {
        [Input("matchExpressions")]
        private InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.BackupSpecAffinityNodeaffinityPreferredduringschedulingignoredduringexecutionPreferenceMatchexpressionsArgs>? _matchExpressions;
        public InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.BackupSpecAffinityNodeaffinityPreferredduringschedulingignoredduringexecutionPreferenceMatchexpressionsArgs> MatchExpressions
        {
            get => _matchExpressions ?? (_matchExpressions = new InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.BackupSpecAffinityNodeaffinityPreferredduringschedulingignoredduringexecutionPreferenceMatchexpressionsArgs>());
            set => _matchExpressions = value;
        }

        [Input("matchFields")]
        private InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.BackupSpecAffinityNodeaffinityPreferredduringschedulingignoredduringexecutionPreferenceMatchfieldsArgs>? _matchFields;
        public InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.BackupSpecAffinityNodeaffinityPreferredduringschedulingignoredduringexecutionPreferenceMatchfieldsArgs> MatchFields
        {
            get => _matchFields ?? (_matchFields = new InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.BackupSpecAffinityNodeaffinityPreferredduringschedulingignoredduringexecutionPreferenceMatchfieldsArgs>());
            set => _matchFields = value;
        }

        public BackupSpecAffinityNodeaffinityPreferredduringschedulingignoredduringexecutionPreferenceArgs()
        {
        }
    }
}
