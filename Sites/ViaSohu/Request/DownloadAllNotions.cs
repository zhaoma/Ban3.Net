// ——————————————————————————————————————
// zhaoma @ 2022 :
// /Users/zhaoma/Projects/fintry/src/Ban3dotnet/Infrastructures/Common/Exchanges/Request/Platforms/Sohu/GetNotions.cs
// ——————————————————————————————————————

using Ban3.Infrastructures.NetHttp.Entries;

namespace Ban3.Sites.ViaSohu.Request
{
    public class DownloadAllNotions
        : TargetResource
    {
        /// <summary>
        /// 
        /// </summary>
        public int SohuId { get; set; }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public DownloadAllNotions()
        {
            Url = $"http://hq.stock.sohu.com/pl/pl-{SohuId}.html";
            Charset = "gb2312";
        }
    }
}

