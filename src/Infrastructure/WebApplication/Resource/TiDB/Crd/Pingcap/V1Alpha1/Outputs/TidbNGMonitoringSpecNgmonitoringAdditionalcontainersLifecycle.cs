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
    public sealed class TidbNGMonitoringSpecNgmonitoringAdditionalcontainersLifecycle
    {
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbNGMonitoringSpecNgmonitoringAdditionalcontainersLifecyclePoststart PostStart;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbNGMonitoringSpecNgmonitoringAdditionalcontainersLifecyclePrestop PreStop;

        [OutputConstructor]
        private TidbNGMonitoringSpecNgmonitoringAdditionalcontainersLifecycle(
            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbNGMonitoringSpecNgmonitoringAdditionalcontainersLifecyclePoststart postStart,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbNGMonitoringSpecNgmonitoringAdditionalcontainersLifecyclePrestop preStop)
        {
            PostStart = postStart;
            PreStop = preStop;
        }
    }
}
