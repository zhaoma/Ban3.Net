using Ban3.Infrastructures.NativeLibs.Enums;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// A DEVICE_CAPABILITIES structure describes PnP and power capabilities of a device. 
    /// This structure is returned in response to an IRP_MN_QUERY_CAPABILITIES IRP.
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ns-wdm-_device_capabilities
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct DEVICE_CAPABILITIES
    {
        /// <summary>
        /// Specifies the size of the structure, in bytes. 
        /// This field is set by the component that sends the IRP_MN_QUERY_CAPABILITIES request.
        /// </summary>
        public ushort Size;

        /// <summary>
        /// Specifies the version of the structure, currently version 1. 
        /// This field is set by the component that sends the IRP_MN_QUERY_CAPABILITIES request.
        /// </summary>
        public ushort Version;

        ///DeviceD1 : 1
        ///DeviceD2 : 1
        ///LockSupported : 1
        ///EjectSupported : 1
        ///Removable : 1
        ///DockDevice : 1
        ///UniqueID : 1
        ///SilentInstall : 1
        ///RawDeviceOK : 1
        ///SurpriseRemovalOK : 1
        ///WakeFromD0 : 1
        ///WakeFromD1 : 1
        ///WakeFromD2 : 1
        ///WakeFromD3 : 1
        ///HardwareDisabled : 1
        ///NonDynamic : 1
        ///WarmEjectSupported : 1
        ///NoDisplayInUI : 1
        ///Reserved1 : 1
        ///WakeFromInterrupt : 1
        ///SecureDevice : 1
        ///ChildOfVgaEnabledBridge : 1
        ///DecodeIoOnBoot : 1
        ///Reserved : 9
        public uint bitvector1;

        /// <summary>
        /// Specifies an address indicating where the device is located on its underlying bus.
        /// </summary>
        public uint Address;

        /// <summary>
        /// Specifies a number associated with the device that can be displayed in the user interface.
        /// </summary>
        public uint UINumber;

        /// <summary>
        /// An array of values indicating the most-powered device power state that the device can maintain for each system power state.
        /// </summary>
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 7)]
        public DEVICE_POWER_STATE[] DeviceState;

        /// <summary>
        /// Specifies the least-powered system power state from which the device can signal a wake event. 
        /// A value of PowerSystemUnspecified indicates that the device cannot wake the system.
        /// </summary>
        public SYSTEM_POWER_STATE SystemWake;

        /// <summary>
        /// Specifies the least-powered device power state from which the device can signal a wake event. 
        /// A value of PowerDeviceUnspecified indicates that the device cannot signal a wake event.
        /// </summary>
        public DEVICE_POWER_STATE DeviceWake;

        /// <summary>
        /// Specifies the device's approximate worst-case latency, in 100-microsecond units, 
        /// for returning the device to the PowerDeviceD0 state from the PowerDeviceD1 state. 
        /// Set to zero if the device does not support the D1 state.
        /// </summary>
        public uint D1Latency;

        /// <summary>
        /// Specifies the device's approximate worst-case latency, in 100-microsecond units, 
        /// for returning the device to the PowerDeviceD0 state from the PowerDeviceD2 state. 
        /// Set to zero if the device does not support the D2 state.
        /// </summary>
        public uint D2Latency;

        /// <summary>
        /// Specifies the device's approximate worst-case latency, in 100-microsecond units, 
        /// for returning the device to the PowerDeviceD0 state from the PowerDeviceD3 state. 
        /// Set to zero if the device does not support the D3 state.
        /// </summary>
        public uint D3Latency;

        /// <summary>
        /// Specifies whether the device hardware supports the D1 power state. 
        /// Drivers should not change this value.
        /// </summary>
        public uint DeviceD1
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
        /// Specifies whether the device hardware supports the D2 power state. 
        /// Drivers should not change this value.
        /// </summary>
        public uint DeviceD2
        {
            get
            {
                return ((uint)(((this.bitvector1 & 2u)
                            / 2)));
            }
            set
            {
                this.bitvector1 = ((uint)(((value * 2)
                            | this.bitvector1)));
            }
        }

        /// <summary>
        /// Specifies whether the device supports physical-device locking that prevents device ejection. 
        /// This member pertains to ejecting the device from its slot, 
        /// rather than ejecting a piece of removable media from the device.
        /// </summary>
        public uint LockSupported
        {
            get
            {
                return ((uint)(((this.bitvector1 & 4u)
                            / 4)));
            }
            set
            {
                this.bitvector1 = ((uint)(((value * 4)
                            | this.bitvector1)));
            }
        }

        /// <summary>
        /// Specifies whether the device supports software-controlled device ejection while the system is in the PowerSystemWorking state. 
        /// This member pertains to ejecting the device from its slot, 
        /// rather than ejecting a piece of removable media from the device.
        /// </summary>
        public uint EjectSupported
        {
            get
            {
                return ((uint)(((this.bitvector1 & 8u)
                            / 8)));
            }
            set
            {
                this.bitvector1 = ((uint)(((value * 8)
                            | this.bitvector1)));
            }
        }

        /// <summary>
        /// Specifies whether the device can be dynamically removed from its immediate parent. 
        /// If Removable is set to TRUE, the device does not belong to the same physical object as its parent.
        /// </summary>
        public uint Removable
        {
            get
            {
                return ((uint)(((this.bitvector1 & 16u)
                            / 16)));
            }
            set
            {
                this.bitvector1 = ((uint)(((value * 16)
                            | this.bitvector1)));
            }
        }

        /// <summary>
        /// Specifies whether the device is a docking peripheral.
        /// </summary>
        public uint DockDevice
        {
            get
            {
                return ((uint)(((this.bitvector1 & 32u)
                            / 32)));
            }
            set
            {
                this.bitvector1 = ((uint)(((value * 32)
                            | this.bitvector1)));
            }
        }

        /// <summary>
        /// Specifies whether the device's instance ID is unique system-wide.
        /// This bit is clear if the instance ID is unique only within the scope of the bus.
        /// </summary>
        public uint UniqueID
        {
            get
            {
                return ((uint)(((this.bitvector1 & 64u)
                            / 64)));
            }
            set
            {
                this.bitvector1 = ((uint)(((value * 64)
                            | this.bitvector1)));
            }
        }

        /// <summary>
        /// Specifies whether Device Manager should suppress all installation dialog boxes; 
        /// except required dialog boxes such as "no compatible drivers found."
        /// </summary>
        public uint SilentInstall
        {
            get
            {
                return ((uint)(((this.bitvector1 & 128u)
                            / 128)));
            }
            set
            {
                this.bitvector1 = ((uint)(((value * 128)
                            | this.bitvector1)));
            }
        }

        /// <summary>
        /// Specifies whether the driver for the underlying bus can drive the device if there is no function driver (for example, SCSI devices in pass-through mode). 
        /// This mode of operation is called raw mode.
        /// </summary>
        public uint RawDeviceOK
        {
            get
            {
                return ((uint)(((this.bitvector1 & 256u)
                            / 256)));
            }
            set
            {
                this.bitvector1 = ((uint)(((value * 256)
                            | this.bitvector1)));
            }
        }

        /// <summary>
        /// Specifies whether the function driver for the device can handle the case where the device is removed before Windows can send IRP_MN_QUERY_REMOVE_DEVICE to it.
        /// If SurpriseRemovalOK is set to TRUE, the device can be safely removed from its immediate parent regardless of the state that its driver is in.
        /// </summary>
        public uint SurpriseRemovalOK
        {
            get
            {
                return ((uint)(((this.bitvector1 & 512u)
                            / 512)));
            }
            set
            {
                this.bitvector1 = ((uint)(((value * 512)
                            | this.bitvector1)));
            }
        }

        /// <summary>
        /// Specifies whether the device can respond to an external wake signal while in the D0 state. Drivers should not change this value.
        /// </summary>
        public uint WakeFromD0
        {
            get
            {
                return ((uint)(((this.bitvector1 & 1024u)
                            / 1024)));
            }
            set
            {
                this.bitvector1 = ((uint)(((value * 1024)
                            | this.bitvector1)));
            }
        }

        /// <summary>
        /// Specifies whether the device can respond to an external wake signal while in the D1 state. Drivers should not change this value.
        /// </summary>
        public uint WakeFromD1
        {
            get
            {
                return ((uint)(((this.bitvector1 & 2048u)
                            / 2048)));
            }
            set
            {
                this.bitvector1 = ((uint)(((value * 2048)
                            | this.bitvector1)));
            }
        }

        /// <summary>
        /// Specifies whether the device can respond to an external wake signal while in the D2 state. Drivers should not change this value.
        /// </summary>
        public uint WakeFromD2
        {
            get
            {
                return ((uint)(((this.bitvector1 & 4096u)
                            / 4096)));
            }
            set
            {
                this.bitvector1 = ((uint)(((value * 4096)
                            | this.bitvector1)));
            }
        }

        /// <summary>
        /// Specifies whether the device can respond to an external wake signal while in the D3 state. Drivers should not change this value.
        /// </summary>
        public uint WakeFromD3
        {
            get
            {
                return ((uint)(((this.bitvector1 & 8192u)
                            / 8192)));
            }
            set
            {
                this.bitvector1 = ((uint)(((value * 8192)
                            | this.bitvector1)));
            }
        }

        /// <summary>
        /// When set, this flag specifies that the device's hardware is disabled.
        /// A device's parent bus driver or a bus filter driver sets this flag when such a driver determines that the device hardware is disabled.
        /// The PnP manager sends one IRP_MN_QUERY_CAPABILITIES IRP right after a device is enumerated and sends another after the device has been started. 
        /// The PnP manager only checks this bit right after the device is enumerated. Once the device is started, this bit is ignored.
        /// </summary>
        public uint HardwareDisabled
        {
            get
            {
                return ((uint)(((this.bitvector1 & 16384u)
                            / 16384)));
            }
            set
            {
                this.bitvector1 = ((uint)(((value * 16384)
                            | this.bitvector1)));
            }
        }

        /// <summary>
        /// Reserved for future use.
        /// </summary>
        public uint NonDynamic
        {
            get
            {
                return ((uint)(((this.bitvector1 & 32768u)
                            / 32768)));
            }
            set
            {
                this.bitvector1 = ((uint)(((value * 32768)
                            | this.bitvector1)));
            }
        }

        /// <summary>
        /// Reserved for future use.
        /// </summary>
        public uint WarmEjectSupported
        {
            get
            {
                return ((uint)(((this.bitvector1 & 65536u)
                            / 65536)));
            }
            set
            {
                this.bitvector1 = ((uint)(((value * 65536)
                            | this.bitvector1)));
            }
        }

        /// <summary>
        /// Do not display the device in the user interface. 
        /// If this bit is set, the device is never displayed in the user interface, even if the device is present but fails to start. 
        /// Only bus drivers and associated bus filter drivers should set this bit.
        /// (Also see the PNP_DEVICE_DONT_DISPLAY_IN_UI flag in the PNP_DEVICE_STATE structure.)
        /// </summary>
        public uint NoDisplayInUI
        {
            get
            {
                return ((uint)(((this.bitvector1 & 131072u)
                            / 131072)));
            }
            set
            {
                this.bitvector1 = ((uint)(((value * 131072)
                            | this.bitvector1)));
            }
        }

        /// <summary>
        /// Reserved for system use.
        /// </summary>
        public uint Reserved1
        {
            get
            {
                return ((uint)(((this.bitvector1 & 262144u)
                            / 262144)));
            }
            set
            {
                this.bitvector1 = ((uint)(((value * 262144)
                            | this.bitvector1)));
            }
        }

        /// <summary>
        /// Indicates whether the driver or ACPI is responsible for handling the wake event. 
        /// If set, the driver is responsible for handling the wake event. 
        /// ACPI arms the device when it receives an IRP_MN_WAIT_WAKE IRP, but does not connect the interrupt, 
        /// complete the IRP to notify the device stack of a wake event.
        /// </summary>
        public uint WakeFromInterrupt
        {
            get
            {
                return ((uint)(((this.bitvector1 & 524288u)
                            / 524288)));
            }
            set
            {
                this.bitvector1 = ((uint)(((value * 524288)
                            | this.bitvector1)));
            }
        }

        /// <summary>
        /// Indicates whether the device is a secure device.
        /// </summary>
        public uint SecureDevice
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
        /// For a VGA device, indicates whether the parent bridge has the VGA decoding bit set.
        /// </summary>
        public uint ChildOfVgaEnabledBridge
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
        /// Indictates whether the device has IO decode enabled on boot.
        /// </summary>
        public uint DecodeIoOnBoot
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
        /// Reserved for system use.
        /// </summary>
        public uint Reserved
        {
            get
            {
                return ((uint)(((this.bitvector1 & 4286578688u)
                            / 8388608)));
            }
            set
            {
                this.bitvector1 = ((uint)(((value * 8388608)
                            | this.bitvector1)));
            }
        }

    }
}
