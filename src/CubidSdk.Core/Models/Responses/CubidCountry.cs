using System.Text.Json.Serialization;

namespace CubidSdk.Core.Models.Responses;

public class CubidCountry
{
    [JsonPropertyName("formattedAddress")]
    public string FormattedAddress { get; set; } = string.Empty;

    [JsonPropertyName("postalCode")]
    public string PostalCode { get; set; } = string.Empty;

    [JsonPropertyName("country")]
    public string Country { get; set; } = string.Empty;

    public override string ToString()
    {
        return $"Formatted Addresss: {FormattedAddress}, PostalCode: {PostalCode}, Country: {Country}";
    }
}