// *** WARNING: this file was generated by crd2pulumi. ***
// *** Do not edit by hand unless you're certain you know what you are doing! ***

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading.Tasks;
using Pulumi.Serialization;

namespace Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1
{

    public class TidbClusterSpecTiflashInitContainersResourcesArgs : global::Pulumi.ResourceArgs
    {
        [Input("limits")]
        private InputMap<Union<int, string>>? _limits;
        public InputMap<Union<int, string>> Limits
        {
            get => _limits ?? (_limits = new InputMap<Union<int, string>>());
            set => _limits = value;
        }

        [Input("requests")]
        private InputMap<Union<int, string>>? _requests;
        public InputMap<Union<int, string>> Requests
        {
            get => _requests ?? (_requests = new InputMap<Union<int, string>>());
            set => _requests = value;
        }

        public TidbClusterSpecTiflashInitContainersResourcesArgs()
        {
        }
        public static new TidbClusterSpecTiflashInitContainersResourcesArgs Empty => new TidbClusterSpecTiflashInitContainersResourcesArgs();
    }
}
