//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using System;

namespace Ban3.Infrastructures.Contracts.Entries.CommunicationServer;

public class ReceivedArgs:EventArgs
{
    public Address Address { get; set; } 

    public byte[] Data { get; set; }
}
