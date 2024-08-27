using System;
using System.Text.Json.Serialization;

namespace FoodToSave.Net;

public record Favorite
{
    /// <summary>
    /// The merchant's unique identifier.
    /// </summary>
    [JsonPropertyName("id")]
    public Guid Id { get; set; }

    /// <summary>
    /// Whether takeout is available for this merchant.
    /// </summary>
    [JsonPropertyName("takeout_enabled")]
    public bool TakeoutEnabled { get; set; }

    /// <summary>
    /// Whether delivery is available for this merchant.
    /// </summary>
    [JsonPropertyName("delivery_enabled")]
    public bool DeliveryEnabled { get; set; }

    /// <summary>
    /// Whether delivery surcharge is available for this merchant.
    /// </summary>
    [JsonPropertyName("delivery_surcharge_enabled")]
    public bool DeliverySurchargeEnabled { get; set; }
}