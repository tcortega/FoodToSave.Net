using System.Text.Json.Serialization;

namespace FoodToSave.Net;

/// <summary>
/// Represents a "paginated" response from the API.
/// </summary>
/// <typeparam name="T">The actual type of the response items.</typeparam>
public class ChunkedResponse<T>
{
    /// <summary>
    /// The total number of items available to be queried.
    /// </summary>
    [JsonPropertyName("count")]
    public int TotalItems { get; set; }

    /// <summary>
    /// The returned items.
    /// </summary>
    [JsonPropertyName("data")]
    public T[] Items { get; set; } = [];
}