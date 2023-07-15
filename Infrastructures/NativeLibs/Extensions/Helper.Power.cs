using Ban3.Infrastructures.NativeLibs.Interfaces.Modules;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Extensions
{
    public static partial class Helper
    {
        public static bool Shutdown(
            this IPower _,
            uint timeout = 0,
            bool forceAppsClosed = true,
            bool rebootAfterShutdown = false,
            string message = null,
            string machineName = null
            )
        {
            return Documented.ADVAPI32.InitiateSystemShutdownW(
                string.IsNullOrEmpty(machineName)
                    ? null
                    : new StringBuilder(machineName),
                string.IsNullOrEmpty(message)
                    ? null
                    : new StringBuilder(message),
                timeout,
                forceAppsClosed,
                rebootAfterShutdown
                );
        }

        public static bool Reboot(
            this IPower _,
            uint timeout = 0,
            bool forceAppsClosed = true,
            bool rebootAfterShutdown = true,
            string message = null,
            string machineName = null
            )
        {
            return Documented.ADVAPI32.InitiateSystemShutdownW(
                string.IsNullOrEmpty(machineName)
                    ? null
                    : new StringBuilder(machineName),
                string.IsNullOrEmpty(message)
                    ? null
                    : new StringBuilder(message),
                timeout,
                forceAppsClosed,
                rebootAfterShutdown
                );
        }

        public static bool AbortShutdown(
            this IPower _,
            string machineName = null
            )
        {
            return Documented.ADVAPI32.AbortSystemShutdownW(
                string.IsNullOrEmpty(machineName)
                    ? null
                    : new StringBuilder(machineName)
                );
        }
    }
}
