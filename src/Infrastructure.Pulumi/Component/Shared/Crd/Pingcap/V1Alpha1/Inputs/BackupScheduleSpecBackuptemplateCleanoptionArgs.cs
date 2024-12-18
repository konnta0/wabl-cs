// *** WARNING: this file was generated by crd2pulumi. ***
// *** Do not edit by hand unless you're certain you know what you are doing! ***

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading.Tasks;
using Pulumi.Serialization;

namespace Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1
{

    public class BackupScheduleSpecBackupTemplateCleanOptionArgs : global::Pulumi.ResourceArgs
    {
        [Input("backoffEnabled")]
        public Input<bool>? BackoffEnabled { get; set; }

        [Input("batchConcurrency")]
        public Input<int>? BatchConcurrency { get; set; }

        [Input("disableBatchConcurrency")]
        public Input<bool>? DisableBatchConcurrency { get; set; }

        [Input("pageSize")]
        public Input<int>? PageSize { get; set; }

        [Input("retryCount")]
        public Input<int>? RetryCount { get; set; }

        [Input("routineConcurrency")]
        public Input<int>? RoutineConcurrency { get; set; }

        public BackupScheduleSpecBackupTemplateCleanOptionArgs()
        {
            RetryCount = 5;
        }
        public static new BackupScheduleSpecBackupTemplateCleanOptionArgs Empty => new BackupScheduleSpecBackupTemplateCleanOptionArgs();
    }
}
