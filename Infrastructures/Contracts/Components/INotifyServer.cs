//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.Contracts.Materials;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ban3.Infrastructures.Contracts.Components;

/// <summary>
/// Producer：消息的上游，消息生产者
/// Consumer：消息的下游，消息消费者
/// Message: 消息，作为异步通信的数据载体。
/// Broker：消息中间件服务器
/// Topic：消息主题，用于发布订阅模式
/// Queue: 消息队列，用于点对点模式
/// Subscription：订阅关系，用于发布订阅模式，表示消费者的感兴趣消息类型
/// Exchange:交换器。用于消息订阅计算，找到目标Consumer。
/// </summary>
public interface INotifyServer : IZero, IDisposable
{
    bool Start();

    bool Stop();

    bool Publish();

    bool Consume();


}
