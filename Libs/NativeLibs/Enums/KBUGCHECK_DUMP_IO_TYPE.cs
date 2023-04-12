using System;
using System.Collections.Generic;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Enums
{
    /// <summary>
    /// The KBUGCHECK_DUMP_IO_TYPE enumeration type identifies the type of a section of data within a crash dump file.
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ne-wdm-_kbugcheck_dump_io_type
    /// </summary>
    public enum KBUGCHECK_DUMP_IO_TYPE
    {
        /// <summary>
        /// Reserved for system use. Do not use.
        /// </summary>
        KbDumpIoInvalid,

        /// <summary>
        /// Specifies that crash dump data is header information.
        /// </summary>
        KbDumpIoHeader,

        /// <summary>
        /// Specifies that the crash dump data is part of the main body of the crash dump, 
        /// such as the memory state at the time of the bug check.
        /// </summary>
        KbDumpIoBody,

        /// <summary>
        /// Specifies that the crash dump data is data returned by a KbCallbackSecondaryDumpData routine.
        /// </summary>
        KbDumpIoSecondaryData,

        /// <summary>
        /// Specifies that the crash dump data has been completely written.
        /// </summary>
        KbDumpIoComplete
    }
}
