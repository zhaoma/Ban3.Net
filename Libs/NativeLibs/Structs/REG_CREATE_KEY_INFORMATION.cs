//  ————————————————————————————————————————————————————————————————————————————
//  zhaoma @ 2023/3/26 09:41
//  function:	REG_CREATE_KEY_INFORMATION.cs
//  reference:	https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ns-wdm-_reg_create_key_information
//  ————————————————————————————————————————————————————————————————————————————
//
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Ban3.Infrastructures.NativeLibs.Enums;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    [StructLayout(LayoutKind.Sequential)]
    public struct REG_CREATE_KEY_INFORMATION
	{
        public IntPtr  CompleteName;
        public IntPtr RootObject;
        public IntPtr ObjectType;
        public uint CreateOptions;
        public IntPtr Class;
        public IntPtr SecurityDescriptor;
        public IntPtr SecurityQualityOfService;
        public ACCESS_MASK DesiredAccess;
        public ACCESS_MASK GrantedAccess;
        public uint Disposition;
        public IntPtr ResultObject;
        public IntPtr CallContext;
        public IntPtr RootObjectContext;
        public IntPtr Transaction;
        public IntPtr Reserved;
    }
}

