using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The OB_CALLBACK_REGISTRATION structure specifies the parameters 
    /// when the ObRegisterCallbacks routine registers ObjectPreCallback and ObjectPostCallback callback routines.
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ns-wdm-_ob_callback_registration
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct OB_CALLBACK_REGISTRATION
    {
        /// <summary>
        /// The version of object callback registration that is requested. 
        /// Drivers should specify OB_FLT_REGISTRATION_VERSION.
        /// </summary>
        public ushort Version;

        /// <summary>
        /// The number of entries in the OperationRegistration array.
        /// </summary>
        public ushort OperationRegistrationCount;

        /// <summary>
        /// A Unicode string that specifies the altitude of the driver.
        /// </summary>
        public UNICODE_STRING Altitude;

        /// <summary>
        /// The system passes the RegistrationContext value to the callback routine when the callback routine is run. 
        /// The meaning of this value is driver-defined.
        /// </summary>
        public System.IntPtr RegistrationContext;

        /// <summary>
        /// A pointer to an array of OB_OPERATION_REGISTRATION structures. 
        /// Each structure specifies ObjectPreCallback and ObjectPostCallback callback routines and the types of operations that the routines are called for.
        /// </summary>
        public System.IntPtr OperationRegistration;
    }
}
