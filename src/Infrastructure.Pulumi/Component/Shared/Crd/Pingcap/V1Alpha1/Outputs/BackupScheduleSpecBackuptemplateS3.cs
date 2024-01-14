// *** WARNING: this file was generated by crd2pulumi. ***
// *** Do not edit by hand unless you're certain you know what you are doing! ***

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading.Tasks;
using Pulumi.Serialization;

namespace Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1
{

    [OutputType]
    public sealed class BackupScheduleSpecBackupTemplateS3
    {
        public readonly string Acl;
        public readonly string Bucket;
        public readonly string Endpoint;
        public readonly ImmutableArray<string> Options;
        public readonly string Path;
        public readonly string Prefix;
        public readonly string Provider;
        public readonly string Region;
        public readonly string SecretName;
        public readonly string Sse;
        public readonly string StorageClass;

        [OutputConstructor]
        private BackupScheduleSpecBackupTemplateS3(
            string acl,

            string bucket,

            string endpoint,

            ImmutableArray<string> options,

            string path,

            string prefix,

            string provider,

            string region,

            string secretName,

            string sse,

            string storageClass)
        {
            Acl = acl;
            Bucket = bucket;
            Endpoint = endpoint;
            Options = options;
            Path = path;
            Prefix = prefix;
            Provider = provider;
            Region = region;
            SecretName = secretName;
            Sse = sse;
            StorageClass = storageClass;
        }
    }
}
