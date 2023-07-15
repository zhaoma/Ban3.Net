using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// A union that consists of either a Detailed structure or a string.
    /// </summary>
    [StructLayout(LayoutKind.Explicit)]
    public struct REASON
    {
        /// <summary>
        /// A structure that identifies a localizable string resource to describe the reason for the power request.
        /// </summary>
        [FieldOffset(0)]
        public REASON_DETAILED Detailed;

        /// <summary>
        /// A non-localized string that describes the reason for the power request.
        /// </summary>
        [FieldOffset(0)]
        public string SimpleReasonString;
    }
}
