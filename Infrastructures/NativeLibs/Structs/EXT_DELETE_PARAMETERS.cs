using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The EXT_DELETE_PARAMETERS structure contains an extended set of parameters for the ExDeleteTimer routine.
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ns-wdm-_ext_delete_parameters
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct EXT_DELETE_PARAMETERS
    {
        /// <summary>
        /// The version number of this EXT_DELETE_PARAMETERS structure. 
        /// The ExInitializeDeleteTimerParameters routine sets this member to the correct version number.
        /// </summary>
        public uint Version;

        /// <summary>
        /// Set to zero. The ExInitializeDeleteTimerParameters routine sets this member to zero.
        /// </summary>
        public uint Reserved;

        /// <summary>
        /// A pointer to a driver-implemented ExTimerDeleteCallback callback routine. 
        /// The operating system calls this routine when the timer is deleted. 
        /// This parameter is optional and can be NULL if no timer-deletion callback routine is needed.
        /// 
        /// The ExInitializeDeleteTimerParameters routine sets this member to NULL.
        /// </summary>
        public System.IntPtr DeleteCallback;

        /// <summary>
        /// A context value for the timer-deletion callback routine. 
        /// The operating system passes this value as a parameter to the timer-deletion callback routine, 
        /// if one is specified. This parameter is typically a pointer to a caller-defined structure that contains context information used by the callback routine. 
        /// This parameter is optional and can be set to NULL if no context information is needed.
        /// The ExInitializeDeleteTimerParameters routine sets this member to NULL.
        /// </summary>
        public System.IntPtr DeleteContext;
    }
}
