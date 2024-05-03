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
public class UtilizeSignalR:IMessageServer
{
    public Task<bool> Publish(INotify notify) {  return Task.FromResult(true); }

    public Task<bool> Subscribe(Action<INotify> action) { return Task.FromResult(true); }
}
