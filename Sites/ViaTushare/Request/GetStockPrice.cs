using Ban3.Infrastructures.Common.Extensions;
using Ban3.Infrastructures.NetHttp.Request;
using Ban3.Sites.ViaTushare.Entries;

namespace Ban3.Sites.ViaTushare.Request;

public class GetStockPrice:GetBase
{
    public GetStockPrice(GetDailyParams getDailyParams)
    {
        ApiRequestBody = new ApiRequestBody
        {
            ApiName = "daily",
            FieldList=new StockPrice().RequestFields,
            Params = getDailyParams.ToDictionary()
        };
        Body = new Body { StringContent = ApiRequestBody.ObjToJson() };
    }
}