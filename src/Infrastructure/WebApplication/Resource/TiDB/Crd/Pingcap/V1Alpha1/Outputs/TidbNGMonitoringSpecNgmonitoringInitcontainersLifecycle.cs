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
    public sealed class TidbNGMonitoringSpecNgmonitoringInitcontainersLifecycle
    {
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbNGMonitoringSpecNgmonitoringInitcontainersLifecyclePoststart PostStart;
        public readonly Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbNGMonitoringSpecNgmonitoringInitcontainersLifecyclePrestop PreStop;

        [OutputConstructor]
        private TidbNGMonitoringSpecNgmonitoringInitcontainersLifecycle(
            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbNGMonitoringSpecNgmonitoringInitcontainersLifecyclePoststart postStart,

            Pulumi.Kubernetes.Types.Outputs.Pingcap.V1Alpha1.TidbNGMonitoringSpecNgmonitoringInitcontainersLifecyclePrestop preStop)
        {
            PostStart = postStart;
            PreStop = preStop;
        }
    }
}
