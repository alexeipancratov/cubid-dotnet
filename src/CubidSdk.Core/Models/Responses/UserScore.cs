using System.Text.Json.Serialization;

namespace CubidSdk.Core.Models.Responses;

public class UserScore
{
    [JsonPropertyName("error")]
    public string? Error { get; set; }

    [JsonPropertyName("scoring_schema")]
    public int ScoringSchema { get; set; }

    [JsonPropertyName("cubid_score")]
    public int CubidScore { get; set; }

    public override string ToString()
    {
        return $"Error: {Error}, ScoringSchema: {ScoringSchema}, CubidScore: {CubidScore}";
    }
}