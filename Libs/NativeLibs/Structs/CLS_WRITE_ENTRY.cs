using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// Contains a user buffer, which is to become part of a log record, and its length.
    /// The ReserveAndAppendLog function uses CLFS_WRITE_ENTRY structures in the routine 
    /// that appends log records to logs.
    /// https://learn.microsoft.com/en-us/windows/win32/api/clfs/ns-clfs-cls_write_entry
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct CLS_WRITE_ENTRY
    {
        /// <summary>
        /// The log record data buffer.
        /// </summary>
        public IntPtr Buffer;

        /// <summary>
        /// The length of the log record data buffer, in bytes.
        /// </summary>
        public uint ByteLength;
    }
}
