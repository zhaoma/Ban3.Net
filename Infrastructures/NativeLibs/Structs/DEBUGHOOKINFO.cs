using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// Contains debugging information passed to a WH_DEBUG hook procedure, DebugProc.
    /// https://learn.microsoft.com/en-us/windows/win32/api/winuser/ns-winuser-debughookinfo
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct DEBUGHOOKINFO
    {
        /// <summary>
        /// A handle to the thread containing the filter function.
        /// </summary>
        public uint idThread;

        /// <summary>
        /// A handle to the thread that installed the debugging filter function.
        /// </summary>
        public uint idThreadInstaller;

        /// <summary>
        /// The value to be passed to the hook in the lParam parameter of the DebugProc callback function.
        /// </summary>
        public int lParam;

        /// <summary>
        /// The value to be passed to the hook in the wParam parameter of the DebugProc callback function.
        /// </summary>
        public uint wParam;

        /// <summary>
        /// The value to be passed to the hook in the nCode parameter of the DebugProc callback function.
        /// </summary>
        public int code;
    }
}