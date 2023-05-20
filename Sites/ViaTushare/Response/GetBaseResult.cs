using Ban3.Sites.ViaTushare.Entries;
using Newtonsoft.Json;

namespace Ban3.Sites.ViaTushare.Response;

public class GetBaseResult
{
    [JsonProperty("request_id")]
    public string RequestId { get; set; } = string.Empty;

    [JsonProperty("code")]
    public int Code { get; set; }

    [JsonProperty("msg")]
    public string Message { get; set; } = string.Empty;

    [JsonProperty("data")]
    public ApiResponseData? Data { get; set; }
}