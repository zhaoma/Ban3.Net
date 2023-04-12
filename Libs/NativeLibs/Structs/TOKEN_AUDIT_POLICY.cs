using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The TOKEN_AUDIT_POLICY structure specifies the per user audit policy for a token.
    /// https://learn.microsoft.com/en-us/windows/win32/api/winnt/ns-winnt-token_audit_policy
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct TOKEN_AUDIT_POLICY
    {
        public byte[] PerUserPolicy;

    }
}