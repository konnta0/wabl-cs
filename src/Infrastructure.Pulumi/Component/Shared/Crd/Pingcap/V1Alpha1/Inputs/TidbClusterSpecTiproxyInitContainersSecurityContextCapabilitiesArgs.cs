// *** WARNING: this file was generated by crd2pulumi. ***
// *** Do not edit by hand unless you're certain you know what you are doing! ***

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading.Tasks;
using Pulumi.Serialization;

namespace Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1
{

    public class TidbClusterSpecTiproxyInitContainersSecurityContextCapabilitiesArgs : global::Pulumi.ResourceArgs
    {
        [Input("add")]
        private InputList<string>? _add;
        public InputList<string> Add
        {
            get => _add ?? (_add = new InputList<string>());
            set => _add = value;
        }

        [Input("drop")]
        private InputList<string>? _drop;
        public InputList<string> Drop
        {
            get => _drop ?? (_drop = new InputList<string>());
            set => _drop = value;
        }

        public TidbClusterSpecTiproxyInitContainersSecurityContextCapabilitiesArgs()
        {
        }
        public static new TidbClusterSpecTiproxyInitContainersSecurityContextCapabilitiesArgs Empty => new TidbClusterSpecTiproxyInitContainersSecurityContextCapabilitiesArgs();
    }
}