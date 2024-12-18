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
    public sealed class TidbClusterSpecDiscoveryAdditionalVolumesFlexVolume
    {
        public readonly string Driver;
        public readonly string FsType;
        public readonly ImmutableDictionary<string, string> Options;
        public readonly bool ReadOnly;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecDiscoveryAdditionalVolumesFlexVolumeSecretRef SecretRef;

        [OutputConstructor]
        private TidbClusterSpecDiscoveryAdditionalVolumesFlexVolume(
            string driver,

            string fsType,

            ImmutableDictionary<string, string> options,

            bool readOnly,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecDiscoveryAdditionalVolumesFlexVolumeSecretRef secretRef)
        {
            Driver = driver;
            FsType = fsType;
            Options = options;
            ReadOnly = readOnly;
            SecretRef = secretRef;
        }
    }
}
