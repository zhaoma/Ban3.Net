using System;
using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The TOKEN_LINKED_TOKEN structure contains a handle to a token. This token is linked to the token being queried by the GetTokenInformation function or set by the SetTokenInformation function.
    /// https://learn.microsoft.com/en-us/windows/win32/api/winnt/ns-winnt-token_linked_token
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct TOKEN_LINKED_TOKEN
    {
        public IntPtr LinkedToken;
    }
}