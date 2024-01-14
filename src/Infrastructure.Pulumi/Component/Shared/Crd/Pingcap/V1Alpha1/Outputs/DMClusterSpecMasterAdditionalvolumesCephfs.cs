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
    public sealed class DMClusterSpecMasterAdditionalVolumesCephfs
    {
        public readonly ImmutableArray<string> Monitors;
        public readonly string Path;
        public readonly bool ReadOnly;
        public readonly string SecretFile;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.DMClusterSpecMasterAdditionalVolumesCephfsSecretRef SecretRef;
        public readonly string User;

        [OutputConstructor]
        private DMClusterSpecMasterAdditionalVolumesCephfs(
            ImmutableArray<string> monitors,

            string path,

            bool readOnly,

            string secretFile,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.DMClusterSpecMasterAdditionalVolumesCephfsSecretRef secretRef,

            string user)
        {
            Monitors = monitors;
            Path = path;
            ReadOnly = readOnly;
            SecretFile = secretFile;
            SecretRef = secretRef;
            User = user;
        }
    }
}
