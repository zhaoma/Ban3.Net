using System;
using System.Collections.Generic;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Enums
{
    /// <summary>
    /// The IO_SESSION_STATE enumeration contains constants that indicate the current state of a user session.
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ne-wdm-_io_session_state
    /// </summary>
    public enum IO_SESSION_STATE
    {
        /// <summary>
        /// The session has been created.
        /// </summary>
        IoSessionStateCreated,

        /// <summary>
        /// The session has been initialized but has not yet been created.
        /// </summary>
        IoSessionStateInitialized,

        /// <summary>
        /// The session is connected but the user has not yet logged on.
        /// </summary>
        IoSessionStateConnected,

        /// <summary>
        /// The session has been disconnected.
        /// </summary>
        IoSessionStateDisconnected,

        /// <summary>
        /// The session was disconnected while the user was logged on.
        /// </summary>
        IoSessionStateDisconnectedLoggedOn,

        /// <summary>
        /// The user is logged on to the session.
        /// </summary>
        IoSessionStateLoggedOn,

        /// <summary>
        /// The user has logged off of the session.
        /// </summary>
        IoSessionStateLoggedOff,

        /// <summary>
        /// The session has been terminated.
        /// </summary>
        IoSessionStateTerminated,

        /// <summary>
        /// Specifies the maximum value in this enumeration type.
        /// </summary>
        IoSessionStateMax
    }
}
