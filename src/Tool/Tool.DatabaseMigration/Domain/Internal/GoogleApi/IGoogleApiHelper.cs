using Google.Apis.Auth.OAuth2;

namespace Tool.DatabaseMigration.Domain.Internal.GoogleApi;

internal interface IGoogleApiHelper
{
    ValueTask<GoogleCredential> GetGoogleCredentialAsync(params string[] scopes);
}