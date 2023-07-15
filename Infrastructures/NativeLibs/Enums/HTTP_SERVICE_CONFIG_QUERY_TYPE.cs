namespace Ban3.Infrastructures.NativeLibs.Enums
{
    /// <summary>
    /// The HTTP_SERVICE_CONFIG_QUERY_TYPE enumeration type defines various types of queries to make.
    /// It is used in the HTTP_SERVICE_CONFIG_SSL_QUERY, HTTP_SERVICE_CONFIG_SSL_CCS_QUERY, and HTTP_SERVICE_CONFIG_URLACL_QUERY structures.
    /// https://learn.microsoft.com/en-us/windows/win32/api/http/ne-http-http_service_config_query_type
    /// </summary>
    public enum HTTP_SERVICE_CONFIG_QUERY_TYPE
    {
        HttpServiceConfigQueryExact,
        HttpServiceConfigQueryNext,
        HttpServiceConfigQueryMax
    }
}