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
    /// PKCS12 configures options for storing a PKCS12 keystore in the `spec.secretName` Secret resource.
    /// </summary>
    public class CertificateSpecKeystoresPkcs12Args : Pulumi.ResourceArgs
    {
        /// <summary>
        /// Create enables PKCS12 keystore creation for the Certificate. If true, a file named `keystore.p12` will be created in the target Secret resource, encrypted using the password stored in `passwordSecretRef`. The keystore file will only be updated upon re-issuance. A file named `truststore.p12` will also be created in the target Secret resource, encrypted using the password stored in `passwordSecretRef` containing the issuing Certificate Authority
        /// </summary>
        [Input("create", required: true)]
        public Input<bool> Create { get; set; } = null!;

        /// <summary>
        /// PasswordSecretRef is a reference to a key in a Secret resource containing the password used to encrypt the PKCS12 keystore.
        /// </summary>
        [Input("passwordSecretRef", required: true)]
        public Input<Pulumi.Kubernetes.Types.Inputs.Certmanager.V1.CertificateSpecKeystoresPkcs12PasswordsecretrefArgs> PasswordSecretRef { get; set; } = null!;

        public CertificateSpecKeystoresPkcs12Args()
        {
        }
    }
}
