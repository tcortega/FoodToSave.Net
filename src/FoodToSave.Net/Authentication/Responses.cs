using System.Text.Json.Serialization;

namespace FoodToSave.Net.Authentication;

/// <summary>
/// Represents the response from the refresh token API.
/// </summary>
public record RefreshTokenResponse
{
    /// <summary>
    /// The new access token.
    /// </summary>
    [JsonPropertyName("access_token")]
    public required string AccessToken { get; set; }

    /// <summary>
    /// The new refresh token.
    /// </summary>
    [JsonPropertyName("refresh_token")]
    public required string RefreshToken { get; set; }
}

/// <summary>
/// Represents the response from the authentication API.
/// </summary>
public record AuthResponse
{
    /// <summary>
    /// The access token.
    /// </summary>
    [JsonPropertyName("access_token")]
    public required string AccessToken { get; set; }

    /// <summary>
    /// The refresh token.
    /// </summary>
    [JsonPropertyName("refresh_token")]
    public required string RefreshToken { get; set; }

    /// <summary>
    /// The user's data.
    /// </summary>
    [JsonPropertyName("customer")]
    public required Customer Customer { get; set; }
}