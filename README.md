# FoodToSave.Net

## What is FoodToSave.Net?
FoodToSave.Net is an unofficial library for interacting with [FoodToSave's](https://www.foodtosave.com.br/) mobile APIs.
Currently, there are no available documentation for the API, so this library is based on reverse engineering research I
did on the mobile app.
It is supported for .NET Standard 2.0, .NET Core 3.1, and .NET 5.0+.

### Where can I get it?
FoodToSave.Net has not been published to NuGet yet, but you can download the source code and build it yourself.

### How it works?
You can make all calls to FoodToSave's API via the `FoodToSave.Net.FoodToSaveClient` class.

```c#
var options = new FoodToSaveOptions() 
{
    Email = "your@email.com",
    Password = "your-password"
};

// Required since we consume from the IOptions<> pattern.
var optionsWrapper = new OptionsWrapper(options);
var client = new FoodToSaveClient(options);

var customer = await client.GetCustomerAsync();
var address = customer.Addresses[0];

var request = new GetMerchantsRequest
{
    Latitude = address.Latitude,
    Longitude = address.Longitude
};

var merchants = await client.GetMerchantsAsync(request);
```

### Usage
You may provide an `email` and `password` to the options to initialize the client.

```c#
var options = new FoodToSaveOptions() 
{
    Email = "your@email.com",
    Password = "your-password"
};
```

For the full list of options, please visit [FoodToSaveOptions.cs](https://github.com/tcortega/FoodToSave.Net/blob/master/src/FoodToSave.Net/FoodToSaveOptions.cs).

### .NET Core Configuration Options

#### Easy to use:

Call `services.AddFoodToSave(IConfigurationRoot)` or `services.AddFoodToSave(IConfiguration)`. This will automatically bind options from the
provided configuration section or the `FoodToSave` section of the root; configure a named `HttpClient` for `FoodToSaveClient`; and configure `FoodToSaveClient` as a singleton.

#### `IOptions` Support

FoodToSave.Net supports configuration from any configuration source via the `IOptions` pattern.
You can provide any configuration section to `.AddFoodToSave()` and the options will be automatically bound.
Alternatively, you may call `services.Configure<FoodToSaveOptions>();` to configure the `FoodToSaveOptions` manually.
Once done, you can then add `FoodToSaveClient` as a singleton by calling `services.AddFoodToSaveClient()`.

## API Version

FoodToSave.Net currently targets FoodToSave API version `v1`, my research was conducted on `2024-08-27`.