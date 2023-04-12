using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The LSA_UNICODE_STRING structure is used by various Local Security Authority (LSA) functions to specify a Unicode string.
    /// https://learn.microsoft.com/en-us/windows/win32/api/lsalookup/ns-lsalookup-lsa_unicode_string
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct LSA_UNICODE_STRING
    {
        /// USHORT->unsigned short
        public ushort Length;

        /// USHORT->unsigned short
        public ushort MaximumLength;

        /// PWSTR->WCHAR*
        [MarshalAs(UnmanagedType.LPWStr)]
        public string Buffer;
    }
}