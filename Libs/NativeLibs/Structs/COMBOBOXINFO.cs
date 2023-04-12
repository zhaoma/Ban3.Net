using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// Contains combo box status information.
    /// https://learn.microsoft.com/en-us/windows/win32/api/winuser/ns-winuser-comboboxinfo
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct COMBOBOXINFO
    {
        /// <summary>
        /// The size, in bytes, of the structure. The calling application must set this to sizeof(COMBOBOXINFO).
        /// </summary>
        public uint cbSize;

        /// <summary>
        /// A RECT structure that specifies the coordinates of the edit box.
        /// </summary>
        public RECT rcItem;

        /// <summary>
        /// A RECT structure that specifies the coordinates of the button that contains the drop-down arrow.
        /// </summary>
        public RECT rcButton;

        /// <summary>
        /// The combo box button state. This parameter can be one of the following values.
        /// 0                       :           The button exists and is not pressed.
        /// STATE_SYSTEM_INVISIBLE              There is no button.
        /// STATE_SYSTEM_PRESSED                The button is pressed.
        /// </summary>
        public uint stateButton;

        /// <summary>
        /// A handle to the combo box.
        /// </summary>
        public System.IntPtr hwndCombo;

        /// <summary>
        /// A handle to the edit box.
        /// </summary>
        public System.IntPtr hwndItem;

        /// <summary>
        /// A handle to the drop-down list.
        /// </summary>
        public System.IntPtr hwndList;
    }
}