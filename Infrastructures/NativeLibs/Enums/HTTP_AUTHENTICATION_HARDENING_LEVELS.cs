namespace Ban3.Infrastructures.NativeLibs.Enums
{
    /// <summary>
    /// Server Hardening level.
    /// https://learn.microsoft.com/en-us/windows/win32/api/http/ne-http-http_authentication_hardening_levels
    /// </summary>
    public enum HTTP_AUTHENTICATION_HARDENING_LEVELS
    {
        /// <summary>
        /// Server is not hardened and operates without Channel Binding Token (CBT) support.
        /// </summary>
        HttpAuthenticationHardeningLegacy = 0,

        /// <summary>
        /// Server is partially hardened. Clients that support CBT are serviced appropriately. Legacy clients are also serviced.
        /// </summary>
        HttpAuthenticationHardeningMedium,

        /// <summary>
        /// Server is hardened. Only clients that supported CBT are serviced.
        /// </summary>
        HttpAuthenticationHardeningStrict
    }
}