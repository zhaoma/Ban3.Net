using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The CM_FLOPPY_DEVICE_DATA structure defines a device-type-specific data record 
    /// that is stored in the \Registry\Machine\Hardware\Description tree for a floppy controller 
    /// if the system can collect this information during the boot process.
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ns-wdm-_cm_floppy_device_data
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct CM_FLOPPY_DEVICE_DATA
    {
        /// USHORT->unsigned short
        public ushort Version;

        /// USHORT->unsigned short
        public ushort Revision;

        /// CHAR[8]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 8)]
        public string Size;

        /// ULONG->unsigned int
        public uint MaxDensity;

        /// ULONG->unsigned int
        public uint MountDensity;

        /// UCHAR->unsigned char
        public byte StepRateHeadUnloadTime;

        /// UCHAR->unsigned char
        public byte HeadLoadTime;

        /// UCHAR->unsigned char
        public byte MotorOffTime;

        /// UCHAR->unsigned char
        public byte SectorLengthCode;

        /// UCHAR->unsigned char
        public byte SectorPerTrack;

        /// UCHAR->unsigned char
        public byte ReadWriteGapLength;

        /// UCHAR->unsigned char
        public byte DataTransferLength;

        /// UCHAR->unsigned char
        public byte FormatGapLength;

        /// UCHAR->unsigned char
        public byte FormatFillCharacter;

        /// UCHAR->unsigned char
        public byte HeadSettleTime;

        /// UCHAR->unsigned char
        public byte MotorSettleTime;

        /// UCHAR->unsigned char
        public byte MaximumTrackValue;

        /// UCHAR->unsigned char
        public byte DataTransferRate;
    }
}
