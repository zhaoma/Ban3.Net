/* —————————————————————————————————————————————————————————————————————————————
 * zhaoma@hotmail.com   2022
 * function:            unmanaged dll挂载
 * reference:
 * —————————————————————————————————————————————————————————————————————————————
 */

using System;
using System.Runtime.InteropServices;

namespace  Ban3.Infrastructures.EventBus.Handlers
{
    /// <summary>
    /// unmanaged dll挂载
    /// </summary>
    public class UnmanagedDLL
    {
        [DllImport( "kernel32.dll", SetLastError = true )]
        private static extern IntPtr LoadLibrary( string path );

        [DllImport( "kernel32.dll", SetLastError = true )]
        private static extern IntPtr GetProcAddress( IntPtr lib, string funcName );

        [DllImport( "kernel32.dll", SetLastError = true )]
        private static extern bool FreeLibrary( IntPtr lib );

        private IntPtr libPtr;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dllPath"></param>
        public UnmanagedDLL( string dllPath )
        {
            libPtr = LoadLibrary( dllPath );

            if( !Ready() )
            {
                var err = Marshal.GetLastWin32Error();
                Console.WriteLine( $"ERROR : {err}" );
            }
        }

        /// <summary>
        /// release unmanaged dll
        /// </summary>
        ~UnmanagedDLL()
        {
            Console.WriteLine( "FREE LIB" );
            FreeLibrary( libPtr );
        }

        /// <summary>
        /// loaded dll ready
        /// </summary>
        /// <returns></returns>
        public bool Ready()
        {
            return !libPtr.Equals( IntPtr.Zero );
        }

        /// <summary>
        /// 将要执行的函数转换为委托
        /// </summary>
        /// <param name="apiName"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        public Delegate Invoke( string apiName, Type t )
        {
            IntPtr api = GetProcAddress( libPtr, apiName );
            return (Delegate)Marshal.GetDelegateForFunctionPointer( api, t );
        }
    }
}