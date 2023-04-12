using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The UNICODE_STRING structure is used to define Unicode strings.
    /// https://learn.microsoft.com/en-us/windows/win32/api/ntdef/ns-ntdef-_unicode_string
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct UNICODE_STRING
    {
        /// <summary>
        /// The length, in bytes, of the string stored in Buffer.
        /// </summary>
        public ushort Length;

        /// <summary>
        /// The length, in bytes, of Buffer.
        /// </summary>
        public ushort MaximumLength;

        /// <summary>
        /// Pointer to a buffer used to contain a string of wide characters.
        /// </summary>
        [MarshalAs(UnmanagedType.LPWStr)]
        public string Buffer;
    }
}
