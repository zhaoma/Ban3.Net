using System.Collections.Generic;

namespace Ban3.Sites.ViaTushare.Request;

public class GetProBarParams
{
    public string Code { get; set; } = string.Empty;

    public string StartDate { get; set; } = string.Empty;

    public string EndDate { get; set; } = string.Empty;

    public string Asset { get; set; } = string.Empty;

    public string Adj { get; set; } = string.Empty;

    public string Freq { get; set; } = string.Empty;

    public Dictionary<string, object> ToDictionary()
    {
        var dic = new Dictionary<string, object>();
        if (!string.IsNullOrEmpty(Code))
            dic.Add("ts_code", Code);
        if (!string.IsNullOrEmpty(StartDate))
            dic.Add("start_date", StartDate);
        if (!string.IsNullOrEmpty(EndDate))
            dic.Add("end_date", EndDate);
        if (!string.IsNullOrEmpty(Asset))
            dic.Add("asset", Asset);
        if (!string.IsNullOrEmpty(Adj))
            dic.Add("adj", Adj);
        if (!string.IsNullOrEmpty(Freq))
            dic.Add("freq", Freq);
        return dic;
    }

    public GetProBarParams(){}

    public GetProBarParams(string tsCode)
    {
        Code = tsCode;
        Asset = "E";
        Adj = "qfq";
        Freq = "D";
    }
}