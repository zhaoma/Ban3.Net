using Ban3.Infrastructures.NativeLibs.Enums;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The CLFS_MGMT_POLICY structure holds a description of a policy for managing a CLFS log.
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ns-wdm-_clfs_mgmt_policy
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct CLFS_MGMT_POLICY
    {
        /// <summary>
        /// The version of the CLFS_MGMT_POLICY structure. Set this to CLFS_MGMT_POLICY_VERSION.
        /// </summary>
        public uint Version;

        /// <summary>
        /// The length of the CLFS_MGMT_POLICY structure.
        /// </summary>
        public uint LengthInBytes;

        /// <summary>
        /// The flags that apply to this instance of the CLFS_MGMT_POLICY structure. 
        /// The only flag that has been implemented for this release is LOG_POLICY_OVERWRITE, 
        /// which indicates that when the policy is installed, 
        /// it will replace the policy of the same type, if such a policy already exists.
        /// </summary>
        public uint PolicyFlags;

        /// <summary>
        /// A value of the CLFS_MGMT_POLICY_TYPE enumeration that supplies the type of this instance of the CLFS_MGMT_POLICY structure.
        /// </summary>
        public CLFS_MGMT_POLICY_TYPE PolicyType;

        /// <summary>
        /// The union that provides the detailed information about this instance of the CLFS_MGMT_POLICY structure.
        /// </summary>
        public CLFS_MGMT_POLICY_PARAMETERS PolicyParameters;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct CLFS_MGMT_POLICY_CONTAINERS
    {

        /// ULONG->unsigned int
        public uint Containers;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct CLFS_MGMT_POLICY_SIZE
    {

        /// ULONG->unsigned int
        public uint SizeInBytes;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct CLFS_MGMT_POLICY_GROWTH
    {

        /// ULONG->unsigned int
        public uint AbsoluteGrowthInContainers;

        /// ULONG->unsigned int
        public uint RelativeGrowthPercentage;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct CLFS_MGMT_POLICY_AVAILABLE
    {

        /// ULONG->unsigned int
        public uint MinimumAvailablePercentage;

        /// ULONG->unsigned int
        public uint MinimumAvailableContainers;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct CLFS_MGMT_POLICY_PERCENTAGE
    {

        /// ULONG->unsigned int
        public uint Percentage;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct CLFS_MGMT_POLICY_ENABLED
    {

        /// ULONG->unsigned int
        public uint Enabled;
    }

    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential, CharSet = System.Runtime.InteropServices.CharSet.Unicode)]
    public struct CLFS_MGMT_POLICY_PREFIX
    {

        /// USHORT->unsigned short
        public ushort PrefixLengthInBytes;

        /// WCHAR[1]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1)]
        public string PrefixString;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct CLFS_MGMT_POLICY_SUFFIX
    {

        /// ULONGLONG->unsigned __int64
        public ulong NextContainerSuffix;
    }

    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Sequential, CharSet = System.Runtime.InteropServices.CharSet.Unicode)]
    public struct CLFS_MGMT_POLICY_EXTENSION
    {

        /// USHORT->unsigned short
        public ushort ExtensionLengthInBytes;

        /// WCHAR[1]
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1)]
        public string ExtensionString;
    }

    /// <summary>
    /// The union that provides the detailed information about this instance of the CLFS_MGMT_POLICY structure.
    /// </summary>
    [System.Runtime.InteropServices.StructLayoutAttribute(System.Runtime.InteropServices.LayoutKind.Explicit)]
    public struct CLFS_MGMT_POLICY_PARAMETERS
    {
        /// <summary>
        /// The structure that provides the detailed information about a policy whose PolicyType is ClfsMgmtPolicyMaximumSize.
        /// </summary>
        [FieldOffsetAttribute(0)]
        public CLFS_MGMT_POLICY_CONTAINERS MaximumSize;

        /// <summary>
        /// The structure that provides the detailed information about a policy whose PolicyType is ClfsMgmtPolicyMinimumSize.
        /// </summary>
        [FieldOffsetAttribute(0)]
        public CLFS_MGMT_POLICY_CONTAINERS MinimumSize;

        /// <summary>
        /// The structure that provides the detailed information about a policy whose PolicyType is ClfsMgmtPolicyNewContainerSize.
        /// </summary>
        [FieldOffsetAttribute(0)]
        public CLFS_MGMT_POLICY_SIZE NewContainerSize;

        /// <summary>
        /// The structure that provides the detailed information about a policy whose PolicyType is ClfsMgmtPolicyGrowthRate.
        /// </summary>
        [FieldOffsetAttribute(0)]
        public CLFS_MGMT_POLICY_GROWTH GrowthRate;

        /// <summary>
        /// The structure that provides the detailed information about a policy whose PolicyType is ClfsMgmtPolicyLogTail.
        /// </summary>
        [FieldOffsetAttribute(0)]
        public CLFS_MGMT_POLICY_AVAILABLE LogTail;

        /// <summary>
        /// The structure that provides the detailed information about a policy whose PolicyType is ClfsMgmtPolicyAutoShrink.
        /// </summary>
        [FieldOffsetAttribute(0)]
        public CLFS_MGMT_POLICY_PERCENTAGE AutoShrink;

        /// <summary>
        /// The structure that provides the detailed information about a policy whose PolicyType is ClfsMgmtPolicyAutoGrow.
        /// </summary>
        [FieldOffsetAttribute(0)]
        public CLFS_MGMT_POLICY_ENABLED AutoGrow;

        /// <summary>
        /// The structure that provides the detailed information about a policy whose PolicyType is ClfsMgmtPolicyNewContainerPrefix.
        /// </summary>
        [FieldOffsetAttribute(0)]
        public CLFS_MGMT_POLICY_PREFIX NewContainerPrefix;

        /// <summary>
        /// The structure that provides the detailed information about a policy whose PolicyType is ClfsMgmtPolicyNewContainerSuffix.
        /// </summary>
        [FieldOffsetAttribute(0)]
        public CLFS_MGMT_POLICY_SUFFIX NewContainerSuffix;

        /// <summary>
        /// The structure that provides the detailed information about a policy whose PolicyType is ClfsMgmtPolicyNewContainerExtension.
        /// </summary>
        [FieldOffsetAttribute(0)]
        public CLFS_MGMT_POLICY_EXTENSION NewContainerExtension;
    }

}
