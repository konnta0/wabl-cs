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
    public sealed class RestoreSpecPitrFullBackupStorageProviderLocalVolumeSecret
    {
        public readonly int DefaultMode;
        public readonly ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.RestoreSpecPitrFullBackupStorageProviderLocalVolumeSecretItems> Items;
        public readonly bool Optional;
        public readonly string SecretName;

        [OutputConstructor]
        private RestoreSpecPitrFullBackupStorageProviderLocalVolumeSecret(
            int defaultMode,

            ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.RestoreSpecPitrFullBackupStorageProviderLocalVolumeSecretItems> items,

            bool optional,

            string secretName)
        {
            DefaultMode = defaultMode;
            Items = items;
            Optional = optional;
            SecretName = secretName;
        }
    }
}
