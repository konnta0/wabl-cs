// *** WARNING: this file was generated by crd2pulumi. ***
// *** Do not edit by hand unless you're certain you know what you are doing! ***

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading.Tasks;
using Pulumi.Serialization;

namespace Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1
{

    public class BackupScheduleSpecBackupTemplateFromArgs : global::Pulumi.ResourceArgs
    {
        [Input("host", required: true)]
        public Input<string> Host { get; set; } = null!;

        [Input("port")]
        public Input<int>? Port { get; set; }

        [Input("secretName", required: true)]
        public Input<string> SecretName { get; set; } = null!;

        [Input("tlsClientSecretName")]
        public Input<string>? TlsClientSecretName { get; set; }

        [Input("user")]
        public Input<string>? User { get; set; }

        public BackupScheduleSpecBackupTemplateFromArgs()
        {
        }
        public static new BackupScheduleSpecBackupTemplateFromArgs Empty => new BackupScheduleSpecBackupTemplateFromArgs();
    }
}
