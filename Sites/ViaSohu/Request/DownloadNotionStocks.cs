//  ————————————————————————————————————————————————————————————————————————————
//  zhaoma @ 2022/9/25 09:27
//  function:	DownloadNotionStocks.cs
//  reference:	https://
//  ————————————————————————————————————————————————————————————————————————————

using Ban3.Infrastructures.NetHttp.Entries;
using Ban3.Sites.ViaSohu.Entries;

namespace Ban3.Sites.ViaSohu.Request
{
	public class DownloadNotionStocks
        : TargetResource
    {
		public DownloadNotionStocks()
        {
            Charset = "gb2312";
            Url = $"http://q.stock.sohu.com/cn/bk_{NotionId}.shtml"; 
        }

        /// <summary>
        /// 
        /// </summary>
        public int NotionId { get; set; }
    }
}

