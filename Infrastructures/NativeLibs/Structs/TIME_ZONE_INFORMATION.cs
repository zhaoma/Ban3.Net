using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    [StructLayout(LayoutKind.Sequential)]
    public struct TIME_ZONE_INFORMATION
    {

        /// LONG->int
        public int Bias;

        /// WCHAR[32]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
        public string StandardName;

        /// SYSTEMTIME->_SYSTEMTIME
        public SYSTEMTIME StandardDate;

        /// LONG->int
        public int StandardBias;

        /// WCHAR[32]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
        public string DaylightName;

        /// SYSTEMTIME->_SYSTEMTIME
        public SYSTEMTIME DaylightDate;

        /// LONG->int
        public int DaylightBias;
    }
}