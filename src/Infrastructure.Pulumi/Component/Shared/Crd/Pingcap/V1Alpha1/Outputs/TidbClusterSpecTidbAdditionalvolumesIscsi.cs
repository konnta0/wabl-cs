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
    public sealed class TidbClusterSpecTidbAdditionalVolumesIscsi
    {
        public readonly bool ChapAuthDiscovery;
        public readonly bool ChapAuthSession;
        public readonly string FsType;
        public readonly string InitiatorName;
        public readonly string Iqn;
        public readonly string IscsiInterface;
        public readonly int Lun;
        public readonly ImmutableArray<string> Portals;
        public readonly bool ReadOnly;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecTidbAdditionalVolumesIscsiSecretRef SecretRef;
        public readonly string TargetPortal;

        [OutputConstructor]
        private TidbClusterSpecTidbAdditionalVolumesIscsi(
            bool chapAuthDiscovery,

            bool chapAuthSession,

            string fsType,

            string initiatorName,

            string iqn,

            string iscsiInterface,

            int lun,

            ImmutableArray<string> portals,

            bool readOnly,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecTidbAdditionalVolumesIscsiSecretRef secretRef,

            string targetPortal)
        {
            ChapAuthDiscovery = chapAuthDiscovery;
            ChapAuthSession = chapAuthSession;
            FsType = fsType;
            InitiatorName = initiatorName;
            Iqn = iqn;
            IscsiInterface = iscsiInterface;
            Lun = lun;
            Portals = portals;
            ReadOnly = readOnly;
            SecretRef = secretRef;
            TargetPortal = targetPortal;
        }
    }
}
