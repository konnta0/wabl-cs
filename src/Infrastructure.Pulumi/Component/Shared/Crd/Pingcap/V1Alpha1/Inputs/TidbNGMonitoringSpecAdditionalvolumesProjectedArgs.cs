// *** WARNING: this file was generated by crd2pulumi. ***
// *** Do not edit by hand unless you're certain you know what you are doing! ***

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading.Tasks;
using Pulumi.Serialization;

namespace Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1
{

    public class TidbNGMonitoringSpecAdditionalVolumesProjectedArgs : global::Pulumi.ResourceArgs
    {
        [Input("defaultMode")]
        public Input<int>? DefaultMode { get; set; }

        [Input("sources", required: true)]
        private InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbNGMonitoringSpecAdditionalVolumesProjectedSourcesArgs>? _sources;
        public InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbNGMonitoringSpecAdditionalVolumesProjectedSourcesArgs> Sources
        {
            get => _sources ?? (_sources = new InputList<Pulumi.Kubernetes.Types.Inputs.Pingcap.V1Alpha1.TidbNGMonitoringSpecAdditionalVolumesProjectedSourcesArgs>());
            set => _sources = value;
        }

        public TidbNGMonitoringSpecAdditionalVolumesProjectedArgs()
        {
        }
        public static new TidbNGMonitoringSpecAdditionalVolumesProjectedArgs Empty => new TidbNGMonitoringSpecAdditionalVolumesProjectedArgs();
    }
}
