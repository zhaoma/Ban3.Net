/* -------------------------------------------------------------------------------------------------
   Copyright (C) Siemens Healthcare GmbH 2023, All rights reserved. Restricted.
   ------------------------------------------------------------------------------------------------- */
   
using Ban3.Infrastructures.Indicators.Enums;
using Ban3.Infrastructures.Indicators.Inputs;
using Newtonsoft.Json;

namespace Ban3.Infrastructures.Indicators.Entries;

public class Stock
{
    [JsonProperty("code")]
    public string Code { get; set; } = string.Empty;

    [JsonProperty("symbol")]
    public string Symbol { get; set; }=string.Empty;

    [JsonProperty("name")]
    public string Name { get; set; } = string.Empty;

    [JsonProperty("listDate")] public string ListDate { get; set; } = string.Empty;

    public string FileNameWithCycle(StockAnalysisCycle cycle)
        => $"{Code}.{cycle}";

    public string FileNameWithProfile(Profile profile)
        => $"{Code}.{profile.Identity}";
}