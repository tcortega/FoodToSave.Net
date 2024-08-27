using System;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using CommunityToolkit.Diagnostics;
using FoodToSave.Net.Utils;

namespace FoodToSave.Net.Authentication;

internal record AuthStoreState
{
    public required string SessionId { get; set; }
    public AuthResponse? AuthResponse { get; private set; }
    public DateTimeOffset? TokenExpiresAt { get; set; }

    public void SetAuthResponse(AuthResponse? response)
    {
        AuthResponse = response;
        UpdateTokenExpiration();
    }

    public void UpdateTokens(RefreshTokenResponse response)
    {
        Guard.IsNotNull(AuthResponse);

        AuthResponse.AccessToken = response.AccessToken;
        AuthResponse.RefreshToken = response.RefreshToken;
        UpdateTokenExpiration();
    }

    [MemberNotNullWhen(true, nameof(AuthResponse))]
    public bool IsAuthenticated => AuthResponse != null && !HasTokenExpired;

    public bool HasTokenExpired => TokenExpiresAt.HasValue && TokenExpiresAt.Value < DateTimeOffset.UtcNow;

    private void UpdateTokenExpiration()
    {
        var encodedPayload = AuthResponse!.AccessToken.Split('.')[1];
        var decoded = encodedPayload.GetBytesFromBase64();
        var payload = JsonSerializer.Deserialize<JwtPayload>(decoded)!;

        TokenExpiresAt = DateTimeOffset.FromUnixTimeSeconds(payload.ExpiresAt);
    }
}

internal record JwtPayload
{
    [JsonPropertyName("exp")]
    public long ExpiresAt { get; set; }
}