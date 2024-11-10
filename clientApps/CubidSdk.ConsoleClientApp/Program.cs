using CubidSdk.Core;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

#region Setup

var serviceProvider = new ServiceCollection()
                .AddLogging(configure => configure.AddConsole().SetMinimumLevel(LogLevel.Warning))
                .AddCubidClient(dappId, apiKey)
                .AddHttpClient()
                .BuildServiceProvider();

var logger = serviceProvider.GetRequiredService<ILogger<Program>>();
logger.LogInformation("Application started.");

var cubidClient = serviceProvider.GetRequiredService<CubidClient>();

await InteractWithSdk(cubidClient);

logger.LogInformation("Application finished.");

#endregion

static async Task InteractWithSdk(CubidClient cubidClient)
{
    var createUserResult = await cubidClient.CreateUser("test@test.com", "1234567890");
    if (createUserResult.IsSuccess)
        Console.WriteLine($"Created user: {createUserResult.Value}");
    else
        Console.WriteLine($"Failed to create user due to: {createUserResult.Error}");

    var userId = createUserResult.Value.UserId;

    var identityResponse = await cubidClient.FetchIdentity(userId);
    if (identityResponse.IsSuccess)
        Console.WriteLine($"Identity details: {identityResponse.Value}");
    else
        Console.WriteLine($"Failed to fetch identity details due to: {identityResponse.Error}");

    var exactLocationResponse = await cubidClient.FetchExactLocation(userId);
    if (exactLocationResponse.IsSuccess)
        Console.WriteLine($"Exact location: {exactLocationResponse.Value}");
    else
        Console.WriteLine($"Failed to fetch exact location due to: {exactLocationResponse.Error}");

    var approximateLocationRespone = await cubidClient.FetchApproximateLocation(userId);
    if (approximateLocationRespone.IsSuccess)
        Console.WriteLine($"Approximate location: {approximateLocationRespone.Value}");
    else
        Console.WriteLine($"Failed to fetch approximate location due to: {approximateLocationRespone.Error}");

    var roughLocationResponse = await cubidClient.FetchRoughLocation(userId);
    if (roughLocationResponse.IsSuccess)
        Console.WriteLine($"Rough Location {roughLocationResponse.Value}");
    else
        Console.WriteLine($"Failed to fetch rough location due to: {roughLocationResponse.Error}");

    var userDataResponse = await cubidClient.FetchUserData(userId);
    if (userDataResponse.IsSuccess)
        Console.WriteLine($"User data: {userDataResponse.Value}");
    else
        Console.WriteLine($"Failed to fetch user data due to: {userDataResponse.Error}");

    var userScoreResponse = await cubidClient.FetchScore(userId);
    if (userScoreResponse.IsSuccess)
        Console.WriteLine($"User score: {userScoreResponse.Value}");
    else
        Console.WriteLine($"Failed to fetch user score due to: {userScoreResponse.Error}");

    var saveSecretResponse = await cubidClient.SaveSecret(userId, "TEST-SECRET-VALUE");
    if (saveSecretResponse.IsSuccess)
        Console.WriteLine($"Saved user secret: {saveSecretResponse.Value}");
    else
        Console.WriteLine($"Failed to save user secret due to: {saveSecretResponse.Error}");
}