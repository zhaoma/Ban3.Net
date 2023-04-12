using System;
using System.Collections.Generic;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Enums
{
    /// <summary>
    /// The parity scheme to be used. This member can be one of the following values.
    /// </summary>
    public enum Parity : byte
    {
        /// <summary>
        /// No parity.
        /// </summary>
        NOPARITY = 0,

        /// <summary>
        /// Odd parity.
        /// </summary>
        ODDPARITY = 1,

        /// <summary>
        /// Even parity.
        /// </summary>
        EVENPARITY = 2,

        /// <summary>
        /// Mark parity.
        /// </summary>
        MARKPARITY = 3,

        /// <summary>
        /// Space parity.
        /// </summary>
        SPACEPARITY = 4
    }
}
