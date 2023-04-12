namespace Ban3.Infrastructures.NativeLibs.Enums
{
    /// <summary>
    /// The POLICY_SERVER_ENABLE_STATE enumeration represents the state of the LSA server—that is, whether it is enabled or disabled. Some operations may only be performed on an enabled LSA server.
    /// https://learn.microsoft.com/en-us/windows/win32/api/ntsecapi/ne-ntsecapi-policy_server_enable_state
    /// </summary>
    public enum POLICY_SERVER_ENABLE_STATE
    {
        /// <summary>
        /// The LSA server is enabled.
        /// </summary>
        PolicyServerEnabled = 2,

        /// 
        PolicyServerDisabled
    }
}