using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// Defines the message parameters passed to a WH_CALLWNDPROCRET hook procedure, CallWndRetProc.
    /// https://learn.microsoft.com/en-us/windows/win32/api/winuser/ns-winuser-cwpretstruct
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct CWPRETSTRUCT
    {
        /// <summary>
        /// The return value of the window procedure that processed the message specified by the message value.
        /// </summary>
        public int lResult;

        /// <summary>
        /// Additional information about the message. The exact meaning depends on the message value.
        /// </summary>
        public int lParam;

        /// <summary>
        /// Additional information about the message. The exact meaning depends on the message value.
        /// </summary>
        public uint wParam;

        /// <summary>
        /// The message.
        /// </summary>
        public uint message;

        /// <summary>
        /// A handle to the window that processed the message specified by the message value.
        /// </summary>
        public System.IntPtr hwnd;
    }
}