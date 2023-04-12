using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    [StructLayout(LayoutKind.Sequential)]
    public struct SYSTEMTIME
    {
        /// WORD->unsigned short
        public ushort wYear;

        /// WORD->unsigned short
        public ushort wMonth;

        /// WORD->unsigned short
        public ushort wDayOfWeek;

        /// WORD->unsigned short
        public ushort wDay;

        /// WORD->unsigned short
        public ushort wHour;

        /// WORD->unsigned short
        public ushort wMinute;

        /// WORD->unsigned short
        public ushort wSecond;

        /// WORD->unsigned short
        public ushort wMilliseconds;
    }
}