// *** WARNING: this file was generated by crd2pulumi. ***
// *** Do not edit by hand unless you're certain you know what you are doing! ***

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading.Tasks;
using Pulumi.Serialization;

namespace Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1
{

    public class TidbDashboardSpecAdditionalVolumesProjectedSourcesServiceAccountTokenArgs : global::Pulumi.ResourceArgs
    {
        [Input("audience")]
        public Input<string>? Audience { get; set; }

        [Input("expirationSeconds")]
        public Input<int>? ExpirationSeconds { get; set; }

        [Input("path", required: true)]
        public Input<string> Path { get; set; } = null!;

        public TidbDashboardSpecAdditionalVolumesProjectedSourcesServiceAccountTokenArgs()
        {
        }
        public static new TidbDashboardSpecAdditionalVolumesProjectedSourcesServiceAccountTokenArgs Empty => new TidbDashboardSpecAdditionalVolumesProjectedSourcesServiceAccountTokenArgs();
    }
}
