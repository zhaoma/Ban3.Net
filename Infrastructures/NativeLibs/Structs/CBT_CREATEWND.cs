using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// Contains information passed to a WH_CBT hook procedure, CBTProc, before a window is created.
    /// https://learn.microsoft.com/en-us/windows/win32/api/winuser/ns-winuser-cbt_createwndw
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct CBT_CREATEWNDA
    {
        /// <summary>
        /// A pointer to a CREATESTRUCTA structure that contains initialization parameters for the window about to be created.
        /// </summary>
        public System.IntPtr lpcs;

        /// HWND->HWND__*
        public System.IntPtr hwndInsertAfter;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct CBT_CREATEWNDW
    {
        /// <summary>
        /// A pointer to a CREATESTRUCTW structure that contains initialization parameters for the window about to be created.
        /// </summary>
        public System.IntPtr lpcs;

        /// HWND->HWND__*
        public System.IntPtr hwndInsertAfter;
    }
}