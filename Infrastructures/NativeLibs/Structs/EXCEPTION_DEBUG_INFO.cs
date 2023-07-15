using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    [StructLayout(LayoutKind.Sequential)]
    public struct EXCEPTION_DEBUG_INFO
    {

        /// EXCEPTION_RECORD->_EXCEPTION_RECORD
        public EXCEPTION_RECORD ExceptionRecord;

        /// DWORD->unsigned int
        public uint dwFirstChance;
    }
}