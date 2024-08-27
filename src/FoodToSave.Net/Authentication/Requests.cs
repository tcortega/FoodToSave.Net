using System.Text.Json.Serialization;

namespace FoodToSave.Net.Authentication;

/// <summary>
/// Represents the request to authenticate the user.
/// </summary>
public record AuthRequest
{
    /// <summary>
    /// The user's email address.
    /// </summary>
    public required string Email { get; set; }
    
    /// <summary>
    /// The user's password.
    /// </summary>
    public required string Password { get; set; }
}

/// <summary>
/// Represents the request to refresh the user's token.
/// </summary>
public record RefreshTokenRequest
{
    /// <summary>
    /// The user's refresh token.
    /// </summary>
    [JsonPropertyName("refresh_token")]
    public required string RefreshToken { get; set; }
}
