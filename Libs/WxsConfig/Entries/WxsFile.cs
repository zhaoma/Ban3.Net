using Newtonsoft.Json;

namespace Ban3.Infrastructures.WxsConfig.Entries
{
    public class WxsFile
    {
        [JsonProperty("longName", NullValueHandling = NullValueHandling.Ignore)]
        public string LongName { get; set; }

        [JsonProperty("source", NullValueHandling = NullValueHandling.Ignore)]
        public string Source { get; set; }
    }
}
