using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// Supplies the identifiers and application-supplied data for two items in a sorted, owner-drawn list box or combo box.
    /// https://learn.microsoft.com/en-us/windows/win32/api/winuser/ns-winuser-compareitemstruct
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct COMPAREITEMSTRUCT
    {

        /// UINT->unsigned int
        public uint CtlType;

        /// UINT->unsigned int
        public uint CtlID;

        /// HWND->HWND__*
        public System.IntPtr hwndItem;

        /// UINT->unsigned int
        public uint itemID1;

        /// ULONG_PTR->unsigned int
        public uint itemData1;

        /// UINT->unsigned int
        public uint itemID2;

        /// ULONG_PTR->unsigned int
        public uint itemData2;

        /// DWORD->unsigned int
        public uint dwLocaleId;
    }
}