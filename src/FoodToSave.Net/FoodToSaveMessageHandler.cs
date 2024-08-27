using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using FoodToSave.Net.Authentication;

namespace FoodToSave.Net;

/// <summary>
/// A <see cref="DelegatingHandler"/> that adds authentication headers to requests.
/// </summary>
internal class FoodToSaveMessageHandler(IAuthStore authStore) : DelegatingHandler
{
    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken ct)
    {
        var token = await authStore.GetTokenAsync(ct);
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
        request.Headers.Add("X-Trace-Id", Guid.NewGuid().ToString());
        request.Headers.Add("X-Session-Id", authStore.GetSessionId());
        
        return await base.SendAsync(request, ct);
    }
}