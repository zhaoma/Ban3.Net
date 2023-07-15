using System;
using System.Collections.Generic;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    public unsafe struct PVOID
    {
        private void* _Value;

        public static implicit operator PVOID(void* value)
        {
            return new PVOID { _Value = value };
        }

        public static implicit operator PVOID(ulong value)
        {
            return new PVOID { _Value = (void*)value };
        }

        public static implicit operator void*(PVOID value)
        {
            return value._Value;
        }

        public static implicit operator ulong(PVOID value)
        {
            return (ulong)value._Value;
        }
    }
}
