// *** WARNING: this file was generated by crd2pulumi. ***
// *** Do not edit by hand unless you're certain you know what you are doing! ***

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading.Tasks;
using Pulumi.Serialization;

namespace Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1
{

    public class DMClusterSpecMasterInitcontainersEnvValuefromSecretkeyrefArgs : Pulumi.ResourceArgs
    {
        [Input("key", required: true)]
        public Input<string> Key { get; set; } = null!;

        [Input("name")]
        public Input<string>? Name { get; set; }

        [Input("optional")]
        public Input<bool>? Optional { get; set; }

        public DMClusterSpecMasterInitcontainersEnvValuefromSecretkeyrefArgs()
        {
        }
    }
}
