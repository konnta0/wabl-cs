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
    public sealed class BackupSpecLocalVolumeCsi
    {
        public readonly string Driver;
        public readonly string FsType;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.BackupSpecLocalVolumeCsiNodepublishsecretref NodePublishSecretRef;
        public readonly bool ReadOnly;
        public readonly ImmutableDictionary<string, string> VolumeAttributes;

        [OutputConstructor]
        private BackupSpecLocalVolumeCsi(
            string driver,

            string fsType,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.BackupSpecLocalVolumeCsiNodepublishsecretref nodePublishSecretRef,

            bool readOnly,

            ImmutableDictionary<string, string> volumeAttributes)
        {
            Driver = driver;
            FsType = fsType;
            NodePublishSecretRef = nodePublishSecretRef;
            ReadOnly = readOnly;
            VolumeAttributes = volumeAttributes;
        }
    }
}