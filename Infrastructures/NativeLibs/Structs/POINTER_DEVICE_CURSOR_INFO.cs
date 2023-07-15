using Ban3.Infrastructures.NativeLibs.Enums;
using System;
using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// Contains cursor ID mappings for pointer devices.
    /// https://learn.microsoft.com/en-us/windows/win32/api/winuser/ns-winuser-pointer_device_cursor_info
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct POINTER_DEVICE_CURSOR_INFO
    {
        /// <summary>
        /// The assigned cursor ID.
        /// </summary>
        public uint cursorId;

        /// <summary>
        /// The POINTER_DEVICE_CURSOR_TYPE that the ID is mapped to.
        /// </summary>
        public POINTER_DEVICE_CURSOR_TYPE cursor;
    }
}