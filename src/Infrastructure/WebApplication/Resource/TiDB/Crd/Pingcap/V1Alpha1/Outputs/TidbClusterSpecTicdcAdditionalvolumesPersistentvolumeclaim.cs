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
    public sealed class TidbClusterSpecTicdcAdditionalvolumesPersistentvolumeclaim
    {
        public readonly string ClaimName;
        public readonly bool ReadOnly;

        [OutputConstructor]
        private TidbClusterSpecTicdcAdditionalvolumesPersistentvolumeclaim(
            string claimName,

            bool readOnly)
        {
            ClaimName = claimName;
            ReadOnly = readOnly;
        }
    }
}
