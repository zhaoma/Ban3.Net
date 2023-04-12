using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// Used by UpdateLayeredWindowIndirect to provide position, size, shape, content, and translucency information for a layered window.
    /// https://learn.microsoft.com/en-us/windows/win32/api/winuser/ns-winuser-updatelayeredwindowinfo
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct UPDATELAYEREDWINDOWINFO
    {
        /// DWORD->unsigned int
        public uint cbSize;

        /// HDC->HDC__*
        public System.IntPtr hdcDst;

        /// POINT*
        public System.IntPtr pptDst;

        /// SIZE*
        public System.IntPtr psize;

        /// HDC->HDC__*
        public System.IntPtr hdcSrc;

        /// POINT*
        public System.IntPtr pptSrc;

        /// COLORREF->DWORD->unsigned int
        public uint crKey;

        /// BLENDFUNCTION*
        public System.IntPtr pblend;

        /// DWORD->unsigned int
        public uint dwFlags;

        /// RECT*
        public System.IntPtr prcDirty;
    }
}