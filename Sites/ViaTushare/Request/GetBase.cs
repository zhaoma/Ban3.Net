using Ban3.Infrastructures.NetHttp.Entries;
using Ban3.Sites.ViaTushare.Entries;

namespace Ban3.Sites.ViaTushare.Request;

public class GetBase
:TargetResource
{
    public GetBase()
    {
        Url= @"http://api.tushare.pro";
        Method = "Post";
    }

    public ApiRequestBody ApiRequestBody { get; set; } = new();
}