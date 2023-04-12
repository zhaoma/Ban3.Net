using System;
using System.Collections.Generic;
using System.Text;

namespace Ban3.Infrastructures.NativeLibs.Enums
{
    public enum IO_SESSION_EVENT
    {
        IoSessionEventIgnore,
        IoSessionEventCreated,
        IoSessionEventTerminated,
        IoSessionEventConnected,
        IoSessionEventDisconnected,
        IoSessionEventLogon,
        IoSessionEventLogoff,
        IoSessionEventMax
    }
}
