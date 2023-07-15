using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    [StructLayout(LayoutKind.Sequential)]
    public struct REG_CREATE_KEY_INFORMATION_V1
    {

        /// PVOID->void*
        public System.IntPtr CompleteName;

        /// PVOID->void*
        public System.IntPtr RootObject;

        /// PVOID->void*
        public System.IntPtr ObjectType;

        /// ULONG->unsigned int
        public uint Options;

        /// PVOID->void*
        public System.IntPtr Class;

        /// PVOID->void*
        public System.IntPtr SecurityDescriptor;

        /// PVOID->void*
        public System.IntPtr SecurityQualityOfService;

        /// ACCESS_MASK->DWORD->unsigned int
        public uint DesiredAccess;

        /// ACCESS_MASK->DWORD->unsigned int
        public uint GrantedAccess;

        /// PULONG->ULONG*
        public System.IntPtr Disposition;

        /// PVOID*
        public System.IntPtr ResultObject;

        /// PVOID->void*
        public System.IntPtr CallContext;

        /// PVOID->void*
        public System.IntPtr RootObjectContext;

        /// PVOID->void*
        public System.IntPtr Transaction;

        /// ULONG_PTR->unsigned int
        public uint Version;

        /// PVOID->void*
        public System.IntPtr RemainingName;

        /// ULONG->unsigned int
        public uint Wow64Flags;

        /// ULONG->unsigned int
        public uint Attributes;

        /// PVOID->void*
        public System.IntPtr CheckAccessMode;

    }
}
