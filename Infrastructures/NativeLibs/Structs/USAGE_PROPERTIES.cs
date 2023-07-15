using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// Contains device properties (Human Interface Device (HID) global items that correspond to HID usages) for any type of HID input device.
    /// https://learn.microsoft.com/en-us/windows/win32/api/winuser/ns-winuser-usage_properties
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct USAGE_PROPERTIES
    {
        /// USHORT->unsigned short
        public ushort level;

        /// USHORT->unsigned short
        public ushort page;

        /// USHORT->unsigned short
        public ushort usage;

        /// INT32->int
        public int logicalMinimum;

        /// INT32->int
        public int logicalMaximum;

        /// USHORT->unsigned short
        public ushort unit;

        /// USHORT->unsigned short
        public ushort exponent;

        /// BYTE->unsigned char
        public byte count;

        /// INT32->int
        public int physicalMinimum;

        /// INT32->int
        public int physicalMaximum;
    }
}