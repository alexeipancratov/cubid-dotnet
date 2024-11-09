using System.Text.Json.Serialization;

namespace CubidSdk.Core.Models.Responses;

public class StampDetails
{
    [JsonPropertyName("value")]
    public string? Value { get; set; }

    [JsonPropertyName("stamp_type")]
    public string? StampType { get; set; }

    [JsonPropertyName("status")]
    public string? Status { get; set; }

    public override string ToString()
    {
        return "StampDetails{" +
               $"Value='{Value}', " +
               $"StampType='{StampType}', " +
               $"Status='{Status}'" +
               "}";
    }
}