using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The NAMED_PIPE_CREATE_PARAMETERS structure is used by the Windows subsystem to create a named pipe.
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ns-wdm-_named_pipe_create_parameters
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct NAMED_PIPE_CREATE_PARAMETERS
    {
        /// <summary>
        /// Type of named pipe to create.
        /// </summary>
        public uint NamedPipeType;

        /// <summary>
        /// Mode in which to read the pipe.
        /// </summary>
        public uint ReadMode;

        /// <summary>
        /// Specifies how the operation is to be completed.
        /// </summary>
        public uint CompletionMode;

        /// <summary>
        /// Maximum number of simultaneous instances of the named pipe.
        /// </summary>
        public uint MaximumInstances;

        /// <summary>
        /// Pool quota that is reserved for writes to the inbound side of the named pipe.
        /// </summary>
        public uint InboundQuota;

        /// <summary>
        /// Pool quota that is reserved for writes to the outbound side of the named pipe.
        /// </summary>
        public uint OutboundQuota;

        /// <summary>
        /// Pointer to a timeout value to use if a timeout value is not specified when waiting for an instance of a named pipe. 
        /// This member is optional and can be set to NULL.
        /// </summary>
        public LARGE_INTEGER DefaultTimeout;

        /// <summary>
        /// Boolean value that specifies whether a pointer to a timeout period was provided in the DefaultTimeout member.
        /// </summary>
        public byte TimeoutSpecified;

    }
}
