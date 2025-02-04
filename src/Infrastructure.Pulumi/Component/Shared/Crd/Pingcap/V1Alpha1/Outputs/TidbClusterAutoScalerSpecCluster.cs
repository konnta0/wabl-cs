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
    public sealed class TidbClusterAutoScalerSpecCluster
    {
        public readonly string ClusterDomain;
        public readonly string Name;
        public readonly string Namespace;

        [OutputConstructor]
        private TidbClusterAutoScalerSpecCluster(
            string clusterDomain,

            string name,

            string @namespace)
        {
            ClusterDomain = clusterDomain;
            Name = name;
            Namespace = @namespace;
        }
    }
}
