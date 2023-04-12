using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// Contains the input injection details.
    /// https://learn.microsoft.com/en-us/windows/win32/api/winuser/ns-winuser-input_injection_value
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct INPUT_INJECTION_VALUE
    {
        /// USHORT->unsigned short
        public ushort page;

        /// USHORT->unsigned short
        public ushort usage;

        /// INT32->int
        public int value;

        /// USHORT->unsigned short
        public ushort index;
    }
}