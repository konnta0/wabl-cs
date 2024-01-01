using System.Net;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.Extensions.Logging;
using WebApplication.Application.Core.Authentication;
using Microsoft.Extensions.Options;
using ZLogger;

namespace WebApplication.Infrastructure.Core.Authentication;

internal class AuthenticationProvider : IAuthenticationProvider
{
    private readonly HttpClient _httpClient;
    private readonly IOptions<AuthenticationConfig> _authenticationConfig;
    private readonly ILogger<AuthenticationProvider> _logger;

    public AuthenticationProvider(
        HttpClient httpClient,
        IOptions<AuthenticationConfig> authenticationConfig,
        ILogger<AuthenticationProvider> logger
        )
    {
        _httpClient = httpClient;
        _authenticationConfig = authenticationConfig;
        _logger = logger;
    }
    
    public async ValueTask<SignUpResult> SignUpAsync(string userName, string password, CancellationToken cancellationToken = new ())
    {
        var adminTokenResponse = await _httpClient.PostAsync($"{_authenticationConfig.Value.AuthorityBaseUrl}protocol/openid-connect/token", new FormUrlEncodedContent(new []
        {
            new KeyValuePair<string, string>("username", _authenticationConfig.Value.AdminUserName),
            new KeyValuePair<string, string>("password", _authenticationConfig.Value.AdminPassword),
            new KeyValuePair<string, string>("grant_type", "password"),
            new KeyValuePair<string, string>("client_id", "web-api")
        }), cancellationToken);

        var responseContent = await adminTokenResponse.Content.ReadAsStringAsync(cancellationToken);
        var adminToken = JsonSerializer.Deserialize<AdminTokenResponse>(responseContent);
        
        // User creation
        var request = new HttpRequestMessage(HttpMethod.Post, $"{_authenticationConfig.Value.AdminBaseUrl}/admin/realms/{_authenticationConfig.Value.Realm}/users");
        request.Headers.Add("Authorization", $"Bearer {adminToken!.AccessToken}");

        var content = new StringContent(JsonSerializer.Serialize(new
        {
            username = userName,
            password,
            enabled = true
        }), Encoding.UTF8, "application/json");
        request.Content = content;

        var response = await _httpClient.SendAsync(request, cancellationToken);
        var resultType = response.IsSuccessStatusCode ? SignUpResultType.Success : SignUpResultType.Failed;

        var authenticationResult = await SignInAsync(userName, password, cancellationToken);

        return new SignUpResult
        {
            ResultType = resultType,
            AccessToken = authenticationResult.ResultType is AuthenticationResultType.Success ? authenticationResult.AccessToken : string.Empty
        };
    }

    public async ValueTask<AuthenticationResult> SignInAsync(string userName, string password, CancellationToken cancellationToken = new ())
    {
        var requestContent = new FormUrlEncodedContent(new[]
        {
            new KeyValuePair<string, string>("client_id", "web-api"),
            new KeyValuePair<string, string>("username", userName),
            new KeyValuePair<string, string>("password", password),
            new KeyValuePair<string, string>("grant_type", "password"),
        });
        var response = await _httpClient.PostAsync($"{_authenticationConfig.Value.AuthorityBaseUrl}/auth/realms/{_authenticationConfig.Value.Realm}/protocol/openid-connect/token", requestContent, cancellationToken);

        if (response.StatusCode is not HttpStatusCode.OK)
        {
            _logger.ZLogError($"Sign in failed. {response.StatusCode}");
            return new AuthenticationResult
            {
                AccessToken = string.Empty,
                ResultType = AuthenticationResultType.Failed
            };
        }

        var contentString = await response.Content.ReadAsStringAsync(cancellationToken);
        var tokenResponse = JsonSerializer.Deserialize<TokenResponse>(contentString);
        var accessToken = tokenResponse!.AccessToken;
        return new AuthenticationResult
        {
            AccessToken = accessToken,
            ResultType = AuthenticationResultType.Success
        };
    }

    private class AdminTokenResponse
    {
        [JsonPropertyName("access_token")] public string AccessToken { get; init; } = default!;
    }
    
    private class TokenResponse
    {
        [JsonPropertyName("access_token")] public string AccessToken { get; init; } = default!;
    }
}