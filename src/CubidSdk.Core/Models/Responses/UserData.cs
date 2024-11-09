using System.Text.Json.Serialization;

namespace CubidSdk.Core.Models.Responses;

public class UserData
{
    [JsonPropertyName("error")]
    public string? Error { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; } = string.Empty;

    [JsonPropertyName("placename")]
    public string PlaceName { get; set; } = string.Empty;

    [JsonPropertyName("country")]
    public string Country { get; set; } = string.Empty;

    [JsonPropertyName("coordinates")]
    public CubidCoordinates Coordinates { get; set; } = new CubidCoordinates();

    public override string ToString()
    {
        return $"Error: {Error}, Name: {Name}, PlaceName: {PlaceName}, Country: {Country}, Coordinates: {Coordinates}";
    }
}