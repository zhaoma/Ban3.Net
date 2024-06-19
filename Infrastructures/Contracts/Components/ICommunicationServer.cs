//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.Contracts.Entries.CommunicationServer;
using Ban3.Infrastructures.Contracts.Materials;
using System;

namespace Ban3.Infrastructures.Contracts.Components;

/// <summary>
/// 通讯服务
/// </summary>
public interface ICommunicationServer : IZero, IDisposable
{
    bool StartListen(Address address);

    event EventHandler<ReceivedArgs> Received;

    bool StopListen(Address address);


}
