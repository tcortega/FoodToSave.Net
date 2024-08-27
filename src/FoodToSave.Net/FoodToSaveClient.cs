using System;
using System.Net.Http;
using CommunityToolkit.Diagnostics;
using FoodToSave.Net.Authentication;
using FoodToSave.Net.Utils;
using Microsoft.Extensions.Options;
using Refit;

namespace FoodToSave.Net;

/// <summary>
/// The FoodToSave API client.
/// </summary>
public sealed partial class FoodToSaveClient
{
    private readonly IFoodToSaveApi _api;
    private readonly IAuthStore _authStore;

    /// <summary>
    /// Initializes a new instance of the <see cref="FoodToSaveClient"/> class.
    /// </summary>
    /// <param name="options">The client options.</param>
    public FoodToSaveClient(IOptions<FoodToSaveOptions> options)
    {
        Guard.IsNotNull(options);
        options.Value.Validate();

        _authStore = CreateAuthStore(options);
        _api = RestService.For<IFoodToSaveApi>(CreateHttpClient(options));
    }

    internal FoodToSaveClient(IAuthStore authStore, IFoodToSaveApi refitApi)
    {
        _api = refitApi;
        _authStore = authStore;
    }

    private static AuthStore CreateAuthStore(IOptions<FoodToSaveOptions> options)
    {
        var authApiClient = new HttpClient
        {
            BaseAddress = new Uri(options.Value.BaseUrl)
        };
        authApiClient.DefaultRequestHeaders.Add(options.Value);
        var authApi = RestService.For<IFoodToSaveAuthApi>(authApiClient);

        return new AuthStore(options, authApi);
    }

    private HttpClient CreateHttpClient(IOptions<FoodToSaveOptions> options)
    {
        var handler = new FoodToSaveMessageHandler(_authStore);
        var httpClient = new HttpClient(handler);
        httpClient.DefaultRequestHeaders.Add(options.Value);

        return httpClient;
    }
}

internal partial interface IFoodToSaveApi;