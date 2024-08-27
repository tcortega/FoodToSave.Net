using System.Threading;
using System.Threading.Tasks;
using Refit;

namespace FoodToSave.Net;

public partial class FoodToSaveClient
{
    /// <summary>
    /// <para>The <c>/merchants</c> endpoint returns a list of merchants near the given location.</para>
    /// <para>The response is paginated, and the <c>limit</c> and <c>offset</c> parameters can be used to control the number of items returned and skipped.</para>
    /// </summary>
    /// <exception cref="FoodToSaveRequestException">Thrown when the request fails.</exception>
    /// <exception cref="ApiException">Thrown when the request fails.</exception>
    public async Task<ChunkedResponse<Merchant>> GetMerchantsAsync(GetMerchantsRequest request,
        CancellationToken ct = default)
    {
        var response = await _api.GetMerchantsAsync(request, ct);
        if (response.IsSuccessStatusCode)
        {
            return response.Content!;
        }

        throw FoodToSaveRequestException.New(response.Error!.Content, response.StatusCode);
    }
}