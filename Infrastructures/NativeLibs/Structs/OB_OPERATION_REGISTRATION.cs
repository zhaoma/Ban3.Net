using Ban3.Infrastructures.NativeLibs.Enums;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The OB_OPERATION_REGISTRATION structure specifies ObjectPreCallback and ObjectPostCallback callback routines 
    /// and the types of operations that the routines are called for.
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ns-wdm-_ob_operation_registration
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct OB_OPERATION_REGISTRATION
    {
        /// <summary>
        /// A pointer to the object type that triggers the callback routine.
        /// Specify one of the following values : OB_OBJECT_TYPE
        /// </summary>
        public System.IntPtr ObjectType;

        /// PVOID->void*
        public OB_OPERATION Operations;

        /// <summary>
        /// A pointer to an ObjectPreCallback routine. 
        /// The system calls this routine before the requested operation occurs.
        /// </summary>
        public System.IntPtr PreOperation;

        /// <summary>
        /// A pointer to an ObjectPostCallback routine. 
        /// The system calls this routine after the requested operation occurs.
        /// </summary>
        public System.IntPtr PostOperation;
    }
}
