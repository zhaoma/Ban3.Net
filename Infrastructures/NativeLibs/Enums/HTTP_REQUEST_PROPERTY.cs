namespace Ban3.Infrastructures.NativeLibs.Enums
{
    /// <summary>
    /// The HTTP_REQUEST_PROPERTY enumeration defines the properties that are configured by the HTTP Server API on a request.
    /// https://learn.microsoft.com/en-us/windows/win32/api/http/ne-http-http_request_property
    /// </summary>
    public enum HTTP_REQUEST_PROPERTY
    {

        HttpRequestPropertyIsb,
        HttpRequestPropertyTcpInfoV0,
        HttpRequestPropertyQuicStats,
        HttpRequestPropertyTcpInfoV1,
        HttpRequestPropertySni,
        HttpRequestPropertyStreamError,
        HttpRequestPropertyWskApiTimings,
        HttpRequestPropertyQuicApiTimings
    }
}