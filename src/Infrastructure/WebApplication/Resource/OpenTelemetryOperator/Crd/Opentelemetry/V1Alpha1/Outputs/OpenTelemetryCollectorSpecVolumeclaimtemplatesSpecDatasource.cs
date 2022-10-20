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
    /// dataSource field can be used to specify either: * An existing VolumeSnapshot object (snapshot.storage.k8s.io/VolumeSnapshot) * An existing PVC (PersistentVolumeClaim) If the provisioner or an external controller can support the specified data source, it will create a new volume based on the contents of the specified data source. If the AnyVolumeDataSource feature gate is enabled, this field will always have the same contents as the DataSourceRef field.
    /// </summary>
    [OutputType]
    public sealed class OpenTelemetryCollectorSpecVolumeclaimtemplatesSpecDatasource
    {
        /// <summary>
        /// APIGroup is the group for the resource being referenced. If APIGroup is not specified, the specified Kind must be in the core API group. For any other third-party types, APIGroup is required.
        /// </summary>
        public readonly string ApiGroup;
        /// <summary>
        /// Kind is the type of resource being referenced
        /// </summary>
        public readonly string Kind;
        /// <summary>
        /// Name is the name of resource being referenced
        /// </summary>
        public readonly string Name;

        [OutputConstructor]
        private OpenTelemetryCollectorSpecVolumeclaimtemplatesSpecDatasource(
            string apiGroup,

            string kind,

            string name)
        {
            ApiGroup = apiGroup;
            Kind = kind;
            Name = name;
        }
    }
}
