using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The IO_SESSION_STATE_NOTIFICATION structure contains information 
    /// that a kernel-mode driver supplies to the IoRegisterContainerNotification routine 
    /// when the driver registers to receive notifications of session events.
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ns-wdm-_io_session_state_notification
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct IO_SESSION_STATE_NOTIFICATION
    {
        /// <summary>
        /// The size, in bytes, of the IO_SESSION_STATE_NOTIFICATION structure.
        /// </summary>
        public uint Size;

        /// <summary>
        /// No flags are currently defined for this member. Set to zero.
        /// </summary>
        public uint Flags;

        /// <summary>
        /// A pointer to an I/O object owned by the driver. 
        /// This member can point to a DEVICE_OBJECT, DRIVER_OBJECT, or FILE_OBJECT structure. 
        /// The I/O object must remain valid for the lifetime of the registration. 
        /// Before you delete a registered device object, unload a registered driver, or close a registered file object, 
        /// call the IoUnregisterContainerNotification routine to cancel the registration. 
        /// A driver can maintain simultaneous registrations for more than one I/O object, 
        /// but it cannot create more than one active registration for the same I/O object.
        /// </summary>
        public IntPtr IoObject;

        /// <summary>
        /// Mask bits for session events. These mask bits indicate the events for which the driver requests notifications.
        /// </summary>
        public uint EventMask;

        /// <summary>
        /// A pointer to a context buffer in which the driver can store its private data for a particular session notification registration.
        /// </summary>
        public IntPtr Context;
    }
}
