// ——————————————————————————————————————
// zhaoma @ 2022 :
// /Users/zhaoma/Projects/fintry/src/Ban3dotnet/Infrastructures/Common/Exchanges/Request/Platforms/Gtimg/GetBrief.cs
// ——————————————————————————————————————

namespace Ban3.Sites.ViaGtimg.Request
{
	public class ReadBrief
		:NormalRequest
	{
		public ReadBrief()
		{
		}

        /// <summary>
        /// 
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override Servers.NetResource NetResource()
        {
            return new Servers.NetResource
            {
                Url = Servers.Gtimg.UrlForReadBrief(Code)
            };
        }
    }
}

