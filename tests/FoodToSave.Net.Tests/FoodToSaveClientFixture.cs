using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FoodToSave.Net.Tests;

[CollectionDefinition(nameof(FoodToSaveClientFixture))]
public class FoodToSaveClientCollection : ICollectionFixture<FoodToSaveClientFixture>;

public class FoodToSaveClientFixture : IAsyncLifetime
{
    public FoodToSaveClient Client { get; }
    public Address Address { get; private set; } = null!;

    public FoodToSaveClientFixture()
    {
        var configuration = new ConfigurationBuilder()
            .AddUserSecrets(Assembly.GetExecutingAssembly())
            .Build();

        var services = new ServiceCollection();
        services.AddFoodToSaveApi(configuration);

        var sp = services.BuildServiceProvider();

        Client = sp.GetRequiredService<FoodToSaveClient>();
    }

    public async Task InitializeAsync()
    {
        var customer = await Client.GetCustomerAsync();
        Address = customer.Addresses[0];
    }

    public Task DisposeAsync()
        => Task.CompletedTask;
}