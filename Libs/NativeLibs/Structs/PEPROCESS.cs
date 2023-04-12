using System;
using System.Collections.Generic;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Structs
{
    public unsafe struct PEPROCESS
    {
        private void* _Value;

        public static implicit operator PEPROCESS(void* value)
        {
            return new PEPROCESS { _Value = value };
        }

        public static implicit operator PEPROCESS(ulong value)
        {
            return new PEPROCESS { _Value = (void*)value };
        }

        public static implicit operator void*(PEPROCESS value)
        {
            return value._Value;
        }

        public static implicit operator ulong(PEPROCESS value)
        {
            return (ulong)value._Value;
        }
    }
}
