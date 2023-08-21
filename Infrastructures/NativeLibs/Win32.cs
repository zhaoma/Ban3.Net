using Ban3.Infrastructures.NativeLibs.Interfaces.Modules;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs
{
    /// 
    public static class Win32
    {
        /// <summary>
        /// Open
        /// Close
        /// Empty
        /// RegisterFormat
        /// Get
        /// Set
        /// GetString
        /// SetString
        /// </summary>
        public static IClipboard Clipboard;
        
        /// 
        public static IPower Power;

        /// 
        public static IRegistry Registry;
    }
}
