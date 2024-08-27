using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;

namespace FoodToSave.Net.Authentication;

internal class AuthStore(IOptions<FoodToSaveOptions> options, IFoodToSaveAuthApi authApi) : IAuthStore
{
    private readonly AuthStoreState _state = new()
    {
        SessionId = Guid.NewGuid().ToString()
    };

    private readonly SemaphoreSlim _semaphore = new(1, 1);

    public async ValueTask<string> GetTokenAsync(CancellationToken ct = default)
    {
        if (_state.IsAuthenticated)
        {
            return _state.AuthResponse!.AccessToken;
        }

        await AuthenticateAsync(ct);
        return _state.AuthResponse!.AccessToken;
    }

    public async ValueTask<Customer> GetCustomerAsync(CancellationToken ct = default)
    {
        if (_state.IsAuthenticated)
        {
            return _state.AuthResponse!.Customer;
        }

        await AuthenticateAsync(ct);
        return _state.AuthResponse!.Customer;
    }

    public string GetSessionId()
    {
        return _state.SessionId;
    }

    private async Task AuthenticateAsync(CancellationToken ct)
    {
        await _semaphore.WaitAsync(ct);
        try
        {
            if (_state.IsAuthenticated)
            {
                return;
            }

            if (_state.AuthResponse is null)
            {
                var response = await GetNewTokenAsync(ct);
                _state.SetAuthResponse(response);
            }
            else
            {
                var response = await RefreshTokenAsync(ct);
                _state.UpdateTokens(response);
            }
        }
        finally
        {
            _semaphore.Release();
        }
    }

    private async Task<AuthResponse> GetNewTokenAsync(CancellationToken ct = default)
    {
        var request = new AuthRequest
        {
            Email = options.Value.Email, Password = options.Value.Password
        };

        var response = await authApi.AuthenticateAsync(request, ct);
        if (response.IsSuccessStatusCode)
        {
            return response.Content!;
        }

        throw AuthenticationException.New(response.Error!.Content, response.StatusCode);
    }

    private async Task<RefreshTokenResponse> RefreshTokenAsync(CancellationToken ct = default)
    {
        var request = new RefreshTokenRequest
        {
            RefreshToken = _state.AuthResponse!.RefreshToken
        };

        var response = await authApi.RefreshTokenAsync(request, ct);
        if (response.IsSuccessStatusCode)
        {
            return response.Content!;
        }

        throw AuthenticationException.New(response.Error!.Content, response.StatusCode);
    }
}

internal interface IAuthStore
{
    ValueTask<string> GetTokenAsync(CancellationToken ct = default);
    ValueTask<Customer> GetCustomerAsync(CancellationToken ct = default);
    string GetSessionId();
}