//  ————————————————————————————————————————————————————————————————————————————
//  zhaoma @ 2023/4/1 17:31
//  function:	IMAGE_DATA_DIRECTORY.cs
//  reference:	
//  ————————————————————————————————————————————————————————————————————————————
//
using System;
using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    [StructLayout(LayoutKind.Sequential)]
    public struct IMAGE_DATA_DIRECTORY
    {
        public UInt32 VirtualAddress;
        public UInt32 Size;
    }
}

