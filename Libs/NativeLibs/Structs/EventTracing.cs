using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Structs
{

    [StructLayout(LayoutKind.Sequential)]
    public struct EventTracing
    {

        /// ULONG->unsigned int
        public uint IsEnabled;

        /// UCHAR->unsigned char
        public byte Level;

        /// UCHAR->unsigned char
        public byte Reserved1;

        /// USHORT->unsigned short
        public ushort LoggerId;

        /// ULONG->unsigned int
        public uint EnableProperty;

        /// ULONG->unsigned int
        public uint Reserved2;

        /// ULONGLONG->unsigned __int64
        public ulong MatchAnyKeyword;

        /// ULONGLONG->unsigned __int64
        public ulong MatchAllKeyword;
    }





}
