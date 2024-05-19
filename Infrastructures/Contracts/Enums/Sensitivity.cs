using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ban3.Infrastructures.Contracts.Enums;

/// <summary>
/// 信息敏感度
/// 可能的值是：normal、personal、private、confidential。
/// </summary>
public enum Sensitivity
{
    [JsonProperty("normal")]
    Normal,

    [JsonProperty("personal")]
    Personal,

    [JsonProperty("private")]
    Private,

    [JsonProperty("confidential")]
    Confidential
}
