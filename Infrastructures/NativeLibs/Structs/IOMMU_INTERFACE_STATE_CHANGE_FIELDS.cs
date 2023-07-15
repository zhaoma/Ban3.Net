using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// IOMMU_INTERFACE_STATE_CHANGE_FIELDS represents the fields of an IOMMU_INTERFACE_STATE_CHANGE, 
    /// indicating the caller's wish to be notified of a change of a specific state field(s) or indicating to callback owners which states have changed.
    /// </summary>
    [StructLayout(LayoutKind.Explicit)]
    public struct IOMMU_INTERFACE_STATE_CHANGE_FIELDS
    {
        /// <summary>
        /// various states of an IOMMU interface.
        /// </summary>
        [FieldOffset(0)]
        public IOMMU_INTERFACE_STATE_CHANGE_FIELDS_DUMMY DUMMYSTRUCTNAME;

        /// <summary>
        /// The consolidated values of the fields in DUMMYSTRUCTNAME.
        /// </summary>
        [FieldOffset(0)]
        public uint AsULONG;
    }

    /// <summary>
    /// A structure containing various states of an IOMMU interface.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct IOMMU_INTERFACE_STATE_CHANGE_FIELDS_DUMMY
    {
        /// <summary>
        /// When set to 1, this indicates that the caller wants to be notified (via the provided callback) 
        /// when the available domain types change or this indicates to callback owners that the available domain types have changed.
        /// </summary>
        public uint AvailableDomainTypes;

        /// <summary>
        /// Reserved for future fields. Currently unused.
        /// </summary>
        public uint Reserved;
    }
}
