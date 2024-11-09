using System.Text.Json.Serialization;

namespace CubidSdk.Core.Models.Responses;

public class RoughLocationResponse
{
    [JsonPropertyName("error")]
    public string? Error { get; set; }

    [JsonPropertyName("cubid_country")]
    public CubidCountry CubidCountry { get; set; } = new CubidCountry();

    [JsonPropertyName("pluscode")]
    public string? PlusCode { get; set; }

    [JsonPropertyName("coordinates")]
    public CubidCoordinates Coordinates { get; set; } = new CubidCoordinates();

    public override string ToString()
    {
        return $"Error: {Error}, Cubid Country: {CubidCountry}, PlusCode: {PlusCode}, Coordinates: {Coordinates}";
    }
}