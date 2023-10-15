using System;
using Newtonsoft.Json;

namespace Ban3.Infrastructures.ServiceCentre.Entries.Casino.Indicators.Inputs;

public interface IMacd
{
    [JsonProperty("short", NullValueHandling = NullValueHandling.Ignore)]
    int SHORT { get; set; }

    /// <summary>
    /// LONG(长期)
    /// </summary>
    [JsonProperty("long", NullValueHandling = NullValueHandling.Ignore)]
    int LONG { get; set; }

    /// <summary>
    /// M 天数
    /// </summary>
    [JsonProperty("mid", NullValueHandling = NullValueHandling.Ignore)]
    int MID { get; set; }
}

