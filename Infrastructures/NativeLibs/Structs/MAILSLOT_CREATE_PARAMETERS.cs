using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The MAILSLOT_CREATE_PARAMETERS is used by the Windows subsystem to create a mailslot.
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ns-wdm-_mailslot_create_parameters
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct MAILSLOT_CREATE_PARAMETERS
    {
        /// <summary>
        /// Pool quota that is reserved for writes to this mailslot.
        /// </summary>
        public uint MailslotQuota;

        /// <summary>
        /// Size, in bytes, of the largest message that can be written to this mailslot.
        /// </summary>
        public uint MaximumMessageSize;

        /// <summary>
        /// The timeout period for the read operation, specified as a relative time.
        /// </summary>
        public LARGE_INTEGER ReadTimeout;

        /// <summary>
        /// Boolean value that specifies whether a timeout period was provided in the ReadTimeout member.
        /// </summary>
        public byte TimeoutSpecified;
    }
}
