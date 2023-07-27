using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Ban3.Infrastructures.NativeLibs.Enums;
using Ban3.Infrastructures.NativeLibs.Structs;

namespace Ban3.Infrastructures.NativeLibs.Undocumented
{
    public static unsafe partial class NTOSKRNL
    {

        [MethodImpl(MethodImplOptions.InternalCall)]
        [DllImport(Documented.NTOSKRNL.Dll, SetLastError = true, CharSet = CharSet.Auto)]
        public static extern NTSTATUS ZwQuerySystemInformation(
            SYSTEM_INFORMATION_CLASS systemInformationClass, 
            void* systemInformation, 
            uint systemInformationLength, 
            uint* returnLength
            );

        [MethodImpl(MethodImplOptions.InternalCall)]
        [DllImport(Documented.NTOSKRNL.Dll, SetLastError = true, CharSet = CharSet.Auto)]
        public static extern NTSTATUS MmCopyVirtualMemory(
            void* SourceProcess,
            void* SourceAddress,
            void* TargetProcess, 
            void* TargetAddress, 
            ulong BufferSize, 
            KProcessorMode PreviousMode, 
            ulong* ReturnSize
            );

        [MethodImpl(MethodImplOptions.InternalCall)]
        [DllImport(Documented.NTOSKRNL.Dll, SetLastError = true, CharSet = CharSet.Auto)]
        public static extern PVOID PsGetProcessSectionBaseAddress(
            void* process
            );

    }
}
