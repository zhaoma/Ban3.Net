using Ban3.Infrastructures.Common.Contracts.Entities.Platforms.Sina;
using Ban3.Infrastructures.Common.Contracts.Requests.Platforms.Sina;
using Ban3.Infrastructures.Common.Contracts.Responses.Platforms.Sina;
using Ban3.Infrastructures.Common.Extensions;
using Ban3.Infrastructures.Interfaces;
using log4net;
using System.Collections.Generic;
using System.Linq;

namespace Ban3.Infrastructures.Platforms.ViaSina
{
    public class Service
        :Interfaces.Platforms.ISina
    {
        private readonly ILog _logger;
        private readonly IDataCollection _collector;

        ///
        public Service(ILog logger, IDataCollection collector)
        {
            _logger = logger;
            _collector = collector;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="request"></param>
        /// <returns>Sina ShareBonus List</returns>
        public DownloadEventsResult DownloadEvents(DownloadEvents request)
        {
            var html = _collector.GetContent(request.NetResource());

            return new DownloadEventsResult { Data = ParseEvents(html) };
        }

        List<ShareBonus> ParseEvents(string html)
        {
            var result = new List<ShareBonus>();
            var sb1 = html.Substr("<!--分红 begin-->", "<!--分红 end-->");

            if (!string.IsNullOrEmpty(sb1))
            {
                var atrs = sb1.SplitTbody();

                foreach (var atr in atrs)
                {
                    if (atr != null && atr.Count() > 4)
                    {
                        if (atr[1].ToDecimal() != 0 || atr[2].ToDecimal() != 0 || atr[3].ToDecimal() != 0)
                        {
                            result.Add(new ShareBonus
                            {
                                EventType = (int)Common.Contracts.Enums.StockEventType.Fenghong,
                                EventSubject = "分红",
                                MarkTime = atr[5].ToDateTime().ToString("yyyy-MM-ddTHH:mm:ssZ").ToDateTime(),
                                Sbonus = atr[1].ToDecimal(),
                                Zbonus = atr[2].ToDecimal(),
                                Xmoney = atr[3].ToDecimal()
                            });
                        }
                    }
                }
            }

            var sb2 = html.Substr("<!--配股 begin-->", "<!--配股 end-->");
            if (!string.IsNullOrEmpty(sb2))
            {
                var btrs = sb2.SplitTbody();

                foreach (var atr in btrs)
                {
                    if (atr != null && atr.Count() > 4)
                    {
                        if (atr[1].ToDecimal() != 0 || atr[2].ToDecimal() != 0 || atr[3].ToDecimal() != 0)
                        {
                            result.Add(new ShareBonus
                            {
                                EventType = (int)Common.Contracts.Enums.StockEventType.Peigu,
                                EventSubject = "配股",
                                MarkTime = atr[4].ToDateTime().ToString("yyyy-MM-ddTHH:mm:ssZ").ToDateTime(),
                                Pbonus = atr[1].ToDecimal(),
                                Pprice = atr[2].ToDecimal(),
                                Pcapital = atr[3].ToDecimal()
                            });
                        }
                    }
                }
            }

            return result;
        }

        public DownloadLiftsResult DownloadLifts(DownloadLifts request)
        {
            var html = _collector.GetContent(request.NetResource());

            return new DownloadLiftsResult { Data=ParseLifts(html)};
        }

        List<ShareBonus> ParseLifts(string html)
        {
            var result = new List<ShareBonus>();
            var sl = html.Substr("<div id=\"divContainer\">", "</table>");
            var trs = sl.SplitTbody();
            foreach (var atr in trs)
            {
                if (atr != null && atr.Count() > 3)
                    if (atr[3].ToDecimal() != 0)
                    {
                        result.Add(new ShareBonus
                        {
                            EventType = (int)Common.Contracts.Enums.StockEventType.Jiejin,
                            EventSubject = "解禁",
                            MarkTime = atr[2].ToDateTime().ToString("yyyy-MM-ddTHH:mm:ssZ").ToDateTime(),
                            Lifted = atr[3].ToDecimal() * 10000M
                        });
                    }
            }
            return result;
        }
    }
}