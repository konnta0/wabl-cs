// *** WARNING: this file was generated by crd2pulumi. ***
// *** Do not edit by hand unless you're certain you know what you are doing! ***

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading.Tasks;
using Pulumi.Serialization;

namespace Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1
{

    public class DMClusterSpecWorkerAdditionalContainersLifecycleArgs : global::Pulumi.ResourceArgs
    {
        [Input("postStart")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.DMClusterSpecWorkerAdditionalContainersLifecyclePostStartArgs>? PostStart { get; set; }

        [Input("preStop")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.DMClusterSpecWorkerAdditionalContainersLifecyclePreStopArgs>? PreStop { get; set; }

        public DMClusterSpecWorkerAdditionalContainersLifecycleArgs()
        {
        }
        public static new DMClusterSpecWorkerAdditionalContainersLifecycleArgs Empty => new DMClusterSpecWorkerAdditionalContainersLifecycleArgs();
    }
}
