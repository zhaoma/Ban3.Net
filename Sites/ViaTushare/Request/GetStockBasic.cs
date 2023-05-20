using System.Collections.Generic;
using Ban3.Infrastructures.Common.Extensions;
using Ban3.Infrastructures.NetHttp.Request;
using Ban3.Sites.ViaTushare.Entries;

namespace Ban3.Sites.ViaTushare.Request;

public class GetStockBasic:GetBase
{
    public GetStockBasic()
    {
        ApiRequestBody = new ApiRequestBody
        {
            ApiName = "stock_basic",
            FieldList = new StockBasic().RequestFields
        };
        Body = new Body { StringContent = ApiRequestBody.ObjToJson() };
    }
}