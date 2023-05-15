using System.Collections.Generic;
using Newtonsoft.Json;

namespace Ban3.Infrastructures.WxsConfig.Entries
{
    /// <summary>
    /// https://documentation.help/WiX-Help/wxs.htm
    /// </summary>
    public class WxsXml
    {
        [JsonProperty("fileName", NullValueHandling = NullValueHandling.Ignore)]
        public string FileName { get; set; }

        [JsonProperty("filePath", NullValueHandling = NullValueHandling.Ignore)]
        public string FilePath { get; set; }

        [JsonProperty("directories", NullValueHandling = NullValueHandling.Ignore)]
        public List<WxsDirectory> Directories { get; set; }

        /// <summary>
        /// 从Directories解析出所有目标文件
        /// </summary>
        [JsonProperty("files", NullValueHandling = NullValueHandling.Ignore)]
        public List<WxsFile> Files { get; set; }
    }
}
