using System;
using System.Collections.Generic;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Enums
{
    /// <summary>
    /// The DEVICE_INSTALL_STATE enumeration describes a device's installation state.
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ne-wdm-_device_install_state
    /// </summary>
    public enum DEVICE_INSTALL_STATE
    {
        /// <summary>
        /// The device is installed.
        /// </summary>
        InstallStateInstalled,

        /// <summary>
        /// The system will try to reinstall the device on a later enumeration.
        /// </summary>
        InstallStateNeedsReinstall,

        /// <summary>
        /// The device did not install properly.
        /// </summary>
        InstallStateFailedInstall,

        /// <summary>
        /// The installation of this device is not yet complete.
        /// </summary>
        InstallStateFinishInstall
    }
}
