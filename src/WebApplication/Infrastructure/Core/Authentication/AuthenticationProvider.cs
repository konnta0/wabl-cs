using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Application.Core.Authentication;
using Microsoft.Extensions.Options;

namespace Infrastructure.Core.Authentication;

internal class AuthenticationProvider : IAuthenticationProvider
{
    private readonly HttpClient _httpClient;
    private readonly IOptions<AuthenticationConfig> _authenticationConfig;

    public AuthenticationProvider(
        HttpClient httpClient,
        IOptions<AuthenticationConfig> authenticationConfig
        )
    {
        _httpClient = httpClient;
        _authenticationConfig = authenticationConfig;
    }
    
    public async ValueTask<SignUpResult> SignUpAsync(string userName, string password, CancellationToken cancellationToken = new CancellationToken())
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

        await SignInAsync(userName, password, cancellationToken);

        return new SignUpResult
        {
            ResultType = resultType
        };
    }

    public async ValueTask<AuthenticationResult> SignInAsync(string userName, string password, CancellationToken cancellationToken = new CancellationToken())
    {
        var requestContent = new FormUrlEncodedContent(new[]
        {
            new KeyValuePair<string, string>("client_id", "web-api"),
            new KeyValuePair<string, string>("username", userName),
            new KeyValuePair<string, string>("password", password),
            new KeyValuePair<string, string>("grant_type", "password"),
        });
        var response = await _httpClient.PostAsync($"{_authenticationConfig.Value.AuthorityBaseUrl}/auth/realms/{_authenticationConfig.Value.Realm}/protocol/openid-connect/token", requestContent, cancellationToken);

        var contentString = await response.Content.ReadAsStringAsync(cancellationToken);
        var tokenResponse = JsonSerializer.Deserialize<TokenResponse>(contentString);
        var accessToken = tokenResponse!.AccessToken;
        return new AuthenticationResult
        {
            AccessToken = accessToken
        };
    }

    private class AdminTokenResponse
    {
        [JsonPropertyName("access_token")] public string AccessToken { get; set; } = default!;
    }
    
    private class TokenResponse
    {
        [JsonPropertyName("access_token")] public string AccessToken { get; set; } = default!;
    }
}