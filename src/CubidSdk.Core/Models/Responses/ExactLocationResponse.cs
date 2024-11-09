using System.Text.Json.Serialization;

namespace CubidSdk.Core.Models.Responses;

public class ExactLocationResponse
{
    [JsonPropertyName("error")]
    public string? Error { get; set; }

    public override string ToString()
    {
        return $"Error: {Error}";
    }
}