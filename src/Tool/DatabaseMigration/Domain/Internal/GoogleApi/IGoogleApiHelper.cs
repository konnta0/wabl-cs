using Google.Apis.Auth.OAuth2;

namespace DatabaseMigration.Domain.Internal.GoogleApi;

internal interface IGoogleApiHelper
{
    ValueTask<GoogleCredential> GetGoogleCredentialAsync(params string[] scopes);
}