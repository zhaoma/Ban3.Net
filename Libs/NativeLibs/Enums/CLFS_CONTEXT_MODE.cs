using System;
using System.Collections.Generic;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Enums
{
    /// <summary>
    /// The CLFS_CONTEXT_MODE enumeration indicates 
    /// the type of sequence that the Common Log File System (CLFS) driver follows when it reads a set of records from a stream.
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ne-wdm-_clfs_context_mode
    /// </summary>
    public enum CLFS_CONTEXT_MODE
    {
        /// <summary>
        /// Do not move the cursor.
        /// Indicates that a variable of type CLFS_CONTEXT_MODE has not yet been assigned a meaningful value.
        /// </summary>
        ClfsContextNone = 0x00,

        /// <summary>
        /// Move the cursor backward to the next undo record.
        /// Indicates that the next record in the sequence is pointed to by the undo-next LSN of the current record.
        /// </summary>
        ClfsContextUndoNext,

        /// <summary>
        /// Move the cursor to the previous log record from the current read context.
        /// Indicates that the next record in the sequence is pointed to by the previous LSN of the current record.
        /// </summary>
        ClfsContextPrevious,

        /// <summary>
        /// Move the cursor to the next client log record from the current read context.
        /// Indicates that the next record in the sequence is the record in the stream that immediately follows the current record.
        /// </summary>
        ClfsContextForward,
    }
}
