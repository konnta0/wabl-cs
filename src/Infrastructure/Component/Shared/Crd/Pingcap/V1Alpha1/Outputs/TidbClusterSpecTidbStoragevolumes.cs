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
    public sealed class TidbClusterSpecTidbStoragevolumes
    {
        public readonly string MountPath;
        public readonly string Name;
        public readonly string StorageClassName;
        public readonly string StorageSize;

        [OutputConstructor]
        private TidbClusterSpecTidbStoragevolumes(
            string mountPath,

            string name,

            string storageClassName,

            string storageSize)
        {
            MountPath = mountPath;
            Name = name;
            StorageClassName = storageClassName;
            StorageSize = storageSize;
        }
    }
}