using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace FoodToSave.Net;

/// <summary>
/// Represents the user's information.
/// </summary>
public record Customer
{
    /// <summary>
    /// The user's unique identifier.
    /// </summary>
    [JsonPropertyName("id")]
    public Guid Id { get; set; }

    /// <summary>
    /// The user's name.
    /// </summary>
    [JsonPropertyName("name")]
    public required string Name { get; set; }

    
    /// <summary>
    /// The user's document number. It is usually a CPF.
    /// </summary>
    [JsonPropertyName("document")]
    public required string Document { get; set; }

    /// <summary>
    /// The user's email address.
    /// </summary>
    [JsonPropertyName("email")]
    public required string Email { get; set; }

    
    /// <summary>
    /// The user's phone number. E.g.: <c>+5511999999999</c>
    /// </summary>
    [JsonPropertyName("phone")]
    public required string Phone { get; set; }

    /// <summary>
    /// Indicates whether the user's phone number has been confirmed.
    /// </summary>
    [JsonPropertyName("phone_confirmed")]
    public bool PhoneConfirmed { get; set; }

    /// <summary>
    /// Indicates whether the user's email address has been confirmed.
    /// </summary>
    [JsonPropertyName("email_confirmed")]
    public bool EmailConfirmed { get; set; }

    
    /// <summary>
    /// Indicates whether the user wants to receive notifications.
    /// </summary>
    [JsonPropertyName("accept_notifications")]
    public bool AcceptNotifications { get; set; }

    /// <summary>
    /// The user's push token. It is used to send push notifications.
    /// </summary>
    [JsonPropertyName("push_token")]
    public string? PushToken { get; set; }

    /// <summary>
    /// The user's status.
    /// </summary>
    [JsonPropertyName("status")]
    public required string Status { get; set; }

    /// <summary>
    /// The user's addresses.
    /// </summary>
    [JsonPropertyName("addresses")]
    public required List<Address> Addresses { get; set; }

    // TODO: Add Card Type
    /// <summary>
    /// The user's registered credit cards.
    /// </summary>
    [JsonPropertyName("cards")]
    public required List<object> Cards { get; set; }

    /// <summary>
    /// The user's favorite merchants.
    /// </summary>
    [JsonPropertyName("favorites")]
    public required List<Favorite> Favorites { get; set; }

    /// <summary>
    /// The date and time when the user registered.
    /// </summary>
    [JsonPropertyName("created_at")]
    public DateTimeOffset CreatedAt { get; set; }
}