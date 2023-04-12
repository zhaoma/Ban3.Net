using System;
using System.Collections.Generic;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Enums
{
    public enum SIGNAL_WAIT : long
    {
        /// <summary>
        /// The specified object is a mutex object that was not released by the thread 
        /// that owned the mutex object before the owning thread terminated. 
        /// Ownership of the mutex object is granted to the calling thread, and the mutex is set to nonsignaled.
        /// If the mutex was protecting persistent state information, you should check it for consistency.
        /// </summary>
        WAIT_ABANDONED = 0x00000080L,

        /// <summary>
        /// The wait was ended by one or more user-mode asynchronous procedure calls (APC) queued to the thread.
        /// </summary>
        WAIT_IO_COMPLETION = 0x000000C0L,


        /// <summary>
        /// The state of the specified object is signaled.
        /// </summary>
        WAIT_OBJECT_0 = 0x00000000L,

        /// <summary>
        /// The time-out interval elapsed, and the object's state is nonsignaled.
        /// </summary>
        WAIT_TIMEOUT = 0x00000102L,

        /// <summary>
        /// The function has failed. To get extended error information, call GetLastError.
        /// </summary>
        WAIT_FAILED = 0xFFFFFFFF,

    }
}
