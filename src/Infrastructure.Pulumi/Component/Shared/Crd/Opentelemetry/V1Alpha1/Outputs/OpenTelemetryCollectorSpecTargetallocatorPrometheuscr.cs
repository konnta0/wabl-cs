// *** WARNING: this file was generated by crd2pulumi. ***
// *** Do not edit by hand unless you're certain you know what you are doing! ***

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading.Tasks;
using Pulumi.Serialization;

namespace Pulumi.Kubernetes.Types.Outputs.Opentelemetry.V1Alpha1
{

    /// <summary>
    /// PrometheusCR defines the configuration for the retrieval of PrometheusOperator CRDs ( servicemonitor.monitoring.coreos.com/v1 and podmonitor.monitoring.coreos.com/v1 )  retrieval. All CR instances which the ServiceAccount has access to will be retrieved. This includes other namespaces.
    /// </summary>
    [OutputType]
    public sealed class OpenTelemetryCollectorSpecTargetallocatorPrometheuscr
    {
        /// <summary>
        /// Enabled indicates whether to use a PrometheusOperator custom resources as targets or not.
        /// </summary>
        public readonly bool Enabled;
        /// <summary>
        /// PodMonitors to be selected for target discovery. This is a map of {key,value} pairs. Each {key,value} in the map is going to exactly match a label in a PodMonitor's meta labels. The requirements are ANDed.
        /// </summary>
        public readonly ImmutableDictionary<string, string> PodMonitorSelector;
        /// <summary>
        /// ServiceMonitors to be selected for target discovery. This is a map of {key,value} pairs. Each {key,value} in the map is going to exactly match a label in a ServiceMonitor's meta labels. The requirements are ANDed.
        /// </summary>
        public readonly ImmutableDictionary<string, string> ServiceMonitorSelector;

        [OutputConstructor]
        private OpenTelemetryCollectorSpecTargetallocatorPrometheuscr(
            bool enabled,

            ImmutableDictionary<string, string> podMonitorSelector,

            ImmutableDictionary<string, string> serviceMonitorSelector)
        {
            Enabled = enabled;
            PodMonitorSelector = podMonitorSelector;
            ServiceMonitorSelector = serviceMonitorSelector;
        }
    }
}
