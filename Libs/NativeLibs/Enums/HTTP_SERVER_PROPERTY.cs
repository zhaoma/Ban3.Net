namespace Ban3.Infrastructures.NativeLibs.Enums
{
    /// <summary>
    /// The HTTP_SERVER_PROPERTY enumeration defines the properties that are configured by the HTTP Server API on a URL group, server session, or request queue.
    /// https://learn.microsoft.com/en-us/windows/win32/api/http/ne-http-http_server_property
    /// </summary>
    public enum HTTP_SERVER_PROPERTY
    {
        HttpServerAuthenticationProperty = 0,
        HttpServerLoggingProperty = 1,
        HttpServerQosProperty = 2,
        HttpServerTimeoutsProperty = 3,
        HttpServerQueueLengthProperty = 4,
        HttpServerStateProperty = 5,
        HttpServer503VerbosityProperty = 6,
        HttpServerBindingProperty = 7,
        HttpServerExtendedAuthenticationProperty = 8,
        HttpServerListenEndpointProperty = 9,
        HttpServerChannelBindProperty = 10,
        HttpServerProtectionLevelProperty = 11,
        HttpServerDelegationProperty
    }
}