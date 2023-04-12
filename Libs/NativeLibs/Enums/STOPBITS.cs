using System;
using System.Collections.Generic;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Enums
{
    /// <summary>
    /// The number of stop bits to be used. This member can be one of the following values.
    /// </summary>
    public enum STOPBITS : byte
    {
        /// <summary>
        /// 1 stop bit.
        /// </summary>
        ONESTOPBIT = 0,
        /// <summary>
        /// 1.5 stop bits.
        /// </summary>
        ONE5STOPBITS = 1,
        /// <summary>
        /// 2 stop bits.
        /// </summary>
        TWOSTOPBITS = 2
    }
}
