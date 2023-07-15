using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// Describes a deleted list box or combo box item.
    /// https://learn.microsoft.com/en-us/windows/win32/api/winuser/ns-winuser-deleteitemstruct
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct DELETEITEMSTRUCT
    {

        /// UINT->unsigned int
        public uint CtlType;

        /// UINT->unsigned int
        public uint CtlID;

        /// UINT->unsigned int
        public uint itemID;

        /// HWND->HWND__*
        public System.IntPtr hwndItem;

        /// ULONG_PTR->unsigned int
        public uint itemData;
    }
}