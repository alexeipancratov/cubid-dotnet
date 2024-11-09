# Cubid SDK

**Cubid SDK** provides a simple interface for interacting with the Cubid API to manage identity, location, and score data for users, and to securely store secrets. The SDK is designed for easy integration into dApps or web applications that require identity management using the Cubid Protocol.

## Features

- **User Identity Management**: Fetch and manage user identity data.
- **Location Data**: Retrieve approximate, rough, or exact location data for a user.
- **User Score**: Fetch the trust score of a user.
- **User Creation**: Create new users with email and phone number.
- **Secret Storage**: Save and manage secrets for users.

## Installation

You can install the SDK via Nuget (not published yet):

```bash
dotnet add package CubidSdk
```

## API Keys

Use Cubid's [Admin Console](https://admin.cubid.me/admin) to configure your App and get provisioned with a dApp ID and API Keys.

## Usage

Here's an example of how to use the Cubid SDK:

### Registration

```csharp
new ServiceCollection()
    .AddHttpClient()
    .AddCubidClient("DAPP-ID", "API-KEY");
```

### API Methods (examples, non-exhaustive list)

#### 1. **Create a New User**

```csharp
var createUserResult = await cubidClient.CreateUser("test@test.com", "1234567890");
if (createUserResult.IsSuccess)
    Console.WriteLine($"Created user: {createUserResult.Value}");
else
    Console.WriteLine($"Failed to create user due to: {createUserResult.Error}");
```

#### 2. **Fetch Identity Data**

```csharp
var identityResponse = await cubidClient.FetchIdentity(userId);
if (identityResponse.IsSuccess)
    Console.WriteLine($"Identity details: {identityResponse.Value}");
else
    Console.WriteLine($"Failed to fetch identity details due to: {identityResponse.Error}");
```

#### 3. **Fetch User Location (Exact)**

```csharp
var exactLocationResponse = await cubidClient.FetchExactLocation(userId);
if (exactLocationResponse.IsSuccess)
    Console.WriteLine($"Exact location: {exactLocationResponse.Value}");
else
    Console.WriteLine($"Failed to fetch exact location due to: {exactLocationResponse.Error}");
```

#### 4. **Fetch User Location (Approximate)**

```csharp
var approximateLocationRespone = await cubidClient.FetchApproximateLocation(userId);
if (approximateLocationRespone.IsSuccess)
    Console.WriteLine($"Approximate location: {approximateLocationRespone.Value}");
else
    Console.WriteLine($"Failed to fetch approximate location due to: {approximateLocationRespone.Error}");
```

#### 5. **Fetch Rough Location (Rough)**

```csharp
var roughLocationResponse = await cubidClient.FetchRoughLocation(userId);
if (roughLocationResponse.IsSuccess)
    Console.WriteLine($"Rough Location {roughLocationResponse.Value}");
else
    Console.WriteLine($"Failed to fetch rough location due to: {roughLocationResponse.Error}");
```

#### 6. **Fetch User Data**

```csharp
var userDataResponse = await cubidClient.FetchUserData(userId);
if (userDataResponse.IsSuccess)
    Console.WriteLine($"User data: {userDataResponse.Value}");
else
    Console.WriteLine($"Failed to fetch user data due to: {userDataResponse.Error}");
```

#### 7. **Fetch Score**

```csharp
var userScoreResponse = await cubidClient.FetchScore(userId);
if (userScoreResponse.IsSuccess)
    Console.WriteLine($"User score: {userScoreResponse.Value}");
else
    Console.WriteLine($"Failed to fetch user score due to: {userScoreResponse.Error}");
```

#### 8. **Save Secret for a User**

```csharp
var saveSecretResponse = await cubidClient.SaveSecret(userId, "TEST-SECRET-VALUE");
if (saveSecretResponse.IsSuccess)
    Console.WriteLine($"Saved user secret: {saveSecretResponse.Value}");
else
    Console.WriteLine($"Failed to save user secret due to: {saveSecretResponse.Error}");
```

### API Reference

For more detailed information about the API endpoints and parameters, check the [Cubid API Documentation](https://docs.cubid.me/#/api-reference).

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.
