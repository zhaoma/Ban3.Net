﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Enums
{
    /// <summary>
    /// Each device object has a device type, which is stored in the DeviceType member of its DEVICE_OBJECT structure. 
    /// The device type represents the type of underlying hardware for the driver.
    /// 
    /// Every kernel-mode driver that creates a device object must specify an appropriate device type value when calling IoCreateDevice. 
    /// The IoCreateDevice routine uses the supplied device type to initialize the DeviceType member of the DEVICE_OBJECT structure.
    /// 
    /// https://learn.microsoft.com/en-us/windows-hardware/drivers/kernel/specifying-device-types
    /// The system defines the following device type values, listed in alphabetical order:
    /// </summary>
    public enum DEVICE_TYPE:uint
    {
        FILE_DEVICE_8042_PORT = 0x00000027,
        FILE_DEVICE_ACPI = 0x00000032,
        FILE_DEVICE_BATTERY = 0x00000029,
        FILE_DEVICE_BEEP = 0x00000001,
        FILE_DEVICE_BUS_EXTENDER = 0x0000002a,
        FILE_DEVICE_CD_ROM = 0x00000002,
        FILE_DEVICE_CD_ROM_FILE_SYSTEM = 0x00000003,
        FILE_DEVICE_CHANGER = 0x00000030,
        FILE_DEVICE_CONTROLLER = 0x00000004,
        FILE_DEVICE_DATALINK = 0x00000005,
        FILE_DEVICE_DFS = 0x00000006,
        FILE_DEVICE_DFS_FILE_SYSTEM = 0x00000035,
        FILE_DEVICE_DFS_VOLUME = 0x00000036,
        FILE_DEVICE_DISK = 0x00000007,
        FILE_DEVICE_DISK_FILE_SYSTEM = 0x00000008,
        FILE_DEVICE_DVD = 0x00000033,
        FILE_DEVICE_FILE_SYSTEM = 0x00000009,
        FILE_DEVICE_FIPS = 0x0000003a,
        FILE_DEVICE_FULLSCREEN_VIDEO = 0x00000034,
        FILE_DEVICE_INPORT_PORT = 0x0000000a,
        FILE_DEVICE_KEYBOARD = 0x0000000b,
        FILE_DEVICE_KS = 0x0000002f,
        FILE_DEVICE_KSEC = 0x00000039,
        FILE_DEVICE_MAILSLOT = 0x0000000c,
        FILE_DEVICE_MASS_STORAGE = 0x0000002d,
        FILE_DEVICE_MIDI_IN = 0x0000000d,
        FILE_DEVICE_MIDI_OUT = 0x0000000e,
        FILE_DEVICE_MODEM = 0x0000002b,
        FILE_DEVICE_MOUSE = 0x0000000f,
        FILE_DEVICE_MULTI_UNC_PROVIDER = 0x00000010,
        FILE_DEVICE_NAMED_PIPE = 0x00000011,
        FILE_DEVICE_NETWORK = 0x00000012,
        FILE_DEVICE_NETWORK_BROWSER = 0x00000013,
        FILE_DEVICE_NETWORK_FILE_SYSTEM = 0x00000014,
        FILE_DEVICE_NETWORK_REDIRECTOR = 0x00000028,
        FILE_DEVICE_NULL = 0x00000015,
        FILE_DEVICE_PARALLEL_PORT = 0x00000016,
        FILE_DEVICE_PHYSICAL_NETCARD = 0x00000017,
        FILE_DEVICE_PRINTER = 0x00000018,
        FILE_DEVICE_SCANNER = 0x00000019,
        FILE_DEVICE_SCREEN = 0x0000001c,
        FILE_DEVICE_SERENUM = 0x00000037,
        FILE_DEVICE_SERIAL_MOUSE_PORT = 0x0000001a,
        FILE_DEVICE_SERIAL_PORT = 0x0000001b,
        FILE_DEVICE_SMARTCARD = 0x00000031,
        FILE_DEVICE_SMB = 0x0000002e,
        FILE_DEVICE_SOUND = 0x0000001d,
        FILE_DEVICE_STREAMS = 0x0000001e,
        FILE_DEVICE_TAPE = 0x0000001f,
        FILE_DEVICE_TAPE_FILE_SYSTEM = 0x00000020,
        FILE_DEVICE_TERMSRV = 0x00000038,
        FILE_DEVICE_TRANSPORT = 0x00000021,
        FILE_DEVICE_UNKNOWN = 0x00000022,
        FILE_DEVICE_VDM = 0x0000002c,
        FILE_DEVICE_VIDEO = 0x00000023,
        FILE_DEVICE_VIRTUAL_DISK = 0x00000024,
        FILE_DEVICE_WAVE_IN = 0x00000025,
        FILE_DEVICE_WAVE_OUT = 0x00000026
    }
}
