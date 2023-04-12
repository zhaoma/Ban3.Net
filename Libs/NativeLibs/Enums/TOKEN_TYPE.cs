namespace Ban3.Infrastructures.NativeLibs.Enums
{
    /// <summary>
    /// The TOKEN_TYPE enumeration contains values that differentiate between a primary token and an impersonation token.
    /// https://learn.microsoft.com/en-us/windows/win32/api/winnt/ne-winnt-token_type
    /// </summary>
    public enum TOKEN_TYPE
    {
        TokenPrimary = 1,
        TokenImpersonation
    }
}