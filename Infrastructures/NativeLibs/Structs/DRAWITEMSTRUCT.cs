using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// Provides information that the owner window uses to determine how to paint an owner-drawn control or menu item. The owner window of the owner-drawn control or menu item receives a pointer to this structure as the lParam parameter of the WM_DRAWITEM message.
    /// https://learn.microsoft.com/en-us/windows/win32/api/winuser/ns-winuser-drawitemstruct
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct DRAWITEMSTRUCT
    {

        /// UINT->unsigned int
        public uint CtlType;

        /// UINT->unsigned int
        public uint CtlID;

        /// UINT->unsigned int
        public uint itemID;

        /// UINT->unsigned int
        public uint itemAction;

        /// UINT->unsigned int
        public uint itemState;

        /// HWND->HWND__*
        public System.IntPtr hwndItem;

        /// HDC->HDC__*
        public System.IntPtr hDC;

        /// RECT->tagRECT
        public RECT rcItem;

        /// ULONG_PTR->unsigned int
        public uint itemData;
    }
}