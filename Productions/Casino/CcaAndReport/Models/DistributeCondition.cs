﻿using System;
using Ban3.Infrastructures.Common.Extensions;
using Ban3.Productions.Casino.Contracts.Request;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
#nullable enable

namespace Ban3.Productions.Casino.CcaAndReport.Models;

public class DistributeCondition
{
    public DistributeCondition() { }

    public DistributeCondition(int rank, string subject, DistributeExpression request)
    {
        Rank = rank;
        Subject = subject;
        Request = request;
    }

    public int Rank { get; set; }

    public string Subject { get; set; } = string.Empty;

    public DistributeExpression Request { get; set; } = new DistributeExpression();

    public bool IsTarget(TimelineRecord record)
    {
        var result = (string.IsNullOrEmpty(Request.StartsWith)
            || record.Code.StartsWithIn(Request.StartsWith!.Split(',')));

        if (Request.IndicatorHas.HasFlag(IndicatorHas.Daily))
            result = result && record.DailyRecord != null;

        if (Request.IndicatorHas.HasFlag(IndicatorHas.Weekly))
            result = result && record.WeeklyRecord != null;

        if (Request.IndicatorHas.HasFlag(IndicatorHas.Monthly))
            result = result && record.MonthlyRecord != null;

        if (Request.MaxAmplitude != null)
            result = result && record.Amplitude() <= Request.MaxAmplitude.Value;

        if (Request.MinAmplitude != null)
            result = result && record.Amplitude() >= Request.MinAmplitude.Value;

        if (Request.MaxIncrease != null)
            result = result && record.Increase() <= Request.MaxIncrease.Value;

        if (Request.MinIncrease != null)
            result = result && record.Increase() >= Request.MinIncrease.Value;

        if (Request.MaxPrice != null)
            result = result && record.NearlyRecord.Close <= Request.MaxPrice.Value;

        if (Request.MinPrice != null)
            result = result && record.NearlyRecord.Close >= Request.MinPrice.Value;



        return result;
    }
}

public class DistributeExpression
{
    public DistributeExpression() { }

    [JsonProperty("startsWith", NullValueHandling = NullValueHandling.Ignore)]
    public string? StartsWith { get; set; }

    [JsonProperty("indicatorHas", NullValueHandling = NullValueHandling.Ignore)]
    [JsonConverter(typeof(StringEnumConverter))]
    public IndicatorHas IndicatorHas { get; set; }

    [JsonProperty("sorter", NullValueHandling = NullValueHandling.Ignore)]
    [JsonConverter(typeof(StringEnumConverter))]
    public RecordsSorter Sorter { get; set; }

    [JsonProperty("maxIncrease", NullValueHandling = NullValueHandling.Ignore)]
    public double? MaxIncrease { get; set; }

    [JsonProperty("minIncrease", NullValueHandling = NullValueHandling.Ignore)]
    public double? MinIncrease { get; set; }

    [JsonProperty("maxAmplitude", NullValueHandling = NullValueHandling.Ignore)]
    public double? MaxAmplitude { get; set; }

    [JsonProperty("minAmplitude", NullValueHandling = NullValueHandling.Ignore)]
    public double? MinAmplitude { get; set; }

    [JsonProperty("maxPrice", NullValueHandling = NullValueHandling.Ignore)]
    public double? MaxPrice { get; set; }

    [JsonProperty("minPrice", NullValueHandling = NullValueHandling.Ignore)]
    public double? MinPrice { get; set; }

    [JsonProperty("page", NullValueHandling = NullValueHandling.Ignore)]
    public int? Page { get; set; } = 1;

    [JsonProperty("pageSize", NullValueHandling = NullValueHandling.Ignore)]
    public int? PageSize { get; set; } = 10;
}

[Flags]
public enum IndicatorHas
{
    Daily,
    Weekly,
    Monthly
}

[Flags]
public enum RecordsSorter
{
    Code,
    Increase,
    Amplitude,
    Price,
    Asc,
    Desc
}