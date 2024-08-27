using System.Threading;
using System.Threading.Tasks;
using Refit;

namespace FoodToSave.Net;

internal partial interface IFoodToSaveApi
{
    /// <summary>
    /// <para>The <c>/merchants</c> endpoint returns a list of merchants near the given location.</para>
    /// <para>The response is paginated, and the <c>limit</c> and <c>offset</c> parameters can be used to control the number of items returned and skipped.</para>
    /// </summary>
    [Get("/merchants")]
    Task<ApiResponse<ChunkedResponse<Merchant>>> GetMerchantsAsync([Query] GetMerchantsRequest request, CancellationToken ct = default);
}