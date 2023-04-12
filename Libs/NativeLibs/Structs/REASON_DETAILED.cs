using System;
using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    [StructLayout(LayoutKind.Sequential)]
    public struct REASON_DETAILED
    {
        /// <summary>
        /// The module that contains the string resource.
        /// </summary>
        public IntPtr LocalizedReasonModule;

        /// <summary>
        /// The ID of the string resource.
        /// </summary>
        public uint LocalizedReasonId;

        /// <summary>
        /// The number of strings in the ReasonStrings parameter.
        /// </summary>
        public uint ReasonStringCount;

        /// <summary>
        /// An array of strings to be substituted in the string resource at run time.
        /// </summary>
        public IntPtr ReasonStrings;
    }
}
