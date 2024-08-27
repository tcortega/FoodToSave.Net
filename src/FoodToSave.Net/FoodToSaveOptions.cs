using CommunityToolkit.Diagnostics;
using Microsoft.Extensions.Configuration;

namespace FoodToSave.Net;

/// <summary>
/// Implements the IOptions pattern for reading a 'FoodToSave' section from an <see cref="IConfiguration"/> object.
/// </summary>
public class FoodToSaveOptions
{
    /// <summary>
    /// A default name in the IConfiguration that contains FoodToSaveOptions settings
    /// </summary>
    /// <remarks>
    /// Section name in configuration is configurable. This default is offered for
    /// convenience only.
    /// </remarks>
    public const string SectionKey = "FoodToSave";

    /// <summary>
    /// The email that will be used to authenticate.
    /// </summary>
    public required string Email { get; set; } = null!;

    /// <summary>
    /// The password that will be used to authenticate.
    /// </summary>
    public required string Password { get; set; } = null!;

    /// <summary>
    /// <para>The base URL for the FoodToSave API.</para>
    /// <para>Defaults to <c>https://api.foodtosave.com.br/api/v1</c>.</para>
    /// </summary>
    public string BaseUrl { get; set; } = "https://api.foodtosave.com.br/api/v1";

    /// <summary>
    /// <para>The user agent sent to the API.</para>
    /// <para>Defaults to <c>Dart/3.4 (dart:io)</c>.</para>
    /// </summary>
    public string UserAgent { get; set; } = "Dart/3.4 (dart:io)";

    /// <summary>
    /// <para>The app version sent to the API via the <c>x-app-version</c> header.</para>
    /// <para>Defaults to <c>3.4.3</c>.</para>
    /// </summary>
    public string AppVersion { get; set; } = "3.4.3";

    /// <summary>
    /// The device metadata sent to the API via the <c>x-device-*</c> headers.
    /// </summary>
    public DeviceMetadata DeviceMetadata { get; set; } = new();
}

/// <summary>
/// Represents metadata about the device making a request.
/// This includes information about the device's operating system, model, app version, and more.
/// </summary>
public record DeviceMetadata
{
    /// <summary>
    /// <para>The operating system name of the device sent to the API via the <c>x-device-os</c> header.</para>
    /// <para>Defaults to <c>android</c>.</para>
    /// </summary>
    public string OperatingSystem { get; set; } = "android";

    /// <summary>
    /// <para>The Ui type of the device sent to the API via the <c>x-device-ui</c> header.</para>
    /// <para>Defaults to <c>normal</c>.</para>
    /// </summary>
    public string Ui { get; set; } = "normal";

    /// <summary>
    /// <para>The OS build identifier of the device sent to the API via the <c>x-device-os-build-version</c> header.</para>
    /// <para>Defaults to <c>224</c>.</para>
    /// </summary>
    /// <remarks>
    /// On android devices, it derives from system properties like Build.ID or Build.VERSION.INCREMENTAL.
    /// </remarks>
    public string BuildVersion { get; set; } = "224";

    /// <summary>
    /// <para>The OS version of the device sent to the API via the <c>x-device-os-version</c> header.</para>
    /// <para>Defaults to <c>SKQ1.211019.001 test-keys</c>.</para>
    /// </summary>
    /// <remarks>
    /// On android devices, this usually corresponds to the android version and includes a unique build identifier.
    /// It is derived from system properties like Build.VERSION.RELEASE or Build.DISPLAY.
    /// </remarks>
    public string OperatingSystemVersion { get; set; } = "SKQ1.211019.001 test-keys";

    /// <summary>
    /// <para>The model of the device sent to the API via the <c>x-device-model</c> header.</para>
    /// <para>Defaults to <c>Redmi Note 9S</c>.</para>
    /// </summary>
    public string Model { get; set; } = "Redmi Note 9S";

    /// <summary>
    /// <para>The brand of the device sent to the API via the <c>x-device-brand</c> header.</para>
    /// <para>Defaults to <c>Android</c>.</para>
    /// </summary>
    public string Brand { get; set; } = "Android";

    /// <summary>
    /// <para>The manufacturer of the device sent to the API via the <c>x-device-manufacturer</c> header.</para>
    /// <para>Defaults to <c>Xiaomi</c>.</para>
    /// </summary>
    public string Manufacturer { get; set; } = "Xiaomi";
}

internal static class FoodToSaveOptionsExtensions
{
    internal static void Validate(this FoodToSaveOptions o)
    {
        Guard.IsNotNullOrEmpty(o.Email, "FoodToSave Email");
        Guard.IsNotNullOrEmpty(o.Password, "FoodToSave Password");

        Guard.IsNotNullOrEmpty(o.BaseUrl, "FoodToSave BaseUrl");
        Guard.IsNotNullOrEmpty(o.AppVersion, "FoodToSave AppVersion");
        Guard.IsNotNullOrEmpty(o.UserAgent, "FoodToSave UserAgent");
        Guard.IsNotNull(o.DeviceMetadata, "FoodToSave DeviceMetadata");
        Guard.IsNotNullOrWhiteSpace(o.DeviceMetadata.Manufacturer, "FoodToSave DeviceMetadata.Manufacturer");
        Guard.IsNotNullOrWhiteSpace(o.DeviceMetadata.Model, "FoodToSave DeviceMetadata.Model");
        Guard.IsNotNullOrWhiteSpace(o.DeviceMetadata.Brand, "FoodToSave DeviceMetadata.Brand");
        Guard.IsNotNullOrWhiteSpace(o.DeviceMetadata.Ui, "FoodToSave DeviceMetadata.Ui");
        Guard.IsNotNullOrWhiteSpace(o.DeviceMetadata.OperatingSystem, "FoodToSave DeviceMetadata.OperatingSystem");
        Guard.IsNotNullOrWhiteSpace(o.DeviceMetadata.BuildVersion, "FoodToSave DeviceMetadata.BuildVersion");
        Guard.IsNotNullOrWhiteSpace(o.DeviceMetadata.OperatingSystemVersion,
            "FoodToSave DeviceMetadata.OperatingSystemVersion");
    }
}