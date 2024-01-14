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
    public sealed class TidbClusterSpecPdAdditionalVolumesFc
    {
        public readonly string FsType;
        public readonly int Lun;
        public readonly bool ReadOnly;
        public readonly ImmutableArray<string> TargetWWNs;
        public readonly ImmutableArray<string> Wwids;

        [OutputConstructor]
        private TidbClusterSpecPdAdditionalVolumesFc(
            string fsType,

            int lun,

            bool readOnly,

            ImmutableArray<string> targetWWNs,

            ImmutableArray<string> wwids)
        {
            FsType = fsType;
            Lun = lun;
            ReadOnly = readOnly;
            TargetWWNs = targetWWNs;
            Wwids = wwids;
        }
    }
}
