using System.Text.Json.Serialization;

namespace CubidSdk.Core.Models.Responses;

public class CreateUserResponse
{
    [JsonPropertyName("user_id")]
    public string UserId { get; set; } = string.Empty;

    [JsonPropertyName("is_new_app_user")]
    public bool IsNewAppUser { get; set; }

    [JsonPropertyName("is_sybil_attack")]
    public bool IsSybilAttack { get; set; }

    [JsonPropertyName("is_blacklisted")]
    public bool IsBlacklisted { get; set; }

    [JsonPropertyName("error")]
    public string? Error { get; set; }

    public override string ToString()
    {
        return $"CreateUserResponse: [UserId: {UserId ?? "Not Set"}, IsNewAppUser: {IsNewAppUser}, IsSybilAttack: {IsSybilAttack}, IsBlacklisted: {IsBlacklisted}, Error: {Error ?? "None"}]";
    }
}