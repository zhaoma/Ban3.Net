using System;
using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// Contains a certificate hash.
    /// https://learn.microsoft.com/en-us/windows/win32/api/winefs/ns-winefs-efs_hash_blob
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct EFS_HASH_BLOB
    {
        /// <summary>
        /// The number of bytes in the pbData buffer.
        /// </summary>
        public uint cbData;

        /// <summary>
        /// The certificate hash.
        /// </summary>
        public IntPtr pbData;
    }

}
