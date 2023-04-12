namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The HTTP_CONNECTION_LIMIT_INFO structure is used to set or query the limit on the maximum number of outstanding connections for a URL Group.
    /// This structure must be used when setting or querying the HttpServerConnectionsProperty on a URL Group.
    /// https://learn.microsoft.com/en-us/windows/win32/api/http/ns-http-http_connection_limit_info
    /// </summary>
    public struct HTTP_CONNECTION_LIMIT_INFO
    {
        /// <summary>
        /// The HTTP_PROPERTY_FLAGS structure specifying whether the property is present.
        /// </summary>
        public HTTP_PROPERTY_FLAGS Flags;

        /// <summary>
        /// The number of connections allowed. Setting this value to HTTP_LIMIT_INFINITE allows an unlimited number of connections.
        /// </summary>
        public uint MaxConnections;
    }
}