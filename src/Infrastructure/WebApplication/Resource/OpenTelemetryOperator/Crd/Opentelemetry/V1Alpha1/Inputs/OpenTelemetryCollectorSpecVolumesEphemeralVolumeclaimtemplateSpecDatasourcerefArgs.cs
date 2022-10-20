// *** WARNING: this file was generated by crd2pulumi. ***
// *** Do not edit by hand unless you're certain you know what you are doing! ***

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading.Tasks;
using Pulumi.Serialization;

namespace Pulumi.Kubernetes.Types.Inputs.Opentelemetry.V1Alpha1
{

    /// <summary>
    /// dataSourceRef specifies the object from which to populate the volume with data, if a non-empty volume is desired. This may be any local object from a non-empty API group (non core object) or a PersistentVolumeClaim object. When this field is specified, volume binding will only succeed if the type of the specified object matches some installed volume populator or dynamic provisioner. This field will replace the functionality of the DataSource field and as such if both fields are non-empty, they must have the same value. For backwards compatibility, both fields (DataSource and DataSourceRef) will be set to the same value automatically if one of them is empty and the other is non-empty. There are two important differences between DataSource and DataSourceRef: * While DataSource only allows two specific types of objects, DataSourceRef allows any non-core object, as well as PersistentVolumeClaim objects. * While DataSource ignores disallowed values (dropping them), DataSourceRef preserves all values, and generates an error if a disallowed value is specified. (Beta) Using this field requires the AnyVolumeDataSource feature gate to be enabled.
    /// </summary>
    public class OpenTelemetryCollectorSpecVolumesEphemeralVolumeclaimtemplateSpecDatasourcerefArgs : Pulumi.ResourceArgs
    {
        /// <summary>
        /// APIGroup is the group for the resource being referenced. If APIGroup is not specified, the specified Kind must be in the core API group. For any other third-party types, APIGroup is required.
        /// </summary>
        [Input("apiGroup")]
        public Input<string>? ApiGroup { get; set; }

        /// <summary>
        /// Kind is the type of resource being referenced
        /// </summary>
        [Input("kind", required: true)]
        public Input<string> Kind { get; set; } = null!;

        /// <summary>
        /// Name is the name of resource being referenced
        /// </summary>
        [Input("name", required: true)]
        public Input<string> Name { get; set; } = null!;

        public OpenTelemetryCollectorSpecVolumesEphemeralVolumeclaimtemplateSpecDatasourcerefArgs()
        {
        }
    }
}
