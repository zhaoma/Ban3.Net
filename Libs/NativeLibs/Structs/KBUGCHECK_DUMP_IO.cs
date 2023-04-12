using Ban3.Infrastructures.NativeLibs.Enums;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The KBUGCHECK_DUMP_IO structure describes an I/O operation on the crash dump file.
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ns-wdm-_kbugcheck_dump_io
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct KBUGCHECK_DUMP_IO
    {
        /// <summary>
        /// Specifies the current offset in the crash dump file, or -1 if the crash dump file is being written sequentially.
        /// </summary>
        public ulong Offset;

        /// <summary>
        /// Pointer to a buffer that contains the current data to be written to the dump file.
        /// </summary>
        public System.IntPtr Buffer;

        /// <summary>
        /// Specifies the length of the buffer, in bytes, that is specified by the Buffer member.
        /// </summary>
        public uint BufferLength;

        /// <summary>
        /// Specifies the KBUGCHECK_DUMP_IO_TYPE value that signifies the type of data to be written to the dump file.
        /// </summary>
        public KBUGCHECK_DUMP_IO_TYPE Type;
    }
}
