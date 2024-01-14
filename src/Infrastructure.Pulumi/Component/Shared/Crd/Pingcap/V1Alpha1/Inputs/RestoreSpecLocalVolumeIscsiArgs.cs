// *** WARNING: this file was generated by crd2pulumi. ***
// *** Do not edit by hand unless you're certain you know what you are doing! ***

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading.Tasks;
using Pulumi.Serialization;

namespace Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1
{

    public class RestoreSpecLocalVolumeIscsiArgs : global::Pulumi.ResourceArgs
    {
        [Input("chapAuthDiscovery")]
        public Input<bool>? ChapAuthDiscovery { get; set; }

        [Input("chapAuthSession")]
        public Input<bool>? ChapAuthSession { get; set; }

        [Input("fsType")]
        public Input<string>? FsType { get; set; }

        [Input("initiatorName")]
        public Input<string>? InitiatorName { get; set; }

        [Input("iqn", required: true)]
        public Input<string> Iqn { get; set; } = null!;

        [Input("iscsiInterface")]
        public Input<string>? IscsiInterface { get; set; }

        [Input("lun", required: true)]
        public Input<int> Lun { get; set; } = null!;

        [Input("portals")]
        private InputList<string>? _portals;
        public InputList<string> Portals
        {
            get => _portals ?? (_portals = new InputList<string>());
            set => _portals = value;
        }

        [Input("readOnly")]
        public Input<bool>? ReadOnly { get; set; }

        [Input("secretRef")]
        public Input<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.RestoreSpecLocalVolumeIscsiSecretRefArgs>? SecretRef { get; set; }

        [Input("targetPortal", required: true)]
        public Input<string> TargetPortal { get; set; } = null!;

        public RestoreSpecLocalVolumeIscsiArgs()
        {
        }
        public static new RestoreSpecLocalVolumeIscsiArgs Empty => new RestoreSpecLocalVolumeIscsiArgs();
    }
}
