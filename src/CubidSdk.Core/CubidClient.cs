using System.Text;
using System.Text.Json;
using CSharpFunctionalExtensions;
using CubidSdk.Core.Models.Responses;

namespace CubidSdk.Core;

public class CubidClient(HttpClient httpClient, CubidClientSettings clientSettings)
{
    private readonly HttpClient _httpClient = httpClient;
    private readonly CubidClientSettings _clientSettings = clientSettings;

    public Task<Result<CreateUserResponse>> CreateUser(string email, string phone)
    {
        return MakePostRequest<CreateUserResponse>("create_user",
            new { dapp_id = _clientSettings.DappId, apikey = _clientSettings.ApiKey, email, phone });
    }

    public Task<Result<IdentityDetailsResponse>> FetchIdentity(string userId)
    {
        return MakePostRequest<IdentityDetailsResponse>("identity/fetch_identity", new { apikey = _clientSettings.ApiKey, user_id = userId });
    }

    public Task<Result<ExactLocationResponse>> FetchExactLocation(string userId)
    {
        return MakePostRequest<ExactLocationResponse>("identity/fetch_exact_location", new { apikey = _clientSettings.ApiKey, user_id = userId });
    }

    public Task<Result<ApproximateLocationResponse>> FetchApproximateLocation(string userId)
    {
        return MakePostRequest<ApproximateLocationResponse>("identity/fetch_approx_location", new { apikey = _clientSettings.ApiKey, user_id = userId });
    }

    public Task<Result<RoughLocationResponse>> FetchRoughLocation(string userId)
    {
        return MakePostRequest<RoughLocationResponse>("identity/fetch_rough_location", new { apikey = _clientSettings.ApiKey, user_id = userId });
    }

    public Task<Result<UserData>> FetchUserData(string userId)
    {
        return MakePostRequest<UserData>("identity/fetch_user_data", new { apikey = _clientSettings.ApiKey, user_id = userId });
    }

    public Task<Result<UserScore>> FetchScore(string userId)
    {
        return MakePostRequest<UserScore>("score/fetch_score", new { apikey = _clientSettings.ApiKey, user_id = userId });
    }

    public Task<Result<SecretSavedResponse>> SaveSecret(string userId, string secret)
    {
        return MakePostRequest<SecretSavedResponse>("save_secret", new { apikey = _clientSettings.ApiKey, user_id = userId, secret });
    }

    private async Task<Result<T>> MakePostRequest<T>(string relativeUrl, object payload)
    {
        var request = new HttpRequestMessage(HttpMethod.Post, $"https://passport.cubid.me/api/v2/{relativeUrl}");
        request.Headers.Add("dapp-id", _clientSettings.DappId);
        request.Headers.Add("api-key", _clientSettings.ApiKey);

        string jsonPayload = JsonSerializer.Serialize(payload);
        var content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");
        request.Content = content;

        var response = await _httpClient.SendAsync(request);
        var stringResponse = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
            return Result.Failure<T>(stringResponse);

        var responseObject = JsonSerializer.Deserialize<T>(stringResponse) ?? throw new Exception("Empty response received");

        return responseObject;
    }
}
