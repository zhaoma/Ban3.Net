namespace Ban3.Infrastructures.NativeLibs.Enums
{
    /// <summary>
    /// The SECURITY_LOGON_TYPE enumeration indicates the type of logon requested by a logon process.
    /// https://learn.microsoft.com/en-us/windows/win32/api/ntsecapi/ne-ntsecapi-security_logon_type
    /// </summary>
    public enum SECURITY_LOGON_TYPE
    {
        UndefinedLogonType = 0,
        Interactive = 2,
        Network,
        Batch,
        Service,
        Proxy,
        Unlock,
        NetworkCleartext,
        NewCredentials,
        RemoteInteractive,
        CachedInteractive,
        CachedRemoteInteractive,
        CachedUnlock
    }
}