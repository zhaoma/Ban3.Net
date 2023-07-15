using Ban3.Infrastructures.NativeLibs.Enums;
using Ban3.Infrastructures.NativeLibs.Structs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Extensions
{
    public static unsafe partial class Helper
    {

        public static bool NT_SUCCESS(NTSTATUS status)
        {
            return (((int)(status)) >= 0);
        }

        public static char* w_str(this string str)
        {
            fixed (char* wc = str)
                return wc;
        }

        /// <summary>
        /// Converts the Wide string into a Multibyte string. The pool has to be freed after usage.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static char* c_str(this string str)
        {
            fixed (void* wc = str)
            {
                //Allocate pool for char* taking the null terminator into consideration
                var buf =Documented.NTOSKRNL.ExAllocatePool(POOL_TYPE.NonPagedPool, (ulong)str.Length + 1);

                //convert wchar_t* to char*
                Documented.NTOSKRNL.wcstombs((char*)buf, wc, (ulong)(str.Length * 2) + 2);
                return (char*)buf;
            }
        }

        public static ulong __readcr3()
        {
            void* buffer = stackalloc byte[0x5C0];
            var sat = Documented.NTOSKRNL.KeSaveStateForHibernate(buffer);
            ulong cr3 = *(ulong*)((ulong)buffer + 0x10);
            return cr3;
        }

        public static ulong DbgPrintEx(uint ComponentId, uint level, string Format, PVOID vararg1)
        {
            fixed (void* wc = Format)
            {
                //Allocate memory on the stack for char* taking the null terminator into consideration
                var buf = stackalloc byte[Format.Length + 1];

                //convert wchar_t* to char*
                Documented.NTOSKRNL.wcstombs((char*)buf, wc, (ulong)(Format.Length * 2) + 2);
                return Documented.NTOSKRNL._DbgPrintEx(ComponentId, level, (char*)buf, vararg1);
            }
        }
    }
}
