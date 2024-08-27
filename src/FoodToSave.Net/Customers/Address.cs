using System;
using System.Text.Json.Serialization;

namespace FoodToSave.Net;

/// <summary>
/// Represents an address.
/// </summary>
public record Address
{
    /// <summary>
    /// The unique identifier of the address.
    /// </summary>
    [JsonPropertyName("id")]
    public Guid Id { get; set; }
    
    /// <summary>
    /// The label of the address. Used to display the address in the UI.
    /// </summary>
    [JsonPropertyName("label")]
    public required string Label { get; set; }

    /// <summary>
    /// The zip code of the address.
    /// </summary>
    [JsonPropertyName("zip_code")]
    public required string ZipCode { get; set; }

    /// <summary>
    /// The street of the address.
    /// </summary>
    [JsonPropertyName("address")]
    public required string Street { get; set; }

    /// <summary>
    /// The complement of the address.
    /// </summary>
    /// <remarks>The address complement is optional, however, it is never null. Which is why it defaults to an empty string.</remarks>
    [JsonPropertyName("complement")]
    public string Complement { get; set; } = string.Empty;

    /// <summary>
    /// The number of the address.
    /// </summary>
    [JsonPropertyName("number")]
    public required string Number { get; set; }

    /// <summary>
    /// The district/neighborhood of the address.
    /// </summary>
    [JsonPropertyName("district")]
    public required string District { get; set; }

    /// <summary>
    /// The city of the address.
    /// </summary>
    [JsonPropertyName("city")]
    public required string City { get; set; }

    /// <summary>
    /// The state of the address.
    /// </summary>
    /// <remarks>In form of the two-letter abbreviation e.g.: ES, SP, RJ, etc.</remarks>
    [JsonPropertyName("state")]
    public required string State { get; set; }

    /// <summary>
    /// The latitude of the address.
    /// </summary>
    [JsonPropertyName("latitude")]
    public double Latitude { get; set; }

    /// <summary>
    /// The longitude of the address.
    /// </summary>
    [JsonPropertyName("longitude")]
    public double Longitude { get; set; }

    
    /// <summary>
    /// The full address, including the street, number, complement, district, city, state, zip code and country.
    /// </summary>
    [JsonPropertyName("full_address")]
    public required string FullAddress { get; set; }
}