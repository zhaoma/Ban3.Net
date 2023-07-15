namespace Ban3.Infrastructures.NativeLibs.Enums
{
    /// <summary>
    /// The HTTP_SERVICE_CONFIG_ID enumeration type defines service configuration options.
    /// https://learn.microsoft.com/en-us/windows/win32/api/http/ne-http-http_service_config_id
    /// </summary>
    public enum HTTP_SERVICE_CONFIG_ID
    {
        HttpServiceConfigIPListenList,
        HttpServiceConfigSSLCertInfo,
        HttpServiceConfigUrlAclInfo,
        HttpServiceConfigTimeout,
        HttpServiceConfigCache,
        HttpServiceConfigSslSniCertInfo,
        HttpServiceConfigSslCcsCertInfo,
        HttpServiceConfigSetting,
        HttpServiceConfigSslCertInfoEx,
        HttpServiceConfigSslSniCertInfoEx,
        HttpServiceConfigSslCcsCertInfoEx,
        HttpServiceConfigSslScopedCcsCertInfo,
        HttpServiceConfigSslScopedCcsCertInfoEx,
        HttpServiceConfigMax
    }
}