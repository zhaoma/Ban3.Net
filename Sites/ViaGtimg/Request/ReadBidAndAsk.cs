using Ban3.Infrastructures.NetHttp.Entries;

namespace Ban3.Sites.ViaGtimg.Request; 

public class ReadBidAndAsk
    : TargetResource
{
    public ReadBidAndAsk(string code)
    {
        Code = code;
        Url= $"http://qt.gtimg.cn/q=s_pksz000858";
    }

    /// <summary>
    /// 
    /// </summary>
    public string Code { get; set; }
}

