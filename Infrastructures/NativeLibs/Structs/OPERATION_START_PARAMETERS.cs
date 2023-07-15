
using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// This structure is used by the OperationEnd function.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct OPERATION_START_PARAMETERS
    {
        /// <summary>
        /// This parameter should be initialized to the OPERATION_API_VERSION defined in the Windows SDK.
        /// OPERATION_API_VERSION                   1       This API was introduced in Windows 8 and Windows Server 2012 as version 1.
        /// </summary>
        public uint Version;

        /// <summary>
        /// A identifier that corresponds to the operation having file access patterns recorded. 
        /// The value should be unique for each operation that the developer intends to record.
        /// </summary>
        public uint OperationId;

        /// <summary>
        /// The value of this parameter can include any combination of the following values.
        /// OPERATION_START_TRACE_CURRENT_THREAD    1       Specifies that the system should discard the information it has been tracking for this operation.Specify this flag when the operation either fails or does not follow the expected sequence of steps.
        /// </summary>
        public uint Flags;

    }
}
