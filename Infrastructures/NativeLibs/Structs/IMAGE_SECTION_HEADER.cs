//  ————————————————————————————————————————————————————————————————————————————
//  zhaoma @ 2023/4/1 17:28
//  function:	IMAGE_SECTION_HEADER.cs
//  reference:	
//  ————————————————————————————————————————————————————————————————————————————
//
using System;
using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{

    [StructLayout(LayoutKind.Explicit)]
    public unsafe struct IMAGE_SECTION_HEADER
    {
        [FieldOffset(0)]
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public char[] Name;

        [FieldOffset(8)] public UInt32 VirtualSize;
        [FieldOffset(12)] public UInt32 VirtualAddress;
        [FieldOffset(16)] public UInt32 SizeOfRawData;
        [FieldOffset(20)] public UInt32 PointerToRawData;
        [FieldOffset(24)] public UInt32 PointerToRelocations;
        [FieldOffset(28)] public UInt32 PointerToLinenumbers;
        [FieldOffset(32)] public UInt16 NumberOfRelocations;
        [FieldOffset(34)] public UInt16 NumberOfLinenumbers;
        [FieldOffset(36)] public UInt32 Characteristics;

        public string Section
        {

            get { return new string(Name); }
        }
    }
}

