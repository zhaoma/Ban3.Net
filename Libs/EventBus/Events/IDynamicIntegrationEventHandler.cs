//  ————————————————————————————————————————————————————————————————————————————
//  zhaoma @ 2022/12/27 09:27
//  function:	IDynamicIntegrationEventHandler.cs
//  reference:	https://
//  ————————————————————————————————————————————————————————————————————————————
using System;
using System.Threading.Tasks;

namespace  Ban3.Infrastructures.EventBus.Events
{
	public interface IDynamicIntegrationEventHandler
    {
        Task Handle(dynamic eventData);
    }
}

