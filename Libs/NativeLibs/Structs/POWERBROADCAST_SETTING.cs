using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential, CharSet = System.Runtime.InteropServices.CharSet.Ansi)]
    public struct POWERBROADCAST_SETTING
    {

        /// GUID->_GUID
        public GUID PowerSetting;

        /// DWORD->unsigned int
        public uint DataLength;

        /// UCHAR[1]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1)]
        public string Data;
    }
}