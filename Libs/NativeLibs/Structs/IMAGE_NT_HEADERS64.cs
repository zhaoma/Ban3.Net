//  ————————————————————————————————————————————————————————————————————————————
//  zhaoma @ 2023/4/1 17:30
//  function:	IMAGE_NT_HEADERS64.cs
//  reference:	
//  ————————————————————————————————————————————————————————————————————————————
//
using System;
using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{

    [StructLayout(LayoutKind.Explicit)]
    public struct IMAGE_NT_HEADERS64
    {
        [FieldOffset(0)] public UInt32 Signature;

        [FieldOffset(4)] public IMAGE_FILE_HEADER FileHeader;

        [FieldOffset(24)] public IMAGE_OPTIONAL_HEADER64 OptionalHeader;
    }
}

