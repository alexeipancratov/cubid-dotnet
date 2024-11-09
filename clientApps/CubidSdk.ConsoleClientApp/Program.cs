using CubidSdk.Core;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

const string dappId = "08dd51f7-15c2-4185-990a-c5fafff66bc7";
const string apiKey = "7cc0eab4-1647-4769-b221-49c9d0a35d26";
const string userId = "f33bd88f-bdf0-43c3-89e4-525bc193cc79";

#region Setup

var serviceProvider = new ServiceCollection()
                .AddLogging(configure => configure.AddConsole())
                .AddCubidClient(dappId, apiKey)
                .AddHttpClient()
                .BuildServiceProvider();

var logger = serviceProvider.GetRequiredService<ILogger<Program>>();
logger.LogInformation("Application started.");

var cubidClient = serviceProvider.GetRequiredService<CubidClient>();

await InteractWithSdk(cubidClient);

logger.LogInformation("Application finished.");

#endregion

async Task InteractWithSdk(CubidClient cubidClient)
{
    var response = await cubidClient.CreateUser("test@test.com", "1234567890");

    if (response.IsSuccess)
        logger.LogInformation("Created user: {UserResponse}", response);
    else
        logger.LogInformation("Failed to create user due to: {Error}", response.Error);
}