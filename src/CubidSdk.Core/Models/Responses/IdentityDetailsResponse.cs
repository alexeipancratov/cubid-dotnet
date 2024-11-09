using System.Text.Json.Serialization;

namespace CubidSdk.Core.Models.Responses;

public class IdentityDetailsResponse
{
    [JsonPropertyName("error")]
    public string? Error { get; set; }

    [JsonPropertyName("stamp_details")]
    public IReadOnlyList<StampDetails> StampDetails { get; set; } = [];

    public override string ToString()
    {
        return $"IdentityDetailsResponse: Error={Error}, StampDetails={string.Join(", ", StampDetails)}";
    }
}