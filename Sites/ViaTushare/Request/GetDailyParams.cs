using System.Collections.Generic;

namespace Ban3.Sites.ViaTushare.Request;

public class GetDailyParams
{
    public string Code { get; set; } = string.Empty;

    public string TradeDate { get; set; } = string.Empty;

    public string StartDate { get; set; } = string.Empty;

    public string EndDate { get; set; } = string.Empty;

    public Dictionary<string, object> ToDictionary()
    {
        var dic = new Dictionary<string, object>();

        if (!string.IsNullOrEmpty(Code))
            dic.Add("ts_code", Code);
        if (!string.IsNullOrEmpty(StartDate))
            dic.Add("start_date", StartDate);
        if (!string.IsNullOrEmpty(EndDate))
            dic.Add("end_date", EndDate);
        if (!string.IsNullOrEmpty(TradeDate))
            dic.Add("trade_date", TradeDate);

        return dic;
    }

    public GetDailyParams(){}

    public GetDailyParams(IEnumerable< string> tsCodes)
    {
        Code = string.Join(",", tsCodes);
    }
}