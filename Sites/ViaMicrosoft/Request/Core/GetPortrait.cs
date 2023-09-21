using Ban3.Infrastructures.NetHttp.Entries;
using Ban3.Sites.ViaMicrosoft.Enums;
using Newtonsoft.Json;

namespace Ban3.Sites.ViaMicrosoft.Request.Core;

/// <summary>
/// 下载头像
/// </summary>
public class GetPortrait
    : TargetResource
{
    [JsonProperty("id")] public string Id { get; set; } = string.Empty;

    public GetPortrait()
    {
        Url = APIResource.Portrait.ToAPIResourceString(Id);
    }
}