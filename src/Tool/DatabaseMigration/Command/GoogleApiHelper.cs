using Google.Apis.Auth.OAuth2;
using Microsoft.Extensions.Logging;

namespace DatabaseMigration.Command;

public class GoogleApiHelper : IGoogleApiHelper
{
    private readonly ILogger<GoogleApiHelper> _logger;

    public GoogleApiHelper(ILogger<GoogleApiHelper> logger)
    {
        _logger = logger;
    }

    public async ValueTask<GoogleCredential> GetGoogleCredentialAsync(string credentialPath, params string[] scopes)
    {
        var credential = await GoogleCredential.GetApplicationDefaultAsync();
        return credential.CreateScoped(scopes);
    }
}