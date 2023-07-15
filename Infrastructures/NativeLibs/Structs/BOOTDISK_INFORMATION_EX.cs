using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// 
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct BOOTDISK_INFORMATION_EX
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

        /// <summary>
        /// If the BootDeviceIsGpt member is TRUE, this specifies the GUID for the boot disk. Otherwise, this member is unused.
        /// </summary>
        public GUID BootDeviceGuid;

        /// <summary>
        /// If the SystemDeviceIsGpt member is TRUE, this specifies the GUID for the boot disk. Otherwise, this member is unused.
        /// </summary>
        public GUID SystemDeviceGuid;

        /// <summary>
        /// TRUE if the boot disk is formatted with the GPT partition table type.
        /// </summary>
        public byte BootDeviceIsGpt;

        /// <summary>
        /// TRUE if the system disk is formatted with the GPT partition table type.
        /// </summary>
        public byte SystemDeviceIsGpt;
    }
}
