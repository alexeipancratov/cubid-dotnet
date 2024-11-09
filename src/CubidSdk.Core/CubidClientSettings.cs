namespace CubidSdk.Core;

public class CubidClientSettings(string dappId, string apiKey)
{
    public string DappId { get; } = dappId;

    public string ApiKey { get; } = apiKey;
}