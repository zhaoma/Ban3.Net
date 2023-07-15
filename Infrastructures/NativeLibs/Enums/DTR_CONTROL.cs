using System;
using System.Collections.Generic;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Enums
{
    /// <summary>
    /// The DTR (data-terminal-ready) flow control. This member can be one of the following values.
    /// </summary>
    public enum DTR_CONTROL:uint
    {
        /// <summary>
        /// Disables the DTR line when the device is opened and leaves it disabled.
        /// </summary>
        DTR_CONTROL_DISABLE = 0x00,

        /// <summary>
        /// Enables the DTR line when the device is opened and leaves it on.
        /// </summary>
        DTR_CONTROL_ENABLE = 0x01,

        /// <summary>
        /// Enables DTR handshaking. If handshaking is enabled, it is an error for the application to adjust the line by using the EscapeCommFunction function.
        /// </summary>
        DTR_CONTROL_HANDSHAKE = 0x02
    }
}
