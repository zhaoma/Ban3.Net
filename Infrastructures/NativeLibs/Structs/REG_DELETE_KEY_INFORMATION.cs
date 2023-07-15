//  ————————————————————————————————————————————————————————————————————————————
//  zhaoma @ 2023/3/26 10:18
//  function:	REG_DELETE_KEY_INFORMATION.cs
//  reference:	
//  ————————————————————————————————————————————————————————————————————————————
//
using Ban3.Infrastructures.NativeLibs.Enums;
using System;
using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    [StructLayout(LayoutKind.Sequential)]
    public struct REG_DELETE_KEY_INFORMATION
    {
        /// PVOID->void*
        public System.IntPtr Object;

        /// PVOID->void*
        public System.IntPtr CallContext;

        /// PVOID->void*
        public System.IntPtr ObjectContext;

        /// PVOID->void*
        public System.IntPtr Reserved;

    }
}

