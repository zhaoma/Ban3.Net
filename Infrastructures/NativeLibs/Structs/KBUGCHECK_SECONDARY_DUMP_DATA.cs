using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The KBUGCHECK_SECONDARY_DUMP_DATA structure describes a section of driver-supplied data to be written by KbCallbackSecondaryDumpData routine to the crash dump file.
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ns-wdm-_kbugcheck_secondary_dump_data
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct KBUGCHECK_SECONDARY_DUMP_DATA
    {
        /// <summary>
        /// Pointer to a buffer that is allocated by the system.
        /// </summary>
        public System.IntPtr InBuffer;

        /// <summary>
        /// Specifies the size of the buffer, in bytes, specified by the InBuffer member.
        /// </summary>
        public uint InBufferLength;

        /// <summary>
        /// Specifies the maximum amount of data that the KbCallbackSecondaryDumpData routine can write to the crash dump file.
        /// </summary>
        public uint MaximumAllowed;

        /// <summary>
        /// Specifies a GUID that identifies the driver's crash dump data. (Drivers must use unique GUIDs to mark their crash dump data. Use the GuidGen.exe tool to generate GUIDs for your driver. 
        /// This tool is included in the Microsoft Windows SDK.)
        /// </summary>
        public GUID Guid;

        /// <summary>
        /// Pointer to the buffer where the driver writes its crash dump data, or NULL.
        /// </summary>
        public System.IntPtr OutBuffer;

        /// <summary>
        /// Specifies the size of the buffer, in bytes, that was specified by the OutBuffer member.
        /// </summary>
        public uint OutBufferLength;
    }
}
