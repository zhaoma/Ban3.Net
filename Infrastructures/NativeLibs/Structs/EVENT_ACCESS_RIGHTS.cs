using System;
using System.Collections.Generic;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/windows/win32/api/evntcons/nf-evntcons-eventaccesscontrol
    /// </summary>
    [Flags]
    public enum EVENT_ACCESS_RIGHTS
    {
        /// <summary>
        /// Allows the user to query information about the trace session.
        /// Set this permission on the session's GUID.
        /// </summary>
        WMIGUID_QUERY,

        /// <summary>
        /// Allows the user to start or update a real-time session.
        /// Set this permission on the session's GUID.
        /// </summary>
        TRACELOG_CREATE_REALTIME,

        /// <summary>
        /// Allows the user to start or update a session that writes events to a log file.
        /// Set this permission on the session's GUID.
        /// </summary>
        TRACELOG_CREATE_ONDISK,

        /// <summary>
        /// Allows the user to enable the provider.
        /// Set this permission on the provider's GUID.
        /// </summary>
        TRACELOG_GUID_ENABLE,

        /// <summary>
        /// Not used.
        /// </summary>
        TRACELOG_ACCESS_KERNEL_LOGGER,

        /// <summary>
        /// Allows the user to log events to a trace session if session is running in SECURE mode (the session set the EVENT_TRACE_SECURE_MODE flag in the LogFileMode member of EVENT_TRACE_PROPERTIES).
        /// </summary>
        TRACELOG_LOG_EVENT,

        /// <summary>
        /// Allows a user to consume events in real-time.
        /// Set this permission on the session's GUID.
        /// </summary>
        TRACELOG_ACCESS_REALTIME,

        /// <summary>
        /// Allows the user to register the provider.
        /// Set this permission on the provider's GUID.
        /// </summary>
        TRACELOG_REGISTER_GUIDS
    }
}
