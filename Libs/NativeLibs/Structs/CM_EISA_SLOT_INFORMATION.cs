using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The CM_EISA_SLOT_INFORMATION structure defines EISA configuration header information 
    /// returned by HalGetBusData for the input BusDataType = EisaConfiguration, 
    /// or by HalGetBusDataByOffset for the inputs BusDataType = EisaConfiguration and Offset = 0, 
    /// assuming the caller-allocated Buffer is of sufficient Length.
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ns-wdm-_cm_eisa_slot_information
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct CM_EISA_SLOT_INFORMATION
    {
        /// <summary>
        /// Contains a status code if an error occurs when the EISA BIOS is queried. Possible status codes include the following:
        /// EISA_INVALID_SLOT
        /// EISA_INVALID_FUNCTION
        /// EISA_INVALID_CONFIGURATION
        /// EISA_EMPTY_SLOT
        /// EISA_INVALID_BIOS_CALL
        /// </summary>
        public byte ReturnCode;

        /// <summary>
        /// The return flags.
        /// </summary>
        public byte ReturnFlags;

        /// <summary>
        /// Information supplied by the manufacturer.
        /// </summary>
        public byte MajorRevision;

        /// <summary>
        /// Information supplied by the manufacturer.
        /// </summary>
        public byte MinorRevision;

        /// <summary>
        /// The checksum value, allowing validation of the configuration data.
        /// </summary>
        public ushort Checksum;

        /// <summary>
        /// The number at this slot.
        /// </summary>
        public byte NumberFunctions;

        /// <summary>
        /// Whether there is available CM_EISA_FUNCTION_INFORMATION for this slot.
        /// </summary>
        public byte FunctionInformation;

        /// <summary>
        /// The EISA compressed identification of the device at this slot.
        /// </summary>
        public uint CompressedId;
    }
}
