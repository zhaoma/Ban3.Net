using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The BOOTDISK_INFORMATION structure contains basic information describing the boot and system disks.
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ns-wdm-_bootdisk_information
    /// IoGetBootDiskInformation returns this structure to describe the boot and system disks.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct BOOTDISK_INFORMATION
    {
        /// <summary>
        /// Specifies the offset, in bytes, on the boot disk where the boot partition begins.
        /// </summary>
        public long BootPartitionOffset;

        /// <summary>
        /// Specifies the offset, in bytes, on the system disk where the system partition begins.
        /// </summary>
        public long SystemPartitionOffset;

        /// <summary>
        /// If the boot disk is formatted with an MBR partition table, 
        /// this specifies the signature for the disk's MBR partition table. 
        /// Otherwise, this member is unused.
        /// </summary>
        public uint BootDeviceSignature;

        /// <summary>
        /// If the system disk is formatted with an MBR partition table, 
        /// this specifies the signature for the disk's MBR partition table. 
        /// Otherwise, this member is unused.
        /// </summary>
        public uint SystemDeviceSignature;
    }
}