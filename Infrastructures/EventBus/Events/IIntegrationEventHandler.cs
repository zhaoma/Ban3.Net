//  ————————————————————————————————————————————————————————————————————————————
//  zhaoma @ 2022/12/27 09:25
//  function:	IIntegrationEventHandler.cs
//  reference:	https://
//  ————————————————————————————————————————————————————————————————————————————
using System;
using System.Threading.Tasks;

namespace  Ban3.Infrastructures.EventBus.Events
{
	public interface IIntegrationEventHandler
	{
	}


    /// <summary>
    /// 集成事件处理程序
    /// 泛型接口
    /// </summary>
    /// <typeparam name="TIntegrationEvent"></typeparam>
    public interface IIntegrationEventHandler<in TIntegrationEvent> : IIntegrationEventHandler
       where TIntegrationEvent : IntegrationEvent
    {
        Task Handle(TIntegrationEvent @event);
    }
}

