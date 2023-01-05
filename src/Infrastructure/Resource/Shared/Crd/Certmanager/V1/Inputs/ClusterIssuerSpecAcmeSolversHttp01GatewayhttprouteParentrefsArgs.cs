// *** WARNING: this file was generated by crd2pulumi. ***
// *** Do not edit by hand unless you're certain you know what you are doing! ***

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading.Tasks;
using Pulumi.Serialization;

namespace Pulumi.Kubernetes.Types.Inputs.Certmanager.V1
{

    /// <summary>
    /// ParentRef identifies an API object (usually a Gateway) that can be considered a parent of this resource (usually a route). The only kind of parent resource with "Core" support is Gateway. This API may be extended in the future to support additional kinds of parent resources, such as HTTPRoute. 
    ///  The API object must be valid in the cluster; the Group and Kind must be registered in the cluster for this reference to be valid. 
    ///  References to objects with invalid Group and Kind are not valid, and must be rejected by the implementation, with appropriate Conditions set on the containing object.
    /// </summary>
    public class ClusterIssuerSpecAcmeSolversHttp01GatewayhttprouteParentrefsArgs : Pulumi.ResourceArgs
    {
        /// <summary>
        /// Group is the group of the referent. 
        ///  Support: Core
        /// </summary>
        [Input("group")]
        public Input<string>? Group { get; set; }

        /// <summary>
        /// Kind is kind of the referent. 
        ///  Support: Core (Gateway) Support: Custom (Other Resources)
        /// </summary>
        [Input("kind")]
        public Input<string>? Kind { get; set; }

        /// <summary>
        /// Name is the name of the referent. 
        ///  Support: Core
        /// </summary>
        [Input("name", required: true)]
        public Input<string> Name { get; set; } = null!;

        /// <summary>
        /// Namespace is the namespace of the referent. When unspecified (or empty string), this refers to the local namespace of the Route. 
        ///  Support: Core
        /// </summary>
        [Input("namespace")]
        public Input<string>? Namespace { get; set; }

        /// <summary>
        /// SectionName is the name of a section within the target resource. In the following resources, SectionName is interpreted as the following: 
        ///  * Gateway: Listener Name 
        ///  Implementations MAY choose to support attaching Routes to other resources. If that is the case, they MUST clearly document how SectionName is interpreted. 
        ///  When unspecified (empty string), this will reference the entire resource. For the purpose of status, an attachment is considered successful if at least one section in the parent resource accepts it. For example, Gateway listeners can restrict which Routes can attach to them by Route kind, namespace, or hostname. If 1 of 2 Gateway listeners accept attachment from the referencing Route, the Route MUST be considered successfully attached. If no Gateway listeners accept attachment from this Route, the Route MUST be considered detached from the Gateway. 
        ///  Support: Core
        /// </summary>
        [Input("sectionName")]
        public Input<string>? SectionName { get; set; }

        public ClusterIssuerSpecAcmeSolversHttp01GatewayhttprouteParentrefsArgs()
        {
            Group = "gateway.networking.k8s.io";
            Kind = "Gateway";
        }
    }
}
