using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// Describes the animation effects associated with user actions.
    /// This structure is used with the SystemParametersInfo function when the SPI_GETANIMATION or SPI_SETANIMATION action value is specified.
    /// https://learn.microsoft.com/en-us/windows/win32/api/winuser/ns-winuser-animationinfo
    [StructLayout(LayoutKind.Sequential)]
    /// </summary>
    public struct ANIMATIONINFO
    {
        /// <summary>
        /// The size of the structure, in bytes. The caller must set this to sizeof(ANIMATIONINFO).
        /// </summary>
        public uint cbSize;

        /// <summary>
        /// If this member is nonzero, minimize and restore animation is enabled; otherwise it is disabled.
        /// </summary>
        public int iMinAnimate;
    }
}