using Ban3.Infrastructures.Common.Extensions;
using Ban3.Infrastructures.NetHttp.Request;
using Ban3.Sites.ViaTushare.Entries;

namespace Ban3.Sites.ViaTushare.Request;

public class GetStockPrice:GetBase
{
    public GetStockPrice(GetProBarParams getProBarParams)
    {
        ApiRequestBody = new ApiRequestBody
        {
            ApiName = "pro_bar",
            FieldList=new StockPrice().RequestFields,
            Params = getProBarParams.ToDictionary()
        };
        Body = new Body { StringContent = ApiRequestBody.ObjToJson() };
    }
}