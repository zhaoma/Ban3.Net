using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The TOKEN_MANDATORY_LABEL structure specifies the mandatory integrity level for a token.
    /// https://learn.microsoft.com/en-us/windows/win32/api/winnt/ns-winnt-token_mandatory_label
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct TOKEN_MANDATORY_LABEL
    {
        public SID_AND_ATTRIBUTES Label;
    }
}