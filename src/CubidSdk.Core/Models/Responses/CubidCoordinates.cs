using System.Text.Json.Serialization;

namespace CubidSdk.Core.Models.Responses;

public class CubidCoordinates
{
    [JsonPropertyName("lat")]
    public string Latitude { get; set; } = string.Empty;

    [JsonPropertyName("lng")]
    public string Longitude { get; set; } = string.Empty;

    public override string ToString()
    {
        return $"{Latitude} {Longitude}";
    }
}