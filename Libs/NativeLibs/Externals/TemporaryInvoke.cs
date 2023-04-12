using System;
using System.Runtime.InteropServices;

namespace Ban3.Infrastructures.NativeLibs.Externals
{
    /// <summary>
    /// 
    /// </summary>
    public class TemporaryInvoke : IDisposable
    {
        private readonly IntPtr _handler;

        public TemporaryInvoke(string dllPath)
        {
            _handler = Documented.KERNEL32.LoadLibraryW(dllPath);

            if (!Ready())
            {
                var err = Marshal.GetLastWin32Error();
                Console.WriteLine($"ERROR={err}");
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }

        protected void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }

            if (disposing)
            {
                Documented.KERNEL32.FreeLibrary(_handler);
            }

            _disposed = true;
        }

        private bool _disposed;

        ~TemporaryInvoke()
        {
            Console.WriteLine("FREE LIB");
        }

        public bool Ready()
        {
            return !_handler.Equals(IntPtr.Zero);
        }

        public Delegate Invoke(string apiName, Type t)
        {
            IntPtr api = Documented.KERNEL32.GetProcAddress(_handler, apiName);
            return Invoke(api, t);
        }

        public Delegate Invoke(IntPtr address, Type t)
        {
            return Marshal.GetDelegateForFunctionPointer(address, t);
        }
    }
}
