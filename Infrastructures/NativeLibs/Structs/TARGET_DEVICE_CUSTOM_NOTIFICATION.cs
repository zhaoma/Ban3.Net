using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The TARGET_DEVICE_CUSTOM_NOTIFICATION structure describes a custom device event.
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ns-wdm-_target_device_custom_notification
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct TARGET_DEVICE_CUSTOM_NOTIFICATION
    {
        /// USHORT->unsigned short
        public ushort Version;

        /// USHORT->unsigned short
        public ushort Size;

        /// GUID->_GUID
        public GUID Event;

        /// PVOID->void*
        public System.IntPtr FileObject;

        /// LONG->int
        public int NameBufferOffset;

        /// UCHAR[1]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1)]
        public string CustomDataBuffer;
    }
}
