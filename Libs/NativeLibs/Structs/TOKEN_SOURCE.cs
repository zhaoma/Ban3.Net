using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The TOKEN_SOURCE structure identifies the source of an access token.
    /// https://learn.microsoft.com/en-us/windows/win32/api/winnt/ns-winnt-token_source
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct TOKEN_SOURCE
    {
        /// CHAR[8]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 8)]
        public string SourceName;

        /// LUID->_LUID
        public LUID SourceIdentifier;
    }
}