namespace FoodToSave.Net.Tests;

[Collection(nameof(FoodToSaveClientFixture))]
public class MerchantTests(FoodToSaveClientFixture fixture)
{
    private readonly FoodToSaveClient _client = fixture.Client;
    private readonly Address _address = fixture.Address;
    
    [Fact]
    public async Task GetMerchants_ShouldReturnValidResponse()
    {
        var request = new GetMerchantsRequest
        {
            Latitude = _address.Latitude,
            Longitude = _address.Longitude
        };
        
        var response = await _client.GetMerchantsAsync(request);
        Assert.NotNull(response);
        Assert.NotEmpty(response.Items);
    }

    [Fact]
    public async Task GetMerchants_WithLimitedItems_ShouldReturnExactlyLimitedItems()
    {
        var randomItemLimit = Random.Shared.Next(1, 10);
        var request = new GetMerchantsRequest
        {
            Latitude = _address.Latitude,
            Longitude = _address.Longitude,
            Limit = randomItemLimit
        };
        var response = await _client.GetMerchantsAsync(request);
        Assert.NotNull(response);
        Assert.Equal(randomItemLimit, response.Items.Length);
    }

    [Fact]
    public async Task GetMerchants_FilteredBySegment_ShouldReturnMerchantsWithMatchingSegment()
    {
        var request = new GetMerchantsRequest
        {
            Latitude = _address.Latitude,
            Longitude = _address.Longitude,
            Segments = [MerchantSegment.Mercado]
        };
        
        var response = await _client.GetMerchantsAsync(request);
        Assert.NotNull(response);
        Assert.NotEmpty(response.Items);
        Assert.All(response.Items, m => Assert.Equal(MerchantSegment.Mercado, m.Segment));
    }
}