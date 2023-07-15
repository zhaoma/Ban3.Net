using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    [StructLayout(LayoutKind.Sequential)]
    public struct WINDOWPOS
    {

        /// HWND->HWND__*
        public System.IntPtr hwnd;

        /// HWND->HWND__*
        public System.IntPtr hwndInsertAfter;

        /// int
        public int x;

        /// int
        public int y;

        /// int
        public int cx;

        /// int
        public int cy;

        /// UINT->unsigned int
        public uint flags;
    }
}