//  ————————————————————————————————————————————————————————————————————————————
//  zhaoma @ 2023/4/1 17:32
//  function:	MODULEINFO.cs
//  reference:	
//  ————————————————————————————————————————————————————————————————————————————
//
using System;
using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    [StructLayout(LayoutKind.Sequential)]
    public struct MODULEINFO
    {
        public IntPtr lpBaseOfDll;
        public uint SizeOfImage;
        public IntPtr EntryPoint;
    }
}

