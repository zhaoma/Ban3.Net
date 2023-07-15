using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The LSA_STRING structure is used by Local Security Authority (LSA) functions to specify an ANSI string.
    /// https://learn.microsoft.com/en-us/windows/win32/api/lsalookup/ns-lsalookup-lsa_string
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct LSA_STRING
    {

        /// USHORT->unsigned short
        public ushort Length;

        /// USHORT->unsigned short
        public ushort MaximumLength;

        /// PCHAR->CHAR*
        [MarshalAs(UnmanagedType.LPStr)]
        public string Buffer;
    }
}