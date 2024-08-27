using Refit;

namespace FoodToSave.Net;

public record GetMerchantsRequest
{
    /// <summary>
    /// The user's current latitude. The merchants returned will be within a radius from this point.
    /// </summary>
    [AliasAs("latitude")]
    public required double Latitude { get; set; }

    /// <summary>
    /// The user's current longitude. The merchants returned will be within a radius from this point.
    /// </summary>
    [AliasAs("longitude")]
    public required double Longitude { get; set; }

    /// <summary>
    /// <para>The number of items to return.</para>
    /// <para>Defaults to <c>13</c>.</para>
    /// </summary>
    /// <remarks>
    /// <para>It defaults to <c>13</c> because that's the default value used in the mobile application.</para>
    /// <para>But apparently, the api does not have a maximum limit.</para>
    /// </remarks>
    [AliasAs("limit")]
    public int Limit { get; set; } = 13;

    /// <summary>
    /// <para>The number of items to skip.</para>
    /// <para>Defaults to <c>0</c>.</para>
    /// </summary>
    [AliasAs("first")]
    public int Offset { get; set; } = 0;

    /// <summary>
    /// <para>The segments to filter the merchants by.</para>
    /// <para>Defaults to an empty array.</para>
    /// </summary>
    [AliasAs("merchant_segments")]
    public MerchantSegment[] Segments { get; set; } = [];
}