namespace Ban3.Infrastructures.NativeLibs.Enums
{
    /// <summary>
    /// The HTTP_SERVICE_CONFIG_TIMEOUT_KEY enumeration defines the type of timer that is queried or configured through the HTTP_SERVICE_CONFIG_TIMEOUT_SET structure.
    /// https://learn.microsoft.com/en-us/windows/win32/api/http/ne-http-http_service_config_timeout_key
    /// </summary>
    public enum HTTP_SERVICE_CONFIG_TIMEOUT_KEY
    {
        IdleConnectionTimeout = 0,
        HeaderWaitTimeout
    }
}