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
    public sealed class TidbClusterSpecPdAdditionalvolumesCsi
    {
        public readonly string Driver;
        public readonly string FsType;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecPdAdditionalvolumesCsiNodepublishsecretref NodePublishSecretRef;
        public readonly bool ReadOnly;
        public readonly ImmutableDictionary<string, string> VolumeAttributes;

        [OutputConstructor]
        private TidbClusterSpecPdAdditionalvolumesCsi(
            string driver,

            string fsType,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecPdAdditionalvolumesCsiNodepublishsecretref nodePublishSecretRef,

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
