namespace Ban3.Infrastructures.NativeLibs.Enums
{
    /// <summary>
    /// The HTTP_REQUEST_AUTH_TYPE enumeration defines the authentication types supported by the HTTP Server API.
    /// This enumeration is used in the HTTP_REQUEST_AUTH_INFO structure.
    /// https://learn.microsoft.com/en-us/windows/win32/api/http/ne-http-http_request_auth_type
    /// </summary>
    public enum HTTP_REQUEST_AUTH_TYPE
    {
        HttpRequestAuthTypeNone = 0,
        HttpRequestAuthTypeBasic,
        HttpRequestAuthTypeDigest,
        HttpRequestAuthTypeNTLM,
        HttpRequestAuthTypeNegotiate,
        HttpRequestAuthTypeKerberos
    }
}