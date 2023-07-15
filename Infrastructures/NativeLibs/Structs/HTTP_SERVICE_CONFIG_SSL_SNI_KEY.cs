using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The HTTP_SERVICE_CONFIG_SSL_SNI_KEY structure serves as the key by which a given Secure Sockets Layer (SSL) Server Name Indication (SNI) certificate record
    /// is identified in the SSL SNI store. It appears in the HTTP_SERVICE_CONFIG_SSL_SNI_SET and the HTTP_SERVICE_CONFIG_SSL_SNI_QUERY structures,
    /// and is passed as the pConfigInformation parameter to HttpDeleteServiceConfiguration, HttpQueryServiceConfiguration,
    /// and HttpSetServiceConfiguration when the ConfigId parameter is set to HttpServiceConfigSslSniCertInfo.
    /// https://learn.microsoft.com/en-us/windows/win32/api/http/ns-http-http_service_config_ssl_sni_key
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct HTTP_SERVICE_CONFIG_SSL_SNI_KEY
    {

        /// ULONG->unsigned int
        public SOCKADDR_STORAGE IpPort;

        /// PWSTR->WCHAR*
        [MarshalAs(UnmanagedType.LPWStr)]
        public string Host;
    }
}