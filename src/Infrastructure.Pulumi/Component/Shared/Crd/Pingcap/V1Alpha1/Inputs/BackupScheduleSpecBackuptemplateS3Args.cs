// *** WARNING: this file was generated by crd2pulumi. ***
// *** Do not edit by hand unless you're certain you know what you are doing! ***

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading.Tasks;
using Pulumi.Serialization;

namespace Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1
{

    public class BackupScheduleSpecBackupTemplateS3Args : global::Pulumi.ResourceArgs
    {
        [Input("acl")]
        public Input<string>? Acl { get; set; }

        [Input("bucket")]
        public Input<string>? Bucket { get; set; }

        [Input("endpoint")]
        public Input<string>? Endpoint { get; set; }

        [Input("options")]
        private InputList<string>? _options;
        public InputList<string> Options
        {
            get => _options ?? (_options = new InputList<string>());
            set => _options = value;
        }

        [Input("path")]
        public Input<string>? Path { get; set; }

        [Input("prefix")]
        public Input<string>? Prefix { get; set; }

        [Input("provider", required: true)]
        public Input<string> Provider { get; set; } = null!;

        [Input("region")]
        public Input<string>? Region { get; set; }

        [Input("secretName")]
        public Input<string>? SecretName { get; set; }

        [Input("sse")]
        public Input<string>? Sse { get; set; }

        [Input("storageClass")]
        public Input<string>? StorageClass { get; set; }

        public BackupScheduleSpecBackupTemplateS3Args()
        {
        }
        public static new BackupScheduleSpecBackupTemplateS3Args Empty => new BackupScheduleSpecBackupTemplateS3Args();
    }
}
