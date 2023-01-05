// *** WARNING: this file was generated by crd2pulumi. ***
// *** Do not edit by hand unless you're certain you know what you are doing! ***

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading.Tasks;
using Pulumi.Serialization;

namespace Pulumi.Kubernetes.Types.Inputs.Acme.V1
{

    /// <summary>
    /// managed identity configuration, can not be used at the same time as clientID, clientSecretSecretRef or tenantID
    /// </summary>
    public class ChallengeSpecSolverDns01AzurednsManagedidentityArgs : Pulumi.ResourceArgs
    {
        /// <summary>
        /// client ID of the managed identity, can not be used at the same time as resourceID
        /// </summary>
        [Input("clientID")]
        public Input<string>? ClientID { get; set; }

        /// <summary>
        /// resource ID of the managed identity, can not be used at the same time as clientID
        /// </summary>
        [Input("resourceID")]
        public Input<string>? ResourceID { get; set; }

        public ChallengeSpecSolverDns01AzurednsManagedidentityArgs()
        {
        }
    }
}
