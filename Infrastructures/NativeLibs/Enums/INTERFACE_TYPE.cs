using System;
using System.Collections.Generic;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Enums
{
    /// <summary>
    /// The INTERFACE_TYPE enumeration indicates the bus type.
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/ddi/wdm/ne-wdm-_interface_type
    /// </summary>
    public enum INTERFACE_TYPE
    {
        /// <summary>
        /// Indicates that the interface type is undefined.
        /// </summary>
        InterfaceTypeUndefined,

        /// <summary>
        /// For internal use only.
        /// </summary>
        Internal,

        /// <summary>
        /// Indicates that the interface is published by the ISA bus driver.
        /// </summary>
        Isa,

        /// <summary>
        /// Indicates that the interface is published by the EISA bus driver.
        /// </summary>
        Eisa,

        /// <summary>
        /// Indicates that the interface is published by the MicroChannel bus driver.
        /// </summary>
        MicroChannel,

        /// <summary>
        /// Indicates that the interface is published by the TurboChannel bus driver.
        /// </summary>
        TurboChannel,

        /// <summary>
        /// Indicates that the interface is published by the PCI bus driver.
        /// </summary>
        PCIBus,

        /// <summary>
        /// Indicates that the interface is published by the VME bus driver.
        /// </summary>
        VMEBus,

        /// <summary>
        /// Indicates that the interface is published by the NuBus driver.
        /// </summary>
        NuBus,

        /// <summary>
        /// Indicates that the interface is published by the PCMCIA bus driver.
        /// </summary>
        PCMCIABus,

        /// <summary>
        /// Indicates that the interface is published by the Cbus driver.
        /// </summary>
        CBus,

        /// <summary>
        /// Indicates that the interface is published by the MPI bus driver.
        /// </summary>
        MPIBus,

        /// <summary>
        /// Indicates that the interface is published by the MPSA bus driver.
        /// </summary>
        MPSABus,

        /// <summary>
        /// Indicates that the interface is published by the ISA bus driver.
        /// </summary>
        ProcessorInternal,

        /// <summary>
        /// Indicates that the interface is published for an internal power bus. 
        /// Some devices have power control ports that allow them to share power control with other devices. 
        /// The Windows architecture represents these devices as slots on a virtual bus called an "internal power bus."
        /// </summary>
        InternalPowerBus,

        /// <summary>
        /// Indicates that the interface is published by the PNPISA bus driver.
        /// </summary>
        PNPISABus,

        /// <summary>
        /// Indicates that the interface is published by the PNP bus driver.
        /// </summary>
        PNPBus,

        /// <summary>
        /// Reserved for use by the operating system.
        /// </summary>
        Vmcs,

        /// <summary>
        /// Indicates that the interface is published by the ACPI bus driver. 
        /// The ACPI bus driver enumerates devices that are described in the ACPI firmware of the hardware platform. 
        /// These devices might physically reside on buses that are controlled by other bus drivers, 
        /// but the ACPI bus driver must enumerate these devices because the other bus drivers cannot detect them. 
        /// This interface type is defined starting with Windows 8.
        /// </summary>
        ACPIBus,

        /// <summary>
        /// Marks the upper limit of the possible bus types.
        /// </summary>
        MaximumInterfaceType,
    }
}
