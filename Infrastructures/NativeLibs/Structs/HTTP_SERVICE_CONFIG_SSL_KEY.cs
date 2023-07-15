using System;
using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The HTTP_SERVICE_CONFIG_SSL_KEY structure serves as the key by which a given Secure Sockets Layer (SSL) certificate record is identified.
    /// https://learn.microsoft.com/en-us/windows/win32/api/http/ns-http-http_service_config_ssl_key
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct HTTP_SERVICE_CONFIG_SSL_KEY
    {
        /// <summary>
        /// Pointer to a sockaddr structure that contains the Internet Protocol (IP) address with which this SSL certificate is associated.
        /// </summary>
        public IntPtr pIpPort;
    }
}