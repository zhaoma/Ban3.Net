using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The PAINTSTRUCT structure contains information for an application.
    /// This information can be used to paint the client area of a window owned by that application.
    /// https://learn.microsoft.com/en-us/windows/win32/api/winuser/ns-winuser-paintstruct
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct PAINTSTRUCT
    {
        /// <summary>
        /// A handle to the display DC to be used for painting.
        /// </summary>
        public System.IntPtr hdc;

        /// <summary>
        /// Indicates whether the background must be erased.
        /// This value is nonzero if the application should erase the background.
        /// The application is responsible for erasing the background if a window class is created without a background brush.
        /// For more information, see the description of the hbrBackground member of the WNDCLASS structure.
        /// </summary>
        [MarshalAs(UnmanagedType.Bool)]
        public bool fErase;

        /// <summary>
        /// A RECT structure that specifies the upper left and lower right corners of the rectangle in which the painting is requested,
        /// in device units relative to the upper-left corner of the client area.
        /// </summary>
        public RECT rcPaint;

        /// <summary>
        /// Reserved; used internally by the system.
        /// </summary>
        [MarshalAs(UnmanagedType.Bool)]
        public bool fRestore;

        /// <summary>
        /// Reserved; used internally by the system.
        /// </summary>
        [MarshalAs(UnmanagedType.Bool)]
        public bool fIncUpdate;

        /// <summary>
        /// Reserved; used internally by the system.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32, ArraySubType = UnmanagedType.I1)]
        public byte[] rgbReserved;
    }
}