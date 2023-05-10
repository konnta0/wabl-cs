using Google.Apis.Auth.OAuth2;

namespace DatabaseMigration.Command;

public interface IGoogleApiHelper
{
    ValueTask<GoogleCredential> GetGoogleCredentialAsync(string credentialPath, params string[] scopes);
}