using Ban3.Infrastructures.NativeLibs.Enums;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The OB_PRE_OPERATION_INFORMATION structure provides information about a process or thread handle operation to an ObjectPreCallback routine.
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ns-wdm-_ob_pre_operation_information
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct OB_PRE_OPERATION_INFORMATION
    {
        /// <summary>
        /// The type of handle operation.
        /// </summary>
        public OB_OPERATION Operation;

        /// Anonymous_0ad38663_422a_4d5d_8610_5ae3e89a1164
        public OB_PRE_OPERATION_INFORMATION_UNION Union1;

        /// <summary>
        /// A pointer to the process or thread object that is the target of the handle operation.
        /// </summary>
        public System.IntPtr Object;

        /// <summary>
        /// A pointer to the object type of the object. 
        /// This member is PsProcessType for a process or PsThreadType for a thread.
        /// </summary>
        public System.IntPtr ObjectType;

        /// <summary>
        /// A pointer to driver-specific context information for the operation. 
        /// By default, the Filter Manager sets this member to NULL, 
        /// but the ObjectPreCallback routine can reset the CallContext member in a driver-specific manner. 
        /// The Filter Manager passes this value to the matching ObjectPostCallback routine.
        /// </summary>
        public System.IntPtr CallContext;

        /// <summary>
        /// A pointer to an OB_PRE_OPERATION_PARAMETERS union that contains operation-specific information. 
        /// The Operation member determines which member of the union is valid.
        /// </summary>
        public System.IntPtr Parameters;
    }

    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Explicit)]
    public struct OB_PRE_OPERATION_INFORMATION_UNION
    {
        /// <summary>
        /// Reserved. Use the KernelHandle member instead.
        /// </summary>
        [FieldOffset(0)]
        public uint Flags;

        /// Anonymous_e9df5848_7f1a_4b82_8aa7_574bcff2986e
        [FieldOffset(0)]
        public OB_PRE_OPERATION_INFORMATION_STRUCT Struct1;
    }


    [StructLayout(LayoutKind.Sequential)]
    public struct OB_PRE_OPERATION_INFORMATION_STRUCT
    {

        /// KernelHandle : 1
        ///Reserved : 31
        public uint bitvector1;

        /// <summary>
        /// A bit that specifies whether the handle is a kernel handle. 
        /// If this member is TRUE, the handle is a kernel handle. 
        /// Otherwise, this handle is not a kernel handle.
        /// </summary>
        public uint KernelHandle
        {
            get
            {
                return ((uint)((this.bitvector1 & 1u)));
            }
            set
            {
                this.bitvector1 = ((uint)((value | this.bitvector1)));
            }
        }

        /// <summary>
        /// Reserved for system use.
        /// </summary>
        public uint Reserved
        {
            get
            {
                return ((uint)(((this.bitvector1 & 4294967294u)
                            / 2)));
            }
            set
            {
                this.bitvector1 = ((uint)(((value * 2)
                            | this.bitvector1)));
            }
        }
    }
}
