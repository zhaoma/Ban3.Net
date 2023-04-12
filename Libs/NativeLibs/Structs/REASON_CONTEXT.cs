
using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    [StructLayout(LayoutKind.Sequential)]
    public struct REASON_CONTEXT
    {
        /// <summary>
        /// The version number of the structure. 
        /// This parameter must be set to POWER_REQUEST_CONTEXT_VERSION.
        /// </summary>
        public uint Version;

        /// <summary>
        /// The format of the reason for the power request. 
        /// This parameter can be one of the following values:
        /// POWER_REQUEST_CONTEXT_DETAILED_STRING       0x00000002      The Detailed structure identifies a localizable string resource 
        ///                                                             that describes the reason for the power request.
        /// POWER_REQUEST_CONTEXT_SIMPLE_STRING         0x00000001      The SimpleReasonString parameter contains a simple, 
        ///                                                             non-localizable string that describes the reason for the power request.
        /// </summary>
        public uint Flags;

        /// <summary>
        /// A union that consists of either a Detailed structure or a string.
        /// </summary>
        public REASON Reason;

    }
}
