namespace Ban3.Infrastructures.NativeLibs.Enums
{
    /// <summary>
    /// The HTTP_SERVICE_BINDING_TYPE enumerated type specifies the string type for service names.
    /// https://learn.microsoft.com/en-us/windows/win32/api/http/ne-http-http_service_binding_type
    /// </summary>
    public enum HTTP_SERVICE_BINDING_TYPE
    {
        HttpServiceBindingTypeNone = 0,
        HttpServiceBindingTypeW,
        HttpServiceBindingTypeA
    }
}