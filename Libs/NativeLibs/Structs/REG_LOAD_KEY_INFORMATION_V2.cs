using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    [StructLayout(LayoutKind.Sequential)]
    public struct REG_LOAD_KEY_INFORMATION_V2
    {
        /// PVOID->void*
        public System.IntPtr Object;

        /// PVOID->void*
        public System.IntPtr KeyName;

        /// PVOID->void*
        public System.IntPtr SourceFile;

        /// ULONG->unsigned int
        public uint Flags;

        /// PVOID->void*
        public System.IntPtr TrustClassObject;

        /// PVOID->void*
        public System.IntPtr UserEvent;

        /// ACCESS_MASK->DWORD->unsigned int
        public uint DesiredAccess;

        /// PHANDLE->HANDLE*
        public System.IntPtr RootHandle;

        /// PVOID->void*
        public System.IntPtr CallContext;

        /// PVOID->void*
        public System.IntPtr ObjectContext;

        /// ULONG_PTR->unsigned int
        public uint Version;

        /// PVOID->void*
        public System.IntPtr FileAccessToken;
    }
}
