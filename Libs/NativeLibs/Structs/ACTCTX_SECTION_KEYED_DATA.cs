using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    [StructLayout(LayoutKind.Sequential)]
    public struct ACTCTX_SECTION_KEYED_DATA
    {
        /// ULONG->unsigned int
        public uint cbSize;

        /// ULONG->unsigned int
        public uint ulDataFormatVersion;

        /// PVOID->void*
        public System.IntPtr lpData;

        /// ULONG->unsigned int
        public uint ulLength;

        /// PVOID->void*
        public System.IntPtr lpSectionGlobalData;

        /// ULONG->unsigned int
        public uint ulSectionGlobalDataLength;

        /// PVOID->void*
        public System.IntPtr lpSectionBase;

        /// ULONG->unsigned int
        public uint ulSectionTotalLength;

        /// HANDLE->void*
        public System.IntPtr hActCtx;

        /// ULONG->unsigned int
        public uint ulAssemblyRosterIndex;

        /// ULONG->unsigned int
        public uint ulFlags;

        public ACTCTX_SECTION_KEYED_DATA_ASSEMBLY_METADATA AssemblyMetadata;

    }


    [StructLayout(LayoutKind.Sequential)]
    public struct ACTCTX_SECTION_KEYED_DATA_ASSEMBLY_METADATA
    {
        /// PVOID->void*
        public System.IntPtr lpInformation;

        /// PVOID->void*
        public System.IntPtr lpSectionBase;

        /// ULONG->unsigned int
        public uint ulSectionLength;

        /// PVOID->void*
        public System.IntPtr lpSectionGlobalDataBase;

        /// ULONG->unsigned int
        public uint ulSectionGlobalDataLength;


    }
}
