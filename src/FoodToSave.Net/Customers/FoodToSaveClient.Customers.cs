using System.Threading;
using System.Threading.Tasks;

namespace FoodToSave.Net;

public partial class FoodToSaveClient
{
    /// <summary>
    /// Gets the user's customer data.
    /// </summary>
    /// <remarks>
    /// <para>
    /// There is no endpoint to recover the entire customer data, which means that it does not perform a dedicated
    /// request, but rather recovers the cached data from the inner authentication store.
    /// </para>
    /// </remarks>
    public ValueTask<Customer> GetCustomerAsync(CancellationToken ct = default)
    {
        return _authStore.GetCustomerAsync(ct);
    }
}