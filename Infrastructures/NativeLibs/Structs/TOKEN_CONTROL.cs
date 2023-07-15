using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The TOKEN_CONTROL structure contains information that identifies an access token.
    /// https://learn.microsoft.com/en-us/windows/win32/api/winnt/ns-winnt-token_control
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct TOKEN_CONTROL
    {

        /// LUID->_LUID
        public LUID TokenId;

        /// LUID->_LUID
        public LUID AuthenticationId;

        /// LUID->_LUID
        public LUID ModifiedId;

        /// TOKEN_SOURCE->_TOKEN_SOURCE
        public TOKEN_SOURCE TokenSource;
    }
}