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
    public sealed class TidbClusterSpecTikvAdditionalcontainersSecuritycontextSeccompprofile
    {
        public readonly string LocalhostProfile;
        public readonly string Type;

        [OutputConstructor]
        private TidbClusterSpecTikvAdditionalcontainersSecuritycontextSeccompprofile(
            string localhostProfile,

            string type)
        {
            LocalhostProfile = localhostProfile;
            Type = type;
        }
    }
}
