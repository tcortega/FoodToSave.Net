using System;
using System.Diagnostics.CodeAnalysis;
using System.Net;

namespace FoodToSave.Net;

/// <summary>
/// Represents an exception that occurs when the API response returns an error.
/// </summary>
/// <param name="message">The error message.</param>
/// <param name="statusCode">The response's HTTP status code.</param>
public class FoodToSaveRequestException(string? message, HttpStatusCode statusCode)
    : Exception(message ?? DefaultErrorMessage)
{
    private const string DefaultErrorMessage = "Request failed";

    public HttpStatusCode StatusCode { get; } = statusCode;

    public static FoodToSaveRequestException New(string? message, HttpStatusCode statusCode)
        => new(message, statusCode);

    [DoesNotReturn]
    public static void Throw(string? message, HttpStatusCode statusCode)
        => throw new FoodToSaveRequestException(message, statusCode);
}