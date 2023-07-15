using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The TOKEN_ORIGIN structure contains information about the origin of the logon session. This structure is used by the GetTokenInformation function.
    /// https://learn.microsoft.com/en-us/windows/win32/api/winnt/ns-winnt-token_origin
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct TOKEN_ORIGIN
    {
        public LUID OriginatingLogonSession;
    }
}