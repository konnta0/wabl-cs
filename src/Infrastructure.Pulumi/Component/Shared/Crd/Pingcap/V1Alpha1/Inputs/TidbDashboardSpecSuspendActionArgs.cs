// *** WARNING: this file was generated by crd2pulumi. ***
// *** Do not edit by hand unless you're certain you know what you are doing! ***

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading.Tasks;
using Pulumi.Serialization;

namespace Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1
{

    public class TidbDashboardSpecSuspendActionArgs : global::Pulumi.ResourceArgs
    {
        [Input("suspendStatefulSet")]
        public Input<bool>? SuspendStatefulSet { get; set; }

        public TidbDashboardSpecSuspendActionArgs()
        {
        }
        public static new TidbDashboardSpecSuspendActionArgs Empty => new TidbDashboardSpecSuspendActionArgs();
    }
}