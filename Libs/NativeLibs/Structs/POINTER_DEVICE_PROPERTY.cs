using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// Contains pointer-based device properties (Human Interface Device (HID) global items that correspond to HID usages).
    /// https://learn.microsoft.com/en-us/windows/win32/api/winuser/ns-winuser-pointer_device_property
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct POINTER_DEVICE_PROPERTY
    {
        /// INT32->int
        public int logicalMin;

        /// INT32->int
        public int logicalMax;

        /// INT32->int
        public int physicalMin;

        /// INT32->int
        public int physicalMax;

        /// UINT32->unsigned int
        public uint unit;

        /// UINT32->unsigned int
        public uint unitExponent;

        /// USHORT->unsigned short
        public ushort usagePageId;

        /// USHORT->unsigned short
        public ushort usageId;
    }
}