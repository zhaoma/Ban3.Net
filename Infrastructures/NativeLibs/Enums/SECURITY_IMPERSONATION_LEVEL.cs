namespace Ban3.Infrastructures.NativeLibs.Enums
{
    /// <summary>
    /// The SECURITY_IMPERSONATION_LEVEL enumeration contains values that specify security impersonation levels.
    /// Security impersonation levels govern the degree to which a server process can act on behalf of a client process.
    /// https://learn.microsoft.com/en-us/windows/win32/api/winnt/ne-winnt-security_impersonation_level
    /// </summary>
    public enum SECURITY_IMPERSONATION_LEVEL
    {
        SecurityAnonymous,
        SecurityIdentification,
        SecurityImpersonation,
        SecurityDelegation
    }
}