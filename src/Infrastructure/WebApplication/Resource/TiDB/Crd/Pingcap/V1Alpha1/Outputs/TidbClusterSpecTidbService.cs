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
    public sealed class TidbClusterSpecTidbService
    {
        public readonly ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecTidbServiceAdditionalports> AdditionalPorts;
        public readonly ImmutableDictionary<string, string> Annotations;
        public readonly string ClusterIP;
        public readonly bool ExposeStatus;
        public readonly string ExternalTrafficPolicy;
        public readonly ImmutableDictionary<string, string> Labels;
        public readonly string LoadBalancerIP;
        public readonly ImmutableArray<string> LoadBalancerSourceRanges;
        public readonly int MysqlNodePort;
        public readonly int Port;
        public readonly string PortName;
        public readonly int StatusNodePort;
        public readonly string Type;

        [OutputConstructor]
        private TidbClusterSpecTidbService(
            ImmutableArray<Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbClusterSpecTidbServiceAdditionalports> additionalPorts,

            ImmutableDictionary<string, string> annotations,

            string clusterIP,

            bool exposeStatus,

            string externalTrafficPolicy,

            ImmutableDictionary<string, string> labels,

            string loadBalancerIP,

            ImmutableArray<string> loadBalancerSourceRanges,

            int mysqlNodePort,

            int port,

            string portName,

            int statusNodePort,

            string type)
        {
            AdditionalPorts = additionalPorts;
            Annotations = annotations;
            ClusterIP = clusterIP;
            ExposeStatus = exposeStatus;
            ExternalTrafficPolicy = externalTrafficPolicy;
            Labels = labels;
            LoadBalancerIP = loadBalancerIP;
            LoadBalancerSourceRanges = loadBalancerSourceRanges;
            MysqlNodePort = mysqlNodePort;
            Port = port;
            PortName = portName;
            StatusNodePort = statusNodePort;
            Type = type;
        }
    }
}
