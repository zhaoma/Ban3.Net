using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Ban3.Infrastructures.Common.Extensions;
using Ban3.Productions.Casino.Contracts.Entities;
using Ban3.Productions.Casino.Contracts.Interfaces;
using Ban3.Sites.ViaTushare.Request;
using Ban3.Sites.ViaYuncaijing.Request;
using Newtonsoft.Json.Bson;

namespace Ban3.Productions.Casino.Contracts.Extensions;

public static partial class Helper
{
    #region icons
    /// <summary>
    /// 云财经有防火墙规则
    /// </summary>
    /// <param name="_"></param>
    /// <returns></returns>
    [Obsolete("云财经有防火墙规则")]
    public static bool DownloadAllIcons(this ISites _)
    {
        var result = true;

        var local = _.LoadAllCodes();

        /*
        local.ParallelExecute((stock) =>
        {
            var t = _.DownloadOnesIcon(stock.Code);
            var line =t ? "OK" : "FAILED";

            result = result && t;
            Logger.Debug($"download {stock.Code} icon : {line}");
        },Config.MaxParallelTasks);
        */

        local.ForEach(stock =>
        {
            var t = _.DownloadOnesIcon(stock.Code);
            var line = t ? "OK" : "FAILED";

            result = result && t;
            Logger.Debug($"download {stock.Code} icon : {line}");
            (3, 7).RandomDelay();
        });

        return result;
    }

    public static bool DownloadOnesIcon(this ISites _, string code)
    {
        var result = Sites.ViaYuncaijing.Helper
            .DownloadOneIcon(new DownloadOneIcon(code.GetStockPrefix(), code))
            .Result;

        return !string.IsNullOrEmpty(result.Path);
    }

    #endregion

    #region codes

    [Obsolete("tushare 数据更有用些,use PrepareAllCodesFromTushare")]
    public static bool PrepareAllCodesFromEastmoney(this ISites _)
    {
        var codes = Sites.ViaEastmoney.Helper.DownloadAllCodes().Result.Data.Diff;

        var local = _.LoadAllCodes();
        if (local != null)
        {
            local.AddRange(codes.FindAll(x => local.All(y => y.Code != x.Code)).Select(o => new Stock
            {
                Code = o.Code,
                Name = o.Name
            }));
        }
        else
        {
            local = codes.Select(o => new Stock
            {
                Code = o.Code,
                Name = o.Name
            }).ToList();
        }

        return !string.IsNullOrEmpty(
            local
                .SetsFile()
                .WriteFile(local.ObjToJson()));
    }

    public static bool PrepareAllCodesFromTushare(this ISites _)
    {
        var result = Sites.ViaTushare.Helper.GetStockBasic(new GetStockBasic());

        var local = _.LoadAllCodes();
        if (local != null)
        {
            local.AddRange(result.Data.FindAll(x => local.All(y => y.Code != x.Code)).Select(o => new Stock
            {
                Code = o.Code,
                Symbol = o.Symbol,
                Name = o.Name,
                ListDate = o.ListDate
            }));
        }
        else
        {
            local = result.Data.Select(o => new Stock
            {
                Code = o.Code,
                Symbol = o.Symbol,
                Name = o.Name,
                ListDate = o.ListDate
            }).ToList();
        }

        return !string.IsNullOrEmpty(
            local.SetsFile()
                .WriteFile(local.ObjToJson())
        );
    }

    public static List<Stock> LoadAllCodes(this ISites _)
        => typeof(Stock)
            .LocalFile()
            .ReadFileAs<List<Stock>>();

    #endregion

    public static bool GetDailyPrices(this ISites _,List<string> tsCodes,string startDate,string endDate)
    {
        var getDailyParams = new GetDailyParams(tsCodes);

        getDailyParams.StartDate = startDate;
        getDailyParams.EndDate = endDate;

        var result=Sites.ViaTushare.Helper.GetStockPrice(new GetStockPrice(getDailyParams));

        Console.WriteLine(result.ObjToJson());

        return true;
    }
}