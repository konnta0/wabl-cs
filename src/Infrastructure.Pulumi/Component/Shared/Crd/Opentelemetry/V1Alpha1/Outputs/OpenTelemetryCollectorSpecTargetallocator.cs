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
    /// TargetAllocator indicates a value which determines whether to spawn a target allocation resource or not.
    /// </summary>
    [OutputType]
    public sealed class OpenTelemetryCollectorSpecTargetallocator
    {
        /// <summary>
        /// AllocationStrategy determines which strategy the target allocator should use for allocation. The current options are least-weighted and consistent-hashing. The default option is least-weighted
        /// </summary>
        public readonly string AllocationStrategy;
        /// <summary>
        /// Enabled indicates whether to use a target allocation mechanism for Prometheus targets or not.
        /// </summary>
        public readonly bool Enabled;
        /// <summary>
        /// FilterStrategy determines how to filter targets before allocating them among the collectors. The only current option is relabel-config (drops targets based on prom relabel_config). Filtering is disabled by default.
        /// </summary>
        public readonly string FilterStrategy;
        /// <summary>
        /// Image indicates the container image to use for the OpenTelemetry TargetAllocator.
        /// </summary>
        public readonly string Image;
        /// <summary>
        /// PrometheusCR defines the configuration for the retrieval of PrometheusOperator CRDs ( servicemonitor.monitoring.coreos.com/v1 and podmonitor.monitoring.coreos.com/v1 )  retrieval. All CR instances which the ServiceAccount has access to will be retrieved. This includes other namespaces.
        /// </summary>
        public readonly Pulumi.Kubernetes.Types.Outputs.Opentelemetry.V1Alpha1.OpenTelemetryCollectorSpecTargetallocatorPrometheuscr PrometheusCR;
        /// <summary>
        /// Replicas is the number of pod instances for the underlying TargetAllocator. This should only be set to a value other than 1 if a strategy that allows for high availability is chosen. Currently, the only allocation strategy that can be run in a high availability mode is consistent-hashing.
        /// </summary>
        public readonly int Replicas;
        /// <summary>
        /// ServiceAccount indicates the name of an existing service account to use with this instance. When set, the operator will not automatically create a ServiceAccount for the TargetAllocator.
        /// </summary>
        public readonly string ServiceAccount;

        [OutputConstructor]
        private OpenTelemetryCollectorSpecTargetallocator(
            string allocationStrategy,

            bool enabled,

            string filterStrategy,

            string image,

            Pulumi.Kubernetes.Types.Outputs.Opentelemetry.V1Alpha1.OpenTelemetryCollectorSpecTargetallocatorPrometheuscr prometheusCR,

            int replicas,

            string serviceAccount)
        {
            AllocationStrategy = allocationStrategy;
            Enabled = enabled;
            FilterStrategy = filterStrategy;
            Image = image;
            PrometheusCR = prometheusCR;
            Replicas = replicas;
            ServiceAccount = serviceAccount;
        }
    }
}
