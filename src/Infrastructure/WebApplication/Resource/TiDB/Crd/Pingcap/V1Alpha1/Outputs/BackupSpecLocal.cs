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
    public sealed class BackupSpecLocal
    {
        public readonly string Prefix;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.BackupSpecLocalVolume Volume;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.BackupSpecLocalVolumemount VolumeMount;

        [OutputConstructor]
        private BackupSpecLocal(
            string prefix,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.BackupSpecLocalVolume volume,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.BackupSpecLocalVolumemount volumeMount)
        {
            Prefix = prefix;
            Volume = volume;
            VolumeMount = volumeMount;
        }
    }
}
