using System;
using System.Linq;
using System.Threading.Tasks;
using Ban3.Infrastructures.Common.Extensions;
using Ban3.Infrastructures.NetHttp;
using Ban3.Infrastructures.NetHttp.Entries;
using Ban3.Sites.ViaTushare.Entries;
using Ban3.Sites.ViaTushare.Request;
using Ban3.Sites.ViaTushare.Response;

namespace Ban3.Sites.ViaTushare;

public static class Helper
{
    public static async Task<GetBaseResult> GetBase(GetBase request)
    {
        return await new TargetHost { Anonymous = true }
            .RequestGeneric<GetBaseResult>(request);
    }

    public static GetStockBasicResult GetResult(this GetStockBasic request)
    {
        var result=new GetStockBasicResult();

        var baseResult =GetBase(request).Result;

        Console.WriteLine(request.ObjToJson());
        Console.WriteLine(baseResult.Message);

        if (baseResult is { Data: { } })
        {
            result.Data = baseResult.Data.Items.Select(o => new StockBasic(o)).ToList();
        }
        
        return result;
    }

    public static GetStockPriceResult GetResult(this GetStockPrice request)
    {
        var result = new GetStockPriceResult();

        var baseResult = GetBase(request).Result;

        if (baseResult is { Data: { } })
        {
            result.Data = baseResult.Data.Items.Select(o => new StockPrice(o)).ToList();
        }

        return result;
    }
}