namespace Ban3.Infrastructures.NativeLibs.Enums
{
    /// <summary>
    /// The HTTP_ENABLED_STATE enumeration defines the state of a request queue, server session, or URL Group.
    /// This enumeration is used in the HTTP_STATE_INFO struct
    /// https://learn.microsoft.com/en-us/windows/win32/api/http/ne-http-http_enabled_state
    /// </summary>
    public enum HTTP_ENABLED_STATE
    {
        /// <summary>
        /// The HTTP Server API object is enabled.
        /// </summary>
        HttpEnabledStateActive,

        /// <summary>
        /// The HTTP Server API object is disabled.
        /// </summary>
        HttpEnabledStateInactive
    }
}