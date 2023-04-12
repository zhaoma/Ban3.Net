//  ————————————————————————————————————————————————————————————————————————————
//  zhaoma @ 2023/3/26 09:27
//  function:	PRIVILEGE_SET.cs
//  reference:	https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ns-wdm-_privilege_set
//  ————————————————————————————————————————————————————————————————————————————
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Structs
{

    [StructLayout(LayoutKind.Sequential)]
    public struct PRIVILEGE_SET
	{
        public uint  PrivilegeCount;
        public uint  Control;
        public byte[]  Privilege;
    }
}

