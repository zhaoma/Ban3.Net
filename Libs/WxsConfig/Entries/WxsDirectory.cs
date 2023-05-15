using System.Collections.Generic;
using Newtonsoft.Json;

namespace Ban3.Infrastructures.WxsConfig.Entries
{
    public class WxsDirectory
    {
        [JsonProperty("lognName", NullValueHandling = NullValueHandling.Ignore)]
        public string LongName { get; set; }

        [JsonProperty("files", NullValueHandling = NullValueHandling.Ignore)]
        public List<WxsFile> Files { get; set; }

        [JsonProperty("subDirectories", NullValueHandling = NullValueHandling.Ignore)]
        public List<WxsDirectory> SubDirectories { get; set; }
    }
}
