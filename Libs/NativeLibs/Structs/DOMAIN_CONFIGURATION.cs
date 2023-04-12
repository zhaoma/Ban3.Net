using Ban3.Infrastructures.NativeLibs.Enums;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// Contains information required to configure a domain. 
    /// This structure is used by the IOMMU_DOMAIN_CONFIGURE callback function.
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ns-wdm-_domain_configuration
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct DOMAIN_CONFIGURATION
    {
        /// <summary>
        /// A DOMAIN_CONFIGURATION_ARCH-type value that indicates the domain architecture.
        /// </summary>
        public DOMAIN_CONFIGURATION_ARCH Type;

        public DOMAIN_CONFIGURATION_UNION Union1;
    }


    [StructLayout(LayoutKind.Explicit)]
    public struct DOMAIN_CONFIGURATION_UNION
    {
        [FieldOffset(0)]
        public DOMAIN_CONFIGURATION_ARM64 Arm64;

        [FieldOffset(0)]
        public DOMAIN_CONFIGURATION_X64 X64;
    }


    /// <summary>
    /// Contains information required to configure a domain for an ARM64 system.
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ns-wdm-_domain_configuration_arm64
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct DOMAIN_CONFIGURATION_ARM64
    {

        /// ULONG->unsigned int
        public PHYSICAL_ADDRESS Ttbr0;

        /// ULONG->unsigned int
        public PHYSICAL_ADDRESS Ttbr1;

        /// ULONG->unsigned int
        public uint Mair0;

        /// ULONG->unsigned int
        public uint Mair1;

        /// UCHAR->unsigned char
        public byte InputSize0;

        /// UCHAR->unsigned char
        public byte InputSize1;

        /// BOOLEAN->BYTE->unsigned char
        public byte CoherentTableWalks;

        /// BOOLEAN->BYTE->unsigned char
        public byte TranslationEnabled;
    }

    /// <summary>
    /// Contains information required to configure a domain for an ARM64 system.
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ns-wdm-_domain_configuration_arm64
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct DOMAIN_CONFIGURATION_X64
    {

        /// ULONG->unsigned int
        public PHYSICAL_ADDRESS FirstLevelPageTableRoot;

        /// ULONG->unsigned int
        public bool TranslationEnabled;
    }
}
