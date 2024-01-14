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
    public sealed class TidbClusterSpecTikvInitContainersPorts
    {
        public readonly int ContainerPort;
        public readonly string HostIP;
        public readonly int HostPort;
        public readonly string Name;
        public readonly string Protocol;

        [OutputConstructor]
        private TidbClusterSpecTikvInitContainersPorts(
            int containerPort,

            string hostIP,

            int hostPort,

            string name,

            string protocol)
        {
            ContainerPort = containerPort;
            HostIP = hostIP;
            HostPort = hostPort;
            Name = name;
            Protocol = protocol;
        }
    }
}
