// ——————————————————————————————————————
// zhaoma @ 2022 :
// /Users/zhaoma/Projects/fintry/src/Ban3dotnet/Infrastructures/Common/Exchanges/Request/Platforms/Sina/GetBonus.cs
// ——————————————————————————————————————

using Ban3.Infrastructures.NetHttp.Entries;

namespace Ban3.Sites.ViaSina.Request
{
    ///
    public class DownloadEvents
        : TargetResource
    {
        ///
		public DownloadEvents(string code)
		{
            Code = code;

            Url = $"http://money.finance.sina.com.cn/corp/go.php/vISSUE_ShareBonus/stockid/{Code}.phtml";
            Charset = "gb2312";
        }

        /// <summary>
        /// 
        /// </summary>
        public string Code { get; set; }
    }
}

