using System;
using System.Collections.Generic;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Enums
{
    /// <summary>
    /// 
    /// https://learn.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-readeventloga
    /// </summary>
    [Flags]
    public enum READ_EVENTLOG_FLAGS:uint
    {
        /// <summary>
        /// Begin reading from the record specified in the dwRecordOffset parameter.
        /// This option may not work with large log files if the function cannot determine the log file's size.
        /// For details, see Knowledge Base article, 177199.
        /// </summary>
        EVENTLOG_SEEK_READ = 0x0002,

        /// <summary>
        /// Read the records sequentially.
        /// If this is the first read operation, the EVENTLOG_FORWARDS_READ EVENTLOG_BACKWARDS_READ flags determines which record is read first.
        /// </summary>
        EVENTLOG_SEQUENTIAL_READ = 0x0001,

        /// <summary>
        /// The log is read in chronological order (oldest to newest).
        /// The default.
        /// </summary>
        EVENTLOG_FORWARDS_READ =0x0004,

        /// <summary>
        /// The log is read in reverse chronological order (newest to oldest).
        /// </summary>
        EVENTLOG_BACKWARDS_READ = 0x0008,

        EVENTLOG_SEEK_FORWARDS= EVENTLOG_SEEK_READ| EVENTLOG_FORWARDS_READ,
        EVENTLOG_SEEK_BACKWARDS= EVENTLOG_SEEK_READ | EVENTLOG_BACKWARDS_READ,
        EVENTLOG_SEQUENTIAL_FORWARDS = EVENTLOG_SEQUENTIAL_READ | EVENTLOG_FORWARDS_READ,
        EVENTLOG_SEQUENTIAL_BACKWARDS = EVENTLOG_SEQUENTIAL_READ | EVENTLOG_BACKWARDS_READ
    }
}
