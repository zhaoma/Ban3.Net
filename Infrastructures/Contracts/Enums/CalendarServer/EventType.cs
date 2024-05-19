using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ban3.Infrastructures.Contracts.Enums.CalendarServer;

/// <summary>
/// 事件类型
/// 事件类型。 可取值为 singleInstance、occurrence、exception、seriesMaster。 
/// 单实例、事件、异常、序列主机
/// 只读。
/// </summary>
public enum EventType
{
    [JsonProperty("singleInstance")]
    SingleInstance,

    [JsonProperty("occurrence")]
    Occurrence,

    [JsonProperty("exception")]
    Exception,

    [JsonProperty("seriesMaster")]
    SeriesMaster
}
