// *** WARNING: this file was generated by crd2pulumi. ***
// *** Do not edit by hand unless you're certain you know what you are doing! ***

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading.Tasks;
using Pulumi.Serialization;

namespace Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1
{

    public class DMClusterSpecMasterAdditionalContainersLifecyclePostStartExecArgs : global::Pulumi.ResourceArgs
    {
        [Input("command")]
        private InputList<string>? _command;
        public InputList<string> Command
        {
            get => _command ?? (_command = new InputList<string>());
            set => _command = value;
        }

        public DMClusterSpecMasterAdditionalContainersLifecyclePostStartExecArgs()
        {
        }
        public static new DMClusterSpecMasterAdditionalContainersLifecyclePostStartExecArgs Empty => new DMClusterSpecMasterAdditionalContainersLifecyclePostStartExecArgs();
    }
}
