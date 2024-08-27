using System;
using System.Diagnostics.CodeAnalysis;
using System.Net;

namespace FoodToSave.Net;

/// <summary>
/// Represents an exception that occurs when the authentication fails.
/// </summary>
/// <param name="message">The error message.</param>
/// <param name="statusCode">The response's HTTP status code.</param>
public class AuthenticationException(string? message, HttpStatusCode statusCode)
    : Exception(message ?? DefaultErrorMessage)
{
    private const string DefaultErrorMessage = "Authentication failed";

    public HttpStatusCode StatusCode { get; } = statusCode;

    /// <summary>
    /// Creates a new instance of the <see cref="AuthenticationException"/> class.
    /// </summary>
    public static AuthenticationException New(string? message, HttpStatusCode statusCode)
        => new(message, statusCode);

    /// <summary>
    /// Throws a <see cref="AuthenticationException"/>.
    /// </summary>
    [DoesNotReturn]
    public static void Throw(string? message, HttpStatusCode statusCode)
        => throw new AuthenticationException(message, statusCode);
}