using Ban3.Infrastructures.NativeLibs.Enums;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The HTTP_SERVICE_CONFIG_URLACL_QUERY structure is used to specify a particular reservation record to query in the URL namespace reservation store.
    /// https://learn.microsoft.com/en-us/windows/win32/api/http/ns-http-http_service_config_urlacl_query
    /// </summary>
    public struct HTTP_SERVICE_CONFIG_URLACL_QUERY
    {

        /// DWORD->unsigned int
        public HTTP_SERVICE_CONFIG_QUERY_TYPE QueryDesc;

        /// DWORD->unsigned int
        public HTTP_SERVICE_CONFIG_URLACL_KEY KeyDesc;

        /// DWORD->unsigned int
        public uint dwToken;
    }
}