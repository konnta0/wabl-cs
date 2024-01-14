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
    public sealed class TidbClusterStatusTiproxyVolumes
    {
        public readonly int BoundCount;
        public readonly Union<int, string> CurrentCapacity;
        public readonly int CurrentCount;
        public readonly string CurrentStorageClass;
        public readonly Union<int, string> ModifiedCapacity;
        public readonly int ModifiedCount;
        public readonly string ModifiedStorageClass;
        public readonly string Name;
        public readonly Union<int, string> ResizedCapacity;
        public readonly int ResizedCount;

        [OutputConstructor]
        private TidbClusterStatusTiproxyVolumes(
            int boundCount,

            Union<int, string> currentCapacity,

            int currentCount,

            string currentStorageClass,

            Union<int, string> modifiedCapacity,

            int modifiedCount,

            string modifiedStorageClass,

            string name,

            Union<int, string> resizedCapacity,

            int resizedCount)
        {
            BoundCount = boundCount;
            CurrentCapacity = currentCapacity;
            CurrentCount = currentCount;
            CurrentStorageClass = currentStorageClass;
            ModifiedCapacity = modifiedCapacity;
            ModifiedCount = modifiedCount;
            ModifiedStorageClass = modifiedStorageClass;
            Name = name;
            ResizedCapacity = resizedCapacity;
            ResizedCount = resizedCount;
        }
    }
}
