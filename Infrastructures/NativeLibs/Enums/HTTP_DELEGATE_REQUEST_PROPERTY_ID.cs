namespace Ban3.Infrastructures.NativeLibs.Enums
{
    /// <summary>
    /// Defines constants that specify a type of property information for a delegate request.
    /// https://learn.microsoft.com/en-us/windows/win32/api/http/ne-http-http_delegate_request_property_id
    /// </summary>
    public enum HTTP_DELEGATE_REQUEST_PROPERTY_ID
    {
        /// <summary>
        /// This property is reserved.
        /// </summary>
        DelegateRequestReservedProperty,

        /// <summary>
        /// Specifies the property that provides the target url to which a delegated request should be delivered.
        /// </summary>
        DelegateRequestDelegateUrlProperty
    }
}