using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// Broadcast System Message
    /// Contains information about a window that denied a request from BroadcastSystemMessageEx.
    /// https://learn.microsoft.com/en-us/windows/win32/api/winuser/ns-winuser-bsminfo
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct BSMINFO
    {
        /// <summary>
        /// The size, in bytes, of this structure.
        /// </summary>
        public uint cbSize;

        /// <summary>
        /// A desktop handle to the window specified by hwnd.
        /// This value is returned only if BroadcastSystemMessageEx specifies BSF_RETURNHDESK and BSF_QUERY.
        /// </summary>
        public System.IntPtr hdesk;

        /// <summary>
        /// A handle to the window that denied the request.
        /// This value is returned if BroadcastSystemMessageEx specifies BSF_QUERY.
        /// </summary>
        public System.IntPtr hwnd;

        /// <summary>
        /// A locally unique identifier (LUID) for the window.
        /// </summary>
        public LUID luid;

    }
}