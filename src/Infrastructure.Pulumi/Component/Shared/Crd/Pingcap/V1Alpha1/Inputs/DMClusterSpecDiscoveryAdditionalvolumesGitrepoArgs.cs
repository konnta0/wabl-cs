// *** WARNING: this file was generated by crd2pulumi. ***
// *** Do not edit by hand unless you're certain you know what you are doing! ***

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading.Tasks;
using Pulumi.Serialization;

namespace Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1
{

    public class DMClusterSpecDiscoveryAdditionalVolumesGitRepoArgs : global::Pulumi.ResourceArgs
    {
        [Input("directory")]
        public Input<string>? Directory { get; set; }

        [Input("repository", required: true)]
        public Input<string> Repository { get; set; } = null!;

        [Input("revision")]
        public Input<string>? Revision { get; set; }

        public DMClusterSpecDiscoveryAdditionalVolumesGitRepoArgs()
        {
        }
        public static new DMClusterSpecDiscoveryAdditionalVolumesGitRepoArgs Empty => new DMClusterSpecDiscoveryAdditionalVolumesGitRepoArgs();
    }
}
