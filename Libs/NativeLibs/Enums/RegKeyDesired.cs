using System;
using System.Collections.Generic;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Enums
{
    public enum RegKeyDesired:uint
    {
        /// <summary>
        /// Delete the key from the 32-bit registry view.
        /// </summary>
        KEY_WOW64_32KEY=0x0200,

        /// <summary>
        /// Delete the key from the 64-bit registry view.
        /// </summary>
        KEY_WOW64_64KEY = 0x0100
    }
}
