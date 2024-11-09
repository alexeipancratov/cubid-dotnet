using System.Text;
using System.Text.Json;
using CubidSdk.Core.Models.Responses;

namespace CubidSdk.Core;

public class CubidClient(HttpClient httpClient, CubidClientSettings clientSettings)
{
    private readonly HttpClient _httpClient = httpClient;
    private readonly CubidClientSettings _clientSettings = clientSettings;

    public Task<CreateUserResponse> CreateUser(string email, string phone)
    {
        return MakePostRequest<CreateUserResponse>("create_user",
            new { dapp_id = _clientSettings.DappId, apikey = _clientSettings.ApiKey, email, phone });
    }

    private async Task<T> MakePostRequest<T>(string relativeUrl, object payload)
    {
        var request = new HttpRequestMessage(HttpMethod.Post, $"https://passport.cubid.me/api/v2/{relativeUrl}");
        request.Headers.Add("dapp-id", _clientSettings.DappId);
        request.Headers.Add("api-key", _clientSettings.ApiKey);

        string jsonPayload = JsonSerializer.Serialize(payload);
        var content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");
        request.Content = content;

        var response = await _httpClient.SendAsync(request);
        var stringResponse = await response.Content.ReadAsStringAsync();

        var responseObject = JsonSerializer.Deserialize<T>(stringResponse) ?? throw new Exception("Empty response received");

        return responseObject;
    }
}
