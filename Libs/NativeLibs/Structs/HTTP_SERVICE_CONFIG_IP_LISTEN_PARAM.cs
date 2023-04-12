namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The HTTP_SERVICE_CONFIG_IP_LISTEN_PARAM structure is used to specify an IP address to be added to or deleted from the list of IP addresses to which the HTTP service binds.
    /// https://learn.microsoft.com/en-us/windows/win32/api/http/ns-http-http_service_config_ip_listen_param
    /// </summary>
    public struct HTTP_SERVICE_CONFIG_IP_LISTEN_PARAM
    {
        /// USHORT->unsigned short
        public ushort AddrLength;

        /// PSOCKADDR->sockaddr*
        public System.IntPtr pAddress;
    }
}