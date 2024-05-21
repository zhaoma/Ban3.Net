﻿//  —————————————————————————————————————————————————————————————————————————————
//  zhaoma@hotmail.com . WTFPL . DRY . KISS . YAGNI
//  —————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.Contracts.Enums.CalendarServer;
using Ban3.Infrastructures.Contracts.Materials.Calendars;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace Ban3.Infrastructures.Contracts.Entries.CalendarServer;

/// <summary>
/// 响应状态(邀请)
/// https://developer.microsoft.com/en-us/graph/docs/api-reference/v1.0/resources/responsestatus
/// </summary>
public class ResponseStatus : IResponseStatus
{
    public ResponseType Response { get; set; }

    public DateTime Time { get; set; }
}