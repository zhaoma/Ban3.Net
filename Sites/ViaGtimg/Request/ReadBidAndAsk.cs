// ——————————————————————————————————————
// zhaoma @ 2022 :
// /Users/zhaoma/Projects/fintry/src/Ban3dotnet/Infrastructures/Common/Exchanges/Request/Platforms/Gtimg/GetBidAndAsk.cs
// ——————————————————————————————————————

namespace Ban3.Sites.ViaGtimg.Request
{
	public class ReadBidAndAsk
        :NormalRequest
	{
		public ReadBidAndAsk()
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
                Url = Servers.Gtimg.UrlForReadBidANdAsk(Code)
            };
        }
    }
}

