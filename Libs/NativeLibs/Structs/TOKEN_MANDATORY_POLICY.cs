using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The TOKEN_MANDATORY_POLICY structure specifies the mandatory integrity policy for a token.
    /// https://learn.microsoft.com/en-us/windows/win32/api/winnt/ns-winnt-token_mandatory_policy
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct TOKEN_MANDATORY_POLICY
    {
        public uint Policy;
    }
}