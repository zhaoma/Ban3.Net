using System;
using System.Collections.Generic;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Enums
{
    /// <summary>
    /// Specifies whether a log is ephemeral.
    /// https://learn.microsoft.com/en-us/windows/win32/api/clfs/ne-clfs-clfs_log_archive_mode
    /// </summary>
    public enum CLFS_LOG_ARCHIVE_MODE
    {
        /// <summary>
        /// Enables log archive (ephemeral logs) support.
        /// </summary>
        ClfsLogArchiveEnabled = 0x01,

        /// <summary>
        /// Disables ephemeral logs.
        /// </summary>
        ClfsLogArchiveDisabled = 0x02
    }
}
