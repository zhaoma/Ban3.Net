using Ban3.Infrastructures.Common.Contracts.Entities.Platforms.Sohu;
using Ban3.Infrastructures.Common.Contracts.Requests.Platforms.Sohu;
using Ban3.Infrastructures.Common.Contracts.Responses.Platforms.Sohu;
using Ban3.Infrastructures.Common.Extensions;
using Ban3.Infrastructures.Interfaces;
using log4net;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;

namespace Ban3.Infrastructures.Platforms.ViaSohu
{
    public class Service
        : Interfaces.Platforms.ISohu
    {
        private readonly ILog _logger;
        private readonly IDataCollection _collector;

        /// 
        public Service(ILog logger, IDataCollection collector)
        {
            _logger = logger;
            _collector = collector;
        }

        public DownloadAllNotionsResult DownloadAllNotions()
        {
            var result = Common.Contracts.Servers.Sohu.Mappings
                .Select(o => ReadGroup(o))
                .ToList();

            return new DownloadAllNotionsResult { Data = result };
        }

        Mapping ReadGroup(Mapping target)
        {
            var request = new DownloadAllNotions
            {
                SohuId = target.SohuId
            };

            var js = _collector.GetContent(request.NetResource());
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

        List<string> ReadNotion(int notionId)
        {
            var request = new DownloadNotionStocks { NotionId = notionId };
            var html = _collector.GetContent(request.NetResource());

            return html.FindHtmlTd("e1");
        }
    }
}