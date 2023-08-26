// ——————————————————————————————————————
// zhaoma @ 2022 :
// /Users/zhaoma/Projects/fintry/src/Ban3dotnet/Infrastructures/Common/Exchanges/Request/Platforms/Gtimg/GetBrief.cs
// ——————————————————————————————————————

using Ban3.Infrastructures.NetHttp.Entries;

namespace Ban3.Sites.ViaGtimg.Request
{
	public class ReadBrief
		:TargetResource
	{
		public ReadBrief(string code)
		{
            Code = code;
            Url= $"http://qt.gtimg.cn/q=s_sz000858";
        }

        /// <summary>
        /// 
        /// </summary>
        public string Code { get; set; }
    }
}

