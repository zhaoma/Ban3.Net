using Ban3.Sites.ViaTushare.Entries;
using System.Collections.Generic;

namespace Ban3.Sites.ViaTushare.Response;

public class GetStockPriceResult
{
    public List<StockPrice> Data { get; set; } = new();
}