using Ban3.Infrastructures.NativeLibs.Enums;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The IO_ERROR_LOG_PACKET structure serves as the header for an error log entry.
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ns-wdm-_io_error_log_packet
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct IO_ERROR_LOG_PACKET
    {
        /// <summary>
        /// Indicates the IRP_MJ_XXX major function code of the IRP the driver was handling when the error occurred. 
        /// Setting this value is optional.
        /// </summary>
        public byte MajorFunctionCode;

        /// <summary>
        /// Indicates the number of times the driver has retried the operation and encountered this error. 
        /// Use zero to indicate the driver attempted the operation once, or add one for each retry beyond the initial attempt.
        /// </summary>
        public byte RetryCount;

        /// <summary>
        /// Indicates the size, in bytes, of the variable-length DumpData member of this structure. 
        /// The specified value must be a multiple of sizeof(ULONG).
        /// </summary>
        public ushort DumpDataSize;

        /// <summary>
        /// Indicates the number of insertion strings the driver will supply with this error log entry. 
        /// Drivers set this value to zero for errors that need no insertion strings. 
        /// The Event Viewer uses these strings to fill in the "%2" through "%n" entries in the string template for this error code.
        /// 
        /// The null-terminated Unicode strings themselves follow the IO_ERROR_LOG_PACKET structure in memory.
        /// </summary>
        public ushort NumberOfStrings;

        /// <summary>
        /// Indicates the offset, in bytes, from the beginning of the structure, at which any driver-supplied insertion string data begins. 
        /// Normally this will be sizeof(IO_ERROR_LOG_PACKET) plus the value of the DumpDataSize member. 
        /// If there are no driver-supplied insertion strings, StringOffset can be zero.
        /// </summary>
        public ushort StringOffset;

        /// <summary>
        /// Specifies the event category for the error. 
        /// A driver specifies the event categories it supports and corresponding descriptive strings in its message catalog. 
        /// The Event Viewer displays the descriptive string as the Category value for the error.
        /// </summary>
        public ushort EventCategory;

        /// <summary>
        /// Specifies the type of error. The Event Viewer uses the error code to determine which string to display as the Description value for the error. 
        /// The Event Viewer takes the string template for the error supplied in the driver's message catalog, 
        /// replaces "%1" in the template with the name of the driver's device object,
        /// and replaces "%2" through "%n" with the insertion strings supplied with the error log entry.
        /// </summary>
        public NTSTATUS ErrorCode;

        /// <summary>
        /// A driver-specific value that indicates where the error was detected in the driver. 
        /// Setting this value is optional.
        /// </summary>
        public uint UniqueErrorValue;

        /// <summary>
        /// Specifies the NTSTATUS value to be returned for the operation that triggered the error. 
        /// Setting this value is optional.
        /// </summary>
        public NTSTATUS FinalStatus;

        /// <summary>
        /// Specifies a driver-assigned sequence number for the current IRP, which should be constant for the life of a given request. 
        /// Setting this value is optional.
        /// </summary>
        public uint SequenceNumber;

        /// <summary>
        /// For an IRP_MJ_DEVICE_CONTROL or IRP_MJ_INTERNAL_DEVICE_CONTROL IRP, this member specifies the I/O control code for the request that trigged the error.
        /// Otherwise, this value is zero. 
        /// Setting this value is optional.
        /// </summary>
        public uint IoControlCode;

        /// <summary>
        /// Specifies the driver-specified offset into the device where the error occurred.
        /// Setting this value is optional.
        /// </summary>
        public LARGE_INTEGER DeviceOffset;

        /// <summary>
        /// A variable-size array that can be used to store driver-specific binary data, 
        /// such as register values or any other information useful in identifying the cause of the error. 
        /// Drivers must specify the size, in bytes, of the array in the DumpDataSize member of this structure.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1, ArraySubType = UnmanagedType.U4)]
        public uint[] DumpData;
    }
}
