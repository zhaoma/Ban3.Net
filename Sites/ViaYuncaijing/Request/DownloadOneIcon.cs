using Ban3.Infrastructures.NetHttp.Entries;

namespace Ban3.Sites.ViaYuncaijing.Request;

public class DownloadOneIcon
    : TargetResource
{
    public string Prefix { get; set; }

    public string Code { get; set; }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public DownloadOneIcon(string prefix,string code)
    {
        Prefix = prefix;
        Code = code;

        Url= $"https://www.yuncaijing.com/quote/{prefix}{code}.html";
    }
}