namespace Ban3.Infrastructures.NativeLibs.Enums
{
    /// <summary>
    /// The HTTP_503_RESPONSE_VERBOSITY enumeration defines the verbosity levels for a 503, service unavailable, error responses.
    /// This structure must be used when setting or querying the HttpServer503ResponseProperty on a request queue.
    /// https://learn.microsoft.com/en-us/windows/win32/api/http/ne-http-http_503_response_verbosity
    /// </summary>
    public enum HTTP_503_RESPONSE_VERBOSITY
    {
        /// <summary>
        /// A 503 response is not sent; the connection is reset.
        /// This is the default HTTP Server API behavior.
        /// </summary>
        Http503ResponseVerbosityBasic,

        /// <summary>
        /// The HTTP Server API sends a 503 response with a "Service Unavailable" reason phrase.
        /// The HTTP Server closes the TCP connection after sending the response, so the client has to re-connect.
        /// </summary>
        Http503ResponseVerbosityLimited,

        /// <summary>
        /// The HTTP Server API sends a 503 response with a detailed reason phrase.
        /// The HTTP Server closes the TCP connection after sending the response, so the client has to re-connect.
        /// </summary>
        Http503ResponseVerbosityFull
    }
}