using System;
using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The TOKEN_USER_CLAIMS structure defines the user claims for the token.
    /// https://learn.microsoft.com/en-us/windows/win32/api/winnt/ns-winnt-token_user_claims
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct TOKEN_USER_CLAIMS
    {
        public IntPtr UserClaims;
    }
}