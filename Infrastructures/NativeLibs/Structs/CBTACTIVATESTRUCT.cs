using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// Contains information passed to a WH_CBT hook procedure, CBTProc, before a window is activated.
    /// https://learn.microsoft.com/en-us/windows/win32/api/winuser/ns-winuser-cbtactivatestruct
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct CBTACTIVATESTRUCT
    {
        /// <summary>
        /// This member is TRUE if a mouse click is causing the activation or FALSE if it is not.
        /// </summary>
        [MarshalAs(UnmanagedType.Bool)]
        public bool fMouse;

        /// <summary>
        /// A handle to the active window.
        /// </summary>
        public System.IntPtr hWndActive;
    }
}