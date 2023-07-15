namespace Ban3.Infrastructures.NativeLibs.Enums
{
    /// <summary>
    /// The HTTP_RESPONSE_INFO_TYPE enumeration defines the type of information contained in the HTTP_RESPONSE_INFO structure.
    /// This enumeration is used in the HTTP_RESPONSE_INFO structure.
    /// https://learn.microsoft.com/en-us/windows/win32/api/http/ne-http-http_response_info_type
    /// </summary>
    public enum HTTP_RESPONSE_INFO_TYPE
    {
        HttpResponseInfoTypeMultipleKnownHeaders,
        HttpResponseInfoTypeAuthenticationProperty,
        HttpResponseInfoTypeQoSProperty,
        HttpResponseInfoTypeChannelBind
    }
}