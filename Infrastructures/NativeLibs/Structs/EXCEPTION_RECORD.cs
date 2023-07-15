using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{

    [StructLayout(LayoutKind.Sequential)]
    public struct EXCEPTION_RECORD
    {

        /// DWORD->unsigned int
        public uint ExceptionCode;

        /// DWORD->unsigned int
        public uint ExceptionFlags;

        /// _EXCEPTION_RECORD*
        public System.IntPtr ExceptionRecord;

        /// PVOID->void*
        public System.IntPtr ExceptionAddress;

        /// DWORD->unsigned int
        public uint NumberParameters;

        /// ULONG_PTR[15]
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 15, ArraySubType = UnmanagedType.U4)]
        public uint[] ExceptionInformation;
    }
}