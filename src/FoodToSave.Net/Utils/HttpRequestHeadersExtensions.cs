using System.Net.Http.Headers;

namespace FoodToSave.Net.Utils;

internal static class HttpRequestHeadersExtensions
{
    internal static void Add(this HttpRequestHeaders headers, FoodToSaveOptions options)
    {
        headers.Add("User-Agent", options.UserAgent);
        headers.Add("X-App-Version", options.AppVersion);
        
        headers.Add("X-Device-Os", options.DeviceMetadata.OperatingSystem);
        headers.Add("X-Device-Os-Build-Version", options.DeviceMetadata.BuildVersion);
        headers.Add("X-Device-Os-Version", options.DeviceMetadata.OperatingSystemVersion);
        headers.Add("X-Device-Model", options.DeviceMetadata.Model);
        headers.Add("X-Device-Brand", options.DeviceMetadata.Brand);
        headers.Add("X-Device-Manufacturer", options.DeviceMetadata.Manufacturer);
        headers.Add("X-Device-Ui", options.DeviceMetadata.Ui);
    }
}