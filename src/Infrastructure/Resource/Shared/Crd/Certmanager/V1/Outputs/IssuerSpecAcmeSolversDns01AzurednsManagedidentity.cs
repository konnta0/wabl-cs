// *** WARNING: this file was generated by crd2pulumi. ***
// *** Do not edit by hand unless you're certain you know what you are doing! ***

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading.Tasks;
using Pulumi.Serialization;

namespace Pulumi.Kubernetes.Types.Outputs.Certmanager.V1
{

    /// <summary>
    /// managed identity configuration, can not be used at the same time as clientID, clientSecretSecretRef or tenantID
    /// </summary>
    [OutputType]
    public sealed class IssuerSpecAcmeSolversDns01AzurednsManagedidentity
    {
        /// <summary>
        /// client ID of the managed identity, can not be used at the same time as resourceID
        /// </summary>
        public readonly string ClientID;
        /// <summary>
        /// resource ID of the managed identity, can not be used at the same time as clientID
        /// </summary>
        public readonly string ResourceID;

        [OutputConstructor]
        private IssuerSpecAcmeSolversDns01AzurednsManagedidentity(
            string clientID,

            string resourceID)
        {
            ClientID = clientID;
            ResourceID = resourceID;
        }
    }
}
