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
    public struct COUNTED_REASON_CONTEXT
    {
        /// <summary>
        /// The version number of the structure. Set this member to DIAGNOSTIC_REASON_VERSION.
        /// </summary>
        public uint Version;

        /// <summary>
        /// Indicates whether the structure contains a simple reason string or a detailed set of reason strings.
        /// DIAGNOSTIC_REASON_SIMPLE_STRING
        /// DIAGNOSTIC_REASON_DETAILED_STRING
        /// If Flags = DIAGNOSTIC_REASON_SIMPLE_STRING, the SimpleString member of the union is valid. 
        /// If Flags = DIAGNOSTIC_REASON_DETAILED_STRING, the ResourceFileName, ResourceReasonId, StringCount, and ReasonStrings members are valid (and the SimpleString member is not valid).
        /// </summary>
        public uint Flags;

        /// Anonymous_04dabf8f_3860_4f89_9e83_bbadbac21e84
        public COUNTED_REASON_CONTEXT_UNION Union1;
    }
    
    [StructLayout(LayoutKind.Explicit)]
    public struct COUNTED_REASON_CONTEXT_UNION
    {

        /// Anonymous_aaec3476_366b_4dee_b596_bce36181ff98
        [FieldOffset(0)]
        public COUNTED_REASON_CONTEXT_DUMMY DUMMYSTRUCTNAME;

        /// <summary>
        /// A pointer to a wide-character, null-terminated string that explains the reason for a power request. 
        /// This member is valid only if Flags = DIAGNOSTIC_REASON_SIMPLE_STRING.
        /// </summary>
        [FieldOffset(0)]
        public UNICODE_STRING SimpleString;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct COUNTED_REASON_CONTEXT_DUMMY
    {
        /// <summary>
        /// A pointer to a wide-character, null-terminated string that contains the pathname of a resource file.
        /// </summary>
        public UNICODE_STRING ResourceFileName;

        /// <summary>
        /// The resource ID assigned to the first reason string in the resource file that is specified by ResourceFileName. 
        /// This member is valid only if Flags = DIAGNOSTIC_REASON_DETAILED_STRING.
        /// </summary>
        public ushort ResourceReasonId;

        /// <summary>
        /// The number of reason strings in the ReasonStrings array or in the resource file that is specified by ResourceFileName. 
        /// This member is valid only if Flags = DIAGNOSTIC_REASON_DETAILED_STRING.
        /// </summary>
        public uint StringCount;

        /// <summary>
        /// A pointer to an array of string pointers. Each array element is a pointer to a wide-character, null-terminated string. 
        /// The number of array elements is specified by StringCount.
        /// This member is valid only if Flags = DIAGNOSTIC_REASON_DETAILED_STRING.
        /// </summary>
        public IntPtr ReasonStrings;
    }
}
