namespace Ban3.Infrastructures.NativeLibs.Enums
{
    /// <summary>
    /// The HTTP_REQUEST_INFO_TYPE enumeration defines the type of information contained in the HTTP_REQUEST_INFO structure.
    /// This enumeration is used in the HTTP_REQUEST_INFO structure.
    /// https://learn.microsoft.com/en-us/windows/win32/api/http/ne-http-http_request_info_type
    /// </summary>
    public enum HTTP_REQUEST_INFO_TYPE
    {
        HttpRequestInfoTypeAuth,
        HttpRequestInfoTypeChannelBind,
        HttpRequestInfoTypeSslProtocol,
        HttpRequestInfoTypeSslTokenBindingDraft,
        HttpRequestInfoTypeSslTokenBinding,
        HttpRequestInfoTypeRequestTiming,
        HttpRequestInfoTypeTcpInfoV0,
        HttpRequestInfoTypeRequestSizing,
        HttpRequestInfoTypeQuicStats,
        HttpRequestInfoTypeTcpInfoV1
    }
}