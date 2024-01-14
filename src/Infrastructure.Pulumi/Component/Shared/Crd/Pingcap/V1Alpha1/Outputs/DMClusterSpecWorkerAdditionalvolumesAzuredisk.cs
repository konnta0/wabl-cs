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
    public sealed class DMClusterSpecWorkerAdditionalVolumesAzureDisk
    {
        public readonly string CachingMode;
        public readonly string DiskName;
        public readonly string DiskURI;
        public readonly string FsType;
        public readonly string Kind;
        public readonly bool ReadOnly;

        [OutputConstructor]
        private DMClusterSpecWorkerAdditionalVolumesAzureDisk(
            string cachingMode,

            string diskName,

            string diskURI,

            string fsType,

            string kind,

            bool readOnly)
        {
            CachingMode = cachingMode;
            DiskName = diskName;
            DiskURI = diskURI;
            FsType = fsType;
            Kind = kind;
            ReadOnly = readOnly;
        }
    }
}
