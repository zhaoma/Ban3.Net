using Ban3.Infrastructures.NativeLibs.Enums;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The IO_SESSION_STATE_INFORMATION structure contains information about the state of a user session.
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ns-wdm-_io_session_state_information
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct IO_SESSION_STATE_INFORMATION
    {
        /// <summary>
        /// The session ID. This member contains the Terminal Services session identifier of a user session. 
        /// The IoGetContainerInformation routine sets this member to the session ID of the session 
        /// that is represented by the session object that the ContainerObject parameter of IoGetContainerInformation points to.
        /// </summary>
        public uint SessionId;

        /// <summary>
        /// The current state of the user session that is identified by SessionId.
        /// </summary>
        public IO_SESSION_STATE SessionState;

        /// <summary>
        /// Indicates whether the user session identified by SessionId is a local session. 
        /// If TRUE, the user is logged on locally. 
        /// If FALSE, the user is logged on remotely. 
        /// This member is valid only if the session is connected.
        /// </summary>
        public bool LocalSession;
    }
}
