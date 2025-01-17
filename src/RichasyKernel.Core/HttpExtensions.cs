// Copyright (c) Richasy. All rights reserved.
// Licensed under the MIT License.

using System.Net;
using System.Security.Authentication;

namespace RichasyKernel;

/// <summary>
/// Provides extension methods for <see cref="HttpClient"/>.
/// </summary>
public static class HttpExtensions
{
    /// <summary>
    /// Creates a new <see cref="HttpClient"/> instance with default settings.
    /// </summary>
    /// <returns><see cref="HttpClient"/>.</returns>
    public static HttpClient CreateHttpClient()
    {
        var handler = new HttpClientHandler
        {
            AllowAutoRedirect = false,
            AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate,
            SslProtocols = SslProtocols.None,
            ServerCertificateCustomValidationCallback = (_, _, _, _) => true,
        };

        return new HttpClient(handler, disposeHandler: true);
    }
}
