using System.Threading;
using System.Threading.Tasks;
using Refit;

namespace FoodToSave.Net.Authentication;

/// <summary>
/// The FoodToSave authentication API.
/// </summary>
/// <remarks>
/// This interface is used internally and automatically by the <see cref="FoodToSaveClient"/>. It is not meant to be used directly.
/// However, it is publicly exposed for the sake of completeness.
/// </remarks>
public interface IFoodToSaveAuthApi
{
    /// <summary>
    /// Authenticates the user.
    /// </summary>
    /// <returns></returns>
    [Post("/authentication")]
    Task<ApiResponse<AuthResponse>> AuthenticateAsync([Body] AuthRequest request, CancellationToken ct = default);

    /// <summary>
    /// Refreshes the user's token.
    /// </summary>
    [Post("/authentication/refresh-token")]
    Task<ApiResponse<RefreshTokenResponse>> RefreshTokenAsync([Body] RefreshTokenRequest request,
        CancellationToken ct = default);
}