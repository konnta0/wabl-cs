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
    public sealed class TidbMonitorSpecAdditionalContainersReadinessProbeTcpSocket
    {
        public readonly string Host;
        public readonly Union<int, string> Port;

        [OutputConstructor]
        private TidbMonitorSpecAdditionalContainersReadinessProbeTcpSocket(
            string host,

            Union<int, string> port)
        {
            Host = host;
            Port = port;
        }
    }
}
