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
    public sealed class TidbClusterStatusTiproxyProxy
    {
        public readonly int MaxConnections;
        public readonly string ProxyProtocol;
        public readonly bool TcpKeepAlive;

        [OutputConstructor]
        private TidbClusterStatusTiproxyProxy(
            int maxConnections,

            string proxyProtocol,

            bool tcpKeepAlive)
        {
            MaxConnections = maxConnections;
            ProxyProtocol = proxyProtocol;
            TcpKeepAlive = tcpKeepAlive;
        }
    }
}
