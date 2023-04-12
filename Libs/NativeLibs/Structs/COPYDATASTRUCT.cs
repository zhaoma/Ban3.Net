using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// Contains data to be passed to another application by the WM_COPYDATA message.
    /// https://learn.microsoft.com/en-us/windows/win32/api/winuser/ns-winuser-copydatastruct
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct COPYDATASTRUCT
    {
        /// <summary>
        /// The type of the data to be passed to the receiving application. 
        /// The receiving application defines the valid types.
        /// </summary>
        public uint dwData;

        /// <summary>
        /// The size, in bytes, of the data pointed to by the lpData member.
        /// </summary>
        public uint cbData;

        /// <summary>
        /// The data to be passed to the receiving application. 
        /// This member can be NULL.
        /// </summary>
        public IntPtr lpData;
    }
}
