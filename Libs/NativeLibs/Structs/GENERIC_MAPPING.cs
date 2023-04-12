using Ban3.Infrastructures.NativeLibs.Enums;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// The GENERIC_MAPPING structure describes the ACCESS_MASK value of specific access rights associated with each type of generic access right.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct GENERIC_MAPPING
    {
        /// <summary>
        /// Describes the specific access rights corresponding to the GENERIC_READ access right.
        /// </summary>
        public ACCESS_MASK GenericRead;

        /// <summary>
        /// Describes the specific access rights corresponding to the GENERIC_WRITE access right.
        /// </summary>
        public ACCESS_MASK GenericWrite;

        /// <summary>
        /// Describes the specific access rights corresponding to the GENERIC_EXECUTE access right.
        /// </summary>
        public ACCESS_MASK GenericExecute;

        /// <summary>
        /// Describes the specific access rights corresponding to the GENERIC_ALL access right.
        /// </summary>
        public ACCESS_MASK GenericAll;

    }
}
