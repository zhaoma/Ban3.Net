using System.Drawing;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// Contains status information for the application-switching (ALT+TAB) window.
    /// https://learn.microsoft.com/en-us/windows/win32/api/winuser/ns-winuser-alttabinfo
    /// </summary>
    public struct ALTTABINFO
    {
        /// <summary>
        /// The size, in bytes, of the structure. The caller must set this to sizeof(ALTTABINFO).
        /// </summary>
        public uint cbSize;

        /// <summary>
        /// The number of items in the window.
        /// </summary>
        public int cItems;

        /// <summary>
        /// The number of columns in the window.
        /// </summary>
        public int cColumns;

        /// <summary>
        /// The number of rows in the window.
        /// </summary>
        public int cRows;

        /// <summary>
        /// The column of the item that has the focus.
        /// </summary>
        public int iColFocus;

        /// <summary>
        /// The row of the item that has the focus.
        /// </summary>
        public int iRowFocus;

        /// <summary>
        /// The width of each icon in the application-switching window.
        /// </summary>
        public int cxItem;

        /// <summary>
        /// The height of each icon in the application-switching window.
        /// </summary>
        public int cyItem;

        /// <summary>
        /// The top-left corner of the first icon.
        /// </summary>
        public POINT ptStart;
    }
}