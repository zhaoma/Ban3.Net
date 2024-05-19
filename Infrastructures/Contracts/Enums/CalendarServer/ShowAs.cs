using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ban3.Infrastructures.Contracts.Enums.CalendarServer;

/// <summary>
/// 状态显示
/// 可取值为：free、tentative、busy、oof、workingElsewhere、unknown。
/// </summary>
public enum ShowAs
{
    [JsonProperty("free")]
    Free,

    [JsonProperty("tentative")]
    Tentative,

    [JsonProperty("busy")]
    Busy,

    [JsonProperty("oof")]
    Oof,

    [JsonProperty("workingElsewhere")]
    WorkingElsewhere,

    [JsonProperty("unknown")]
    Unknown
}
