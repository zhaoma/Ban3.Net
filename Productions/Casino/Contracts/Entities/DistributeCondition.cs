using Ban3.Infrastructures.Common.Extensions;
using Newtonsoft.Json;

#nullable enable

namespace Ban3.Productions.Casino.Contracts.Entities;

/// <summary>
/// 分发条件
/// </summary>
public class DistributeCondition
{
    /// 
    public DistributeCondition() { }

    /// 
    public DistributeCondition(int rank, string subject, DistributeExpression request)
    {
        Rank = rank;
        Subject = subject;
        Request = request;
    }

    /// <summary>
    /// 序号/标识
    /// </summary>
    [JsonProperty("rank", NullValueHandling = NullValueHandling.Ignore)]
    public int Rank { get; set; }

    /// <summary>
    /// 主题
    /// </summary>
    [JsonProperty("subject", NullValueHandling = NullValueHandling.Ignore)]
    public string Subject { get; set; } = string.Empty;

    /// <summary>
    /// 条件
    /// </summary>
    [JsonProperty("request", NullValueHandling = NullValueHandling.Ignore)]
    public DistributeExpression Request { get; set; } = new DistributeExpression();

    /// <summary>
    /// 对时间记录判定
    /// </summary>
    /// <param name="record"></param>
    /// <returns></returns>
    public bool IsTarget(TimelineRecord record)
    {
        var result = (string.IsNullOrEmpty(Request.StartsWith)
            || record.Code.StartsWithIn(Request.StartsWith!.Split(',')));

        if (Request.HasWeek != null && Request.HasWeek.Value)
            result = result && record.WeeklyRecord != null;

        if (Request.HasMonth != null && Request.HasMonth.Value)
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

    /// 
    public override string ToString()
        => this.ObjToJson();

    /// 
    public override int GetHashCode()
    {
        return Rank * 23;
    }

    /// 
    public override bool Equals(object? obj)
    {
        if (obj == null) return false;

        return Rank == (obj as DistributeCondition)?.Rank;
    }
}
