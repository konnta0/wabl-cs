// *** WARNING: this file was generated by crd2pulumi. ***
// *** Do not edit by hand unless you're certain you know what you are doing! ***

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading.Tasks;
using Pulumi.Serialization;

namespace Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1
{

    public class BackupScheduleSpecLogBackupTemplateDumplingArgs : global::Pulumi.ResourceArgs
    {
        [Input("options")]
        private InputList<string>? _options;
        public InputList<string> Options
        {
            get => _options ?? (_options = new InputList<string>());
            set => _options = value;
        }

        [Input("tableFilter")]
        private InputList<string>? _tableFilter;
        public InputList<string> TableFilter
        {
            get => _tableFilter ?? (_tableFilter = new InputList<string>());
            set => _tableFilter = value;
        }

        public BackupScheduleSpecLogBackupTemplateDumplingArgs()
        {
        }
        public static new BackupScheduleSpecLogBackupTemplateDumplingArgs Empty => new BackupScheduleSpecLogBackupTemplateDumplingArgs();
    }
}
