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
    public sealed class TidbClusterSpecDiscoveryPodSecurityContextSeccompProfile
    {
        public readonly string LocalhostProfile;
        public readonly string Type;

        [OutputConstructor]
        private TidbClusterSpecDiscoveryPodSecurityContextSeccompProfile(
            string localhostProfile,

            string type)
        {
            LocalhostProfile = localhostProfile;
            Type = type;
        }
    }
}
