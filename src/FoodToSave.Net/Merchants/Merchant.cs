using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace FoodToSave.Net;

/// <summary>
/// Represents a store/merchant.
/// </summary>
public class Merchant
{
    /// <summary>
    /// The unique identifier of the merchant.
    /// </summary>
    public required Guid Id { get; set; }

    /// <summary>
    /// The name of the merchant.
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// The email address of the merchant.
    /// </summary>
    public required string Email { get; set; }

    /// <summary>
    /// The phone number of the merchant.
    /// </summary>
    public required string Phone { get; set; }

    /// <summary>
    /// The document number of the merchant.
    /// </summary>
    /// <remarks>
    /// This is usually a CNPJ.
    /// </remarks>
    public required string Document { get; set; }

    /// <summary>
    /// The URL of the merchant's logo.
    /// </summary>
    [JsonPropertyName("logo_url")]
    public Uri? LogoUrl { get; set; }

    /// <summary>
    /// The URL of the merchant's banner.
    /// </summary>
    [JsonPropertyName("banner_url")]
    public Uri? BannerUrl { get; set; }

    /// <summary>
    /// The name of the merchant's company.
    /// </summary>
    [JsonPropertyName("company_name")]
    public required string CompanyName { get; set; }

    /// <summary>
    /// The address of the merchant.
    /// </summary>
    public required Address Address { get; set; }

    /// <summary>
    /// Whether takeout is enabled for this merchant.
    /// </summary>
    [JsonPropertyName("takeout_enabled")]
    public bool TakeoutEnabled { get; set; }

    /// <summary>
    /// Whether delivery is enabled for this merchant.
    /// </summary>
    [JsonPropertyName("delivery_enabled")]
    public bool DeliveryEnabled { get; set; }


    /// <summary>
    /// Whether delivery is available for this merchant.
    /// </summary>
    [JsonPropertyName("delivery_available")]
    public bool DeliveryAvailable { get; set; }

    /// <summary>
    /// The maximum distance in kilometers that the merchant allows for delivery.
    /// </summary>
    [JsonPropertyName("delivery_max_distance")]
    public int DeliveryMaxDistance { get; set; }

    /// <summary>
    /// The minimum distance in kilometers that the merchant allows for delivery.
    /// </summary>
    [JsonPropertyName("delivery_min_distance")]
    public int DeliveryMinDistance { get; set; }

    // TODO: This is probably an enum.
    /// <summary>
    /// The type of fee that the merchant charges for delivery.
    /// </summary>
    [JsonPropertyName("delivery_fee_type")]
    public required string DeliveryFeeType { get; set; }

    /// <summary>
    /// The minimum fee that the merchant charges for delivery.
    /// </summary>
    [JsonPropertyName("delivery_minimum_fee")]
    public decimal DeliveryMinimumFee { get; set; }

    /// <summary>
    /// Whether the merchant charges a surcharge for delivery.
    /// </summary>
    [JsonPropertyName("delivery_surcharge_enabled")]
    public bool DeliverySurchargeEnabled { get; set; }

    /// <summary>
    /// The segment of the merchant.
    /// </summary>
    [JsonPropertyName("segment")]
    public required MerchantSegment Segment { get; set; }

    /// <summary>
    /// The distance in kilometers from the user's location to the merchant.
    /// </summary>
    [JsonPropertyName("distance")]
    public decimal Distance { get; set; }

    /// <summary>
    /// The time range when takeout is available.
    /// </summary>
    [JsonPropertyName("takeout_time")]
    public required string TakeoutTime { get; set; }

    /// <summary>
    /// The time when takeout starts.
    /// </summary>
    [JsonPropertyName("takeout_start_hour")]
    public required string TakeoutStartHour { get; set; }

    /// <summary>
    /// The time when takeout ends.
    /// </summary>
    [JsonPropertyName("takeout_limit_hour")]
    public required string TakeoutLimitHour { get; set; }

    /// <summary>
    /// The time when delivery ends.
    /// </summary>
    [JsonPropertyName("delivery_limit_hour")]
    public required string DeliveryLimitHour { get; set; }

    /// <summary>
    /// There is not enough information about this.
    /// </summary>
    [JsonPropertyName("cancel_limit_hour")]
    public required string CancelLimitHour { get; set; }

    /// <summary>
    /// The description of the merchant.
    /// </summary>
    [JsonPropertyName("description")]
    public required string Description { get; set; }

    /// <summary>
    /// Whether the user has marked this merchant as a favorite.
    /// </summary>
    [JsonPropertyName("favorite")]
    public bool Favorite { get; set; }

    /// <summary>
    /// The lowest price available for this merchant's products.
    /// </summary>
    [JsonPropertyName("lower_price_available")]
    public decimal LowerPriceAvailable { get; set; }

    /// <summary>
    /// The reference price of the lowest price available for this merchant's products.
    /// </summary>
    [JsonPropertyName("lower_reference_price_available")]
    public decimal LowerReferencePriceAvailable { get; set; }

    /// <summary>
    /// The total number of bags available for purchase for this merchant.
    /// </summary>
    [JsonPropertyName("total_bags_available")]
    public int TotalBagsAvailable { get; set; }

    /// <summary>
    /// The average rating of this merchant.
    /// </summary>
    [JsonPropertyName("evaluation_average")]
    public decimal EvaluationAverage { get; set; }

    /// <summary>
    /// The number of ratings for this merchant.
    /// </summary>
    [JsonPropertyName("evaluation_count")]
    public int EvaluationCount { get; set; }

    /// <summary>
    /// Whether this merchant is a top saver.
    /// </summary>
    [JsonPropertyName("top_saver")]
    public bool TopSaver { get; set; }

    /// <summary>
    /// The time zone of the merchant.
    /// </summary>
    /// <remarks>
    /// This is usually America/Sao_Paulo.
    /// </remarks>
    [JsonPropertyName("time_zone")]
    public required string TimeZone { get; set; }

    // TODO: This is probably an enum.
    /// <summary>
    /// The tags of the merchant.
    /// </summary>
    [JsonPropertyName("tags")]
    public List<string>? Tags { get; set; }

    /// <summary>
    /// The special instructions for takeout.
    /// </summary>
    [JsonPropertyName("takeout_instruction")]
    public string? TakeoutInstruction { get; set; }
}