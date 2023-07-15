using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// Contains information about a window station or desktop handle.
    /// https://learn.microsoft.com/en-us/windows/win32/api/winuser/ns-winuser-userobjectflags
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct USEROBJECTFLAGS
    {
        /// <summary>
        /// If this member is TRUE, new processes inherit the handle. Otherwise, the handle is not inherited.
        /// </summary>
        [MarshalAs(UnmanagedType.Bool)]
        public bool fInherit;

        /// <summary>
        /// Reserved for future use. This member must be FALSE.
        /// </summary>
        [MarshalAs(UnmanagedType.Bool)]
        public bool fReserved;

        /// <summary>
        /// For window stations, this member can contain the following window station attribute.
        /// WSF_VISIBLE=0x0001L                 Window station has visible display surfaces.
        ///
        /// For desktops, the dwFlags member can contain the following value.
        /// DF_ALLOWOTHERACCOUNTHOOK=0x0001L    Allows processes running in other accounts on the desktop to set hooks in this process.
        /// </summary>
        public uint dwFlags;

    }
}