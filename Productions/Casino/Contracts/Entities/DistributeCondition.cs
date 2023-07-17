using System;
using Ban3.Infrastructures.Common.Extensions;
using Ban3.Productions.Casino.Contracts.Enums;
using Newtonsoft.Json;

#nullable enable

namespace Ban3.Productions.Casino.Contracts.Entities;

public class DistributeCondition
{
    public DistributeCondition() { }

    public DistributeCondition(int rank, string subject, DistributeExpression request)
    {
        Rank = rank;
        Subject = subject;
        Request = request;
    }

    [JsonProperty("rank", NullValueHandling = NullValueHandling.Ignore)]
    public int Rank { get; set; }

    [JsonProperty("subject", NullValueHandling = NullValueHandling.Ignore)]
    public string Subject { get; set; } = string.Empty;

    [JsonProperty("request", NullValueHandling = NullValueHandling.Ignore)]
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

        if (Request.MaxDays != null)
            result = result && record.DurationDays() <= Request.MaxDays.Value;

        return result;
    }
}
