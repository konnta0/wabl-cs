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
    public sealed class TidbDashboardSpecAdditionalVolumesRbd
    {
        public readonly string FsType;
        public readonly string Image;
        public readonly string Keyring;
        public readonly ImmutableArray<string> Monitors;
        public readonly string Pool;
        public readonly bool ReadOnly;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbDashboardSpecAdditionalVolumesRbdSecretRef SecretRef;
        public readonly string User;

        [OutputConstructor]
        private TidbDashboardSpecAdditionalVolumesRbd(
            string fsType,

            string image,

            string keyring,

            ImmutableArray<string> monitors,

            string pool,

            bool readOnly,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbDashboardSpecAdditionalVolumesRbdSecretRef secretRef,

            string user)
        {
            FsType = fsType;
            Image = image;
            Keyring = keyring;
            Monitors = monitors;
            Pool = pool;
            ReadOnly = readOnly;
            SecretRef = secretRef;
            User = user;
        }
    }
}