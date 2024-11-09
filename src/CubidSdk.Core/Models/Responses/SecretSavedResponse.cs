using System.Text.Json.Serialization;

namespace CubidSdk.Core.Models.Responses;

public class SecretSavedResponse
{
    [JsonPropertyName("success")]
    public bool Success { get; set; }

    public override string ToString()
    {
        return $"Success: {Success}";
    }
}