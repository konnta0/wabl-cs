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
    public sealed class TidbNGMonitoringSpecNgmonitoringAdditionalvolumesGitrepo
    {
        public readonly string Directory;
        public readonly string Repository;
        public readonly string Revision;

        [OutputConstructor]
        private TidbNGMonitoringSpecNgmonitoringAdditionalvolumesGitrepo(
            string directory,

            string repository,

            string revision)
        {
            Directory = directory;
            Repository = repository;
            Revision = revision;
        }
    }
}
