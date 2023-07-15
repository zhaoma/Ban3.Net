using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The SYSTEM_POWER_STATE_CONTEXT structure is a partially opaque system structure that contains information about the previous system power states of a computer.
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ns-wdm-_system_power_state_context
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct SYSTEM_POWER_STATE_CONTEXT
    {
        public SYSTEM_POWER_STATE_CONTEXT_UNION Union1;
    }

    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Explicit)]
    public struct SYSTEM_POWER_STATE_CONTEXT_UNION
    {

        /// Anonymous_a1189099_7915_4298_bc12_96f1e1a5794a
        [FieldOffset(0)]
        public SYSTEM_POWER_STATE_CONTEXT_DUMMY DUMMYSTRUCTNAME;

        /// <summary>
        /// Opaque member. Reserved for system use.
        /// </summary>
        [FieldOffset(0)]
        public uint ContextAsUlong;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct SYSTEM_POWER_STATE_CONTEXT_DUMMY
    {

        /// Reserved1 : 8
        ///TargetSystemState : 4
        ///EffectiveSystemState : 4
        ///CurrentSystemState : 4
        ///IgnoreHibernationPath : 1
        ///PseudoTransition : 1
        ///KernelSoftReboot : 1
        ///DirectedDripsTransition : 1
        ///Reserved2 : 8
        public uint bitvector1;

        /// <summary>
        /// Opaque member. Reserved for system use.
        /// </summary>
        public uint Reserved1
        {
            get
            {
                return ((uint)((this.bitvector1 & 255u)));
            }
            set
            {
                this.bitvector1 = ((uint)((value | this.bitvector1)));
            }
        }

        /// <summary>
        /// The target system power state of the previous system power IRP that the driver received. 
        /// This member is set to a SYSTEM_POWER_STATE enumeration value. 
        /// Drivers should treat this member as read-only.
        /// </summary>
        public uint TargetSystemState
        {
            get
            {
                return ((uint)(((this.bitvector1 & 3840u)
                            / 256)));
            }
            set
            {
                this.bitvector1 = ((uint)(((value * 256)
                            | this.bitvector1)));
            }
        }

        /// <summary>
        /// The effective previous system power state, as perceived by the user. 
        /// This member is set to a SYSTEM_POWER_STATE enumeration value. 
        /// Drivers should treat this member as read-only. 
        /// This member value might not match the TargetSystemState member if, 
        /// for example, the previous system power IRP indicated that the computer was about to enter hibernation, 
        /// but a hybrid shutdown instead occurred to prepare the computer for a fast startup.
        /// </summary>
        public uint EffectiveSystemState
        {
            get
            {
                return ((uint)(((this.bitvector1 & 61440u)
                            / 4096)));
            }
            set
            {
                this.bitvector1 = ((uint)(((value * 4096)
                            | this.bitvector1)));
            }
        }

        /// <summary>
        /// Opaque member. Reserved for system use.
        /// </summary>
        public uint CurrentSystemState
        {
            get
            {
                return ((uint)(((this.bitvector1 & 983040u)
                            / 65536)));
            }
            set
            {
                this.bitvector1 = ((uint)(((value * 65536)
                            | this.bitvector1)));
            }
        }

        /// <summary>
        /// Opaque member. Reserved for system use.
        /// </summary>
        public uint IgnoreHibernationPath
        {
            get
            {
                return ((uint)(((this.bitvector1 & 1048576u)
                            / 1048576)));
            }
            set
            {
                this.bitvector1 = ((uint)(((value * 1048576)
                            | this.bitvector1)));
            }
        }

        /// <summary>
        /// Opaque member. Reserved for system use.
        /// </summary>
        public uint PseudoTransition
        {
            get
            {
                return ((uint)(((this.bitvector1 & 2097152u)
                            / 2097152)));
            }
            set
            {
                this.bitvector1 = ((uint)(((value * 2097152)
                            | this.bitvector1)));
            }
        }

        /// <summary>
        /// Opaque member. Reserved for system use.
        /// </summary>
        public uint KernelSoftReboot
        {
            get
            {
                return ((uint)(((this.bitvector1 & 4194304u)
                            / 4194304)));
            }
            set
            {
                this.bitvector1 = ((uint)(((value * 4194304)
                            | this.bitvector1)));
            }
        }

        /// <summary>
        /// Opaque member. Reserved for system use.
        /// </summary>
        public uint DirectedDripsTransition
        {
            get
            {
                return ((uint)(((this.bitvector1 & 8388608u)
                            / 8388608)));
            }
            set
            {
                this.bitvector1 = ((uint)(((value * 8388608)
                            | this.bitvector1)));
            }
        }

        /// <summary>
        /// Opaque member. Reserved for system use.
        /// </summary>
        public uint Reserved2
        {
            get
            {
                return ((uint)(((this.bitvector1 & 4278190080u)
                            / 16777216)));
            }
            set
            {
                this.bitvector1 = ((uint)(((value * 16777216)
                            | this.bitvector1)));
            }
        }
    }
}
