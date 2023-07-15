//  ————————————————————————————————————————————————————————————————————————————
//  zhaoma @ 2023/4/1 17:30
//  function:	IMAGE_FILE_HEADER.cs
//  reference:	
//  ————————————————————————————————————————————————————————————————————————————
//
using System;
using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    [StructLayout(LayoutKind.Sequential)]
    public struct IMAGE_FILE_HEADER
    {
        public UInt16 Machine;
        public UInt16 NumberOfSections;
        public UInt32 TimeDateStamp;
        public UInt32 PointerToSymbolTable;
        public UInt32 NumberOfSymbols;
        public UInt16 SizeOfOptionalHeader;
        public UInt16 Characteristics;
    }
}

