using Ban3.Infrastructures.NetHttp.Entries;
using Newtonsoft.Json;

namespace Ban3.Sites.ViaMicrosoft.Request;

public class MultiPageQuery : TargetResource
{
    /// <summary>
    /// Number of results to skip. Default: null
    /// </summary>
    [JsonProperty("$skip")]
    public int Skip { get; set; }

    /// <summary>
    /// The maximum number of results to return. Default: null
    /// </summary>
    [JsonProperty("$top")]
    public int Top { get; set; }
}
