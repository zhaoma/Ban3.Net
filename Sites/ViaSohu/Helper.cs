using System.Collections.Generic;
using System.Linq;
using Ban3.Infrastructures.Common.Extensions;
using Ban3.Infrastructures.NetHttp;
using Ban3.Sites.ViaSohu.Entries;
using Ban3.Sites.ViaSohu.Request;
using Ban3.Sites.ViaSohu.Response;
using log4net;

namespace Ban3.Sites.ViaSohu
{
    public static partial class Helper
    {
        public static DownloadAllNotionsResult DownloadAllNotions()
        {
            var result = Sohu.Mappings
                .Select(o => ReadGroup(o))
                .ToList();

            return new DownloadAllNotionsResult { Data = result };
        }

        static Mapping ReadGroup(Mapping target)
        {
            var request = new DownloadAllNotions
            {
                SohuId = target.SohuId
            };

            var js = new Infrastructures.NetHttp.Entries.TargetHost
            {
                Anonymous = true
            }.ReadContent(request).Result;
            var json = $"[{js.Substr("'pllist',", "])</script>")}" + "]";

            var result = json.JsonToObj<List<string[]>>();

            target.Notions = result.Select(o => new Notion
            {
                NotionId = o[0].ToInt(),
                Subject = o[1],
                Stocks=ReadNotion(o[0].ToInt())
            }).ToList();

            return target;
        }

        static List<string> ReadNotion(int notionId)
        {
            var request = new DownloadNotionStocks { NotionId = notionId };
            var html = new Infrastructures.NetHttp.Entries.TargetHost
            {
                Anonymous = true
            }.ReadContent(request).Result;

            return html.FindHtmlTd("e1");
        }
    }
}