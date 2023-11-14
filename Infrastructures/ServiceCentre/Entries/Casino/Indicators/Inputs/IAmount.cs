// —————————————————————————————————————————————————————————————————————————————
// zhaoma@hotmail.com   2023
// WTFPL . DRY . KISS . YAGNI
// —————————————————————————————————————————————————————————————————————————————

using Newtonsoft.Json;

using System.Collections.Generic;

namespace Ban3.Infrastructures.ServiceCentre.Entries.Casino.Indicators.Inputs;

public interface IAmount : IParameter
{
    /// <summary>
    /// 周期集合
    /// </summary>
    [JsonProperty( "durations" )]
    IEnumerable<int> Durations { get; set; }
}