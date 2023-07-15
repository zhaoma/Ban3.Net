using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    [StructLayout(LayoutKind.Sequential)]
    public struct OUTPUT_DEBUG_STRING_INFO
    {

        /// LPSTR->CHAR*
        [MarshalAs(UnmanagedType.LPStr)]
        public string lpDebugStringData;

        /// WORD->unsigned short
        public ushort fUnicode;

        /// WORD->unsigned short
        public ushort nDebugStringLength;
    }
}