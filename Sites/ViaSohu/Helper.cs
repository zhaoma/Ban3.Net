using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        static readonly List<Mapping> Mappings =
            new List<Mapping>
            {
                new Mapping
                {
                    GroupName = "行业",
                    SohuId = 1631
                },
                new Mapping
                {
                    GroupName = "地域",
                    SohuId = 1632
                },
                new Mapping
                {
                    GroupName = "概念",
                    SohuId = 1630
                }
            };

        public static DownloadAllNotionsResult DownloadAllNotions()
        {
            var result = Mappings
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

            var bytes = new Infrastructures.NetHttp.Entries.TargetHost
            {
                Anonymous = true
            }.ReadBytes(request).Result;
            
            Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            var js = Encoding.GetEncoding(request.Charset).GetString(bytes);

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