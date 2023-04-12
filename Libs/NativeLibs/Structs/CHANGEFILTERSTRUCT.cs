using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// Contains extended result information obtained by calling the ChangeWindowMessageFilterEx function.
    /// https://learn.microsoft.com/en-us/windows/win32/api/winuser/ns-winuser-changefilterstruct
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct CHANGEFILTERSTRUCT
    {
        /// <summary>
        /// The size of the structure, in bytes.
        /// Must be set to sizeof(CHANGEFILTERSTRUCT), otherwise the function fails with ERROR_INVALID_PARAMETER.
        /// </summary>
        public uint cbSize;

        /// <summary>
        /// If the function succeeds, this field contains one of the following values.
        /// </summary>
        public uint ExtStatus;
    }
}