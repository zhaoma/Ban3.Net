using Ban3.Infrastructures.NativeLibs.Enums;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    /// <summary>
    /// This structure is not supported.
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ns-wdm-_image_policy_entry
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct IMAGE_POLICY_ENTRY
    {    
        /// DWORD->unsigned int
        public IMAGE_POLICY_ENTRY_TYPE Type;

        /// DWORD->unsigned int
        public IMAGE_POLICY_ID PolicyId;

        /// Anonymous_9c2f4c43_7c62_41b9_92fb_1fe2a2096564
        public IMAGE_POLICY_ENTRY_U u;
    }


    [StructLayout(LayoutKind.Explicit, CharSet = CharSet.Ansi)]
    public struct IMAGE_POLICY_ENTRY_U
    {    /// void*
        [FieldOffsetAttribute(0)]
        public IntPtr None;

        /// BOOLEAN->BYTE->unsigned char
        [FieldOffsetAttribute(0)]
        public byte BoolValue;

        /// INT8->char
        [FieldOffsetAttribute(0)]
        public byte Int8Value;

        /// UINT8->unsigned char
        [FieldOffsetAttribute(0)]
        public byte UInt8Value;

        /// INT16->short
        [FieldOffsetAttribute(0)]
        public short Int16Value;

        /// UINT16->unsigned short
        [FieldOffsetAttribute(0)]
        public ushort UInt16Value;

        /// INT32->int
        [FieldOffsetAttribute(0)]
        public int Int32Value;

        /// UINT32->unsigned int
        [FieldOffsetAttribute(0)]
        public uint UInt32Value;

        /// INT64->__int64
        [FieldOffsetAttribute(0)]
        public long Int64Value;

        /// UINT64->unsigned __int64
        [FieldOffsetAttribute(0)]
        public ulong UInt64Value;

        /// PCSTR->CHAR*
        [FieldOffsetAttribute(0)]
        public IntPtr AnsiStringValue;

        /// PCWSTR->WCHAR*
        [FieldOffsetAttribute(0)]
        public IntPtr UnicodeStringValue;
    }
}
