// *** WARNING: this file was generated by crd2pulumi. ***
// *** Do not edit by hand unless you're certain you know what you are doing! ***

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading.Tasks;
using Pulumi.Serialization;

namespace Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1
{

    public class TidbDashboardSpecAdditionalContainersVolumeDevicesArgs : global::Pulumi.ResourceArgs
    {
        [Input("devicePath", required: true)]
        public Input<string> DevicePath { get; set; } = null!;

        [Input("name", required: true)]
        public Input<string> Name { get; set; } = null!;

        public TidbDashboardSpecAdditionalContainersVolumeDevicesArgs()
        {
        }
        public static new TidbDashboardSpecAdditionalContainersVolumeDevicesArgs Empty => new TidbDashboardSpecAdditionalContainersVolumeDevicesArgs();
    }
}
