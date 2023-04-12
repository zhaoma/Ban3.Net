using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// Informs the system of the dimensions of an owner-drawn control or menu item.
    /// This allows the system to process user interaction with the control correctly.
    /// https://learn.microsoft.com/en-us/windows/win32/api/winuser/ns-winuser-measureitemstruct
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct MEASUREITEMSTRUCT
    {
        /// UINT->unsigned int
        public uint CtlType;

        /// UINT->unsigned int
        public uint CtlID;

        /// UINT->unsigned int
        public uint itemID;

        /// UINT->unsigned int
        public uint itemWidth;

        /// UINT->unsigned int
        public uint itemHeight;

        /// ULONG_PTR->unsigned int
        public uint itemData;
    }
}