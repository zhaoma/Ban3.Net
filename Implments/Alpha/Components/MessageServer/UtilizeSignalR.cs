//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.Components;
using Ban3.Infrastructures.Components.Entries.MessageServer;
using System;
using System.Threading.Tasks;

namespace Ban3.Implements.Alpha.Components.MessageServer;

/// <summary>
/// 
/// </summary>
public class UtilizeSignalR : IMessageServer
{
    /// see interface
    public Task<bool> Publish(Notify notify) { return Task.FromResult(true); }

    /// see interface
    public Task<bool> Subscribe(Action<Notify> action) { return Task.FromResult(true); }
}
